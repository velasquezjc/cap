using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAcceso
{
    public static class SincronizarInfo
    {

        public enum eProcesos
        {
            p0_Sin_Proceso,
            p1_Act_Dotacion,
            p2_Inf_Novedades,
            p3_Finalizado
        }

        public enum eStatusProc
        {
            sOk,
            sBloqueoXProceso,
            sError,
        }

        public enum eSubProc
        {
            esp_SinProceso,
            esp_ad1_GetDotRemota,
            esp_ad2_ActDotLocal,
            esp_in1_GenLotes,
            esp_in2_InfLotes,
            esp_Finalizado
        }


        private static eProcesos _Proceso_Actual = eProcesos.p0_Sin_Proceso;
        public static eProcesos Proceso_Actual
        {
            get { return SincronizarInfo._Proceso_Actual; }
            set { SincronizarInfo._Proceso_Actual = value; }
        }

        private static eSubProc _SubProceso_Actual = eSubProc.esp_SinProceso;
        private static eSubProc SubProceso_Actual
        {
            get { return SincronizarInfo._SubProceso_Actual; }
            set { SincronizarInfo._SubProceso_Actual = value; }
        }


        private static eStatusProc _Estado = eStatusProc.sOk;
        public static eStatusProc Estado
        {
            get { return SincronizarInfo._Estado; }
            set { SincronizarInfo._Estado = value; }
        }

        private static bool Procesando = false;

        private static StringBuilder _sbBitacora = new StringBuilder();
        public static string Bitacora
        {
            get { return _sbBitacora.ToString(); }
        }

        private static string Info_Ult_Proceso = string.Empty;
        public static string InfoEstado
        {
            get { return Info_Ult_Proceso; }
        }


        private static Dotacion dotacion_local = new Dotacion();
        private static DataBase db_masivo = new DataBase();
        private static int DotTotal = 0;
        private static Persona[] aPerActualizacion;
        private static int index = 0;


        public static void Iniciar()
        {
            Log_Proceso("Iniciando proceso...");
        }


        public static eStatusProc Procesar()
        {
            if (Procesando) return eStatusProc.sBloqueoXProceso;
            Procesando = true;
            switch (Proceso_Actual)
            {
                case eProcesos.p0_Sin_Proceso:
                    Proceso_Actual = eProcesos.p1_Act_Dotacion;
                    break;
                case eProcesos.p1_Act_Dotacion:
                    Proceso_Actual = Proc_Dotacion();
                    break;
                case eProcesos.p2_Inf_Novedades:
                    Proceso_Actual = Proc_Novedades();
                    break;
            }
            Procesando = false;
            return Estado;
        }

        private static void Log_Proceso(string registro)
        {
            Info_Ult_Proceso = registro;
            _sbBitacora.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "= " + registro + System.Environment.NewLine);
        }

        private static eProcesos Proc_Dotacion()
        {
            switch (SubProceso_Actual)
            {
                case eSubProc.esp_SinProceso:
                    SubProceso_Actual = eSubProc.esp_ad1_GetDotRemota;
                    // Obtener Dotacion desde la Web
                    var bdw = new ServiceLayer(); Dotacion dotacion_remota;
                    try
                    {
                        Log_Proceso("Recuperando dotacion local...");
                        dotacion_local.Recuperar_Dotacion_DB();
                        Log_Proceso("Conectando con el servidor remoto...");
                        dotacion_remota = bdw.Get_Dotacion();
                        Log_Proceso("Preparando la base de datos para la actualización...");
                        db_masivo.OpenMasivo(db_masivo.GenerarConexionString(DataBase.getDefaultPathDB()));
                    }
                    catch (Exception e)
                    {
                        Log_Proceso("Se produjo un error: " + e.Message);
                        Log_Proceso("No fue posible establecer la comunicación con el servidor remoto. Verifique su conexión de internet.");
                        return Set_Error_Irrecuperable();
                    }
                    DotTotal = dotacion_remota.personas.Count;
                    Log_Proceso("Se estableció la conexion con el servidor y se obtuvo la dotación.");
                    Log_Proceso("Cantidad de personas para actualizar: " + DotTotal.ToString() + "." );
                    Log_Proceso("Comienzo del proceso de actualizacion...");
                    Log_Proceso("Actualizando " + DotTotal.ToString() + " registros de dotación.");
                    // Actualizar Base local
                    aPerActualizacion = dotacion_remota.personas.ToArray();
                    index = 0;
                    Log_Proceso(String.Format("{0}% completado", (100 * index) / aPerActualizacion.Length));
                    Log_Proceso("Tiempo estimado: Calculando....");
                    SubProceso_Actual = eSubProc.esp_ad2_ActDotLocal;
                    break;
                case eSubProc.esp_ad2_ActDotLocal:
                    if (aPerActualizacion.Length <= index)
                    {
                        Log_Proceso("Fin del proceso de actualización de la base de datos local." + System.Environment.NewLine);
                        Log_Proceso("Cerrando la base de datos local." + System.Environment.NewLine);
                        db_masivo.CloseMasivo();
                        SubProceso_Actual = eSubProc.esp_Finalizado;
                        break;                
                    }
                    var perDot = aPerActualizacion[index];
                    if(!dotacion_local.personas.Exists(p => p.id==perDot.id))
                    {
                        if (perDot.Insert_Base_Local_Masivo(db_masivo))
                            Log_Proceso("El registro #" + (++index).ToString().Trim() + "  fue insertado en la BD."+ System.Environment.NewLine);
                        else
                            Log_Proceso("Error al intentar insertar la información del registro #" + (++index).ToString() + System.Environment.NewLine);
                    }
                    else
                    {
                        if (perDot.Update_Base_Local_Masivo(db_masivo))
                            Log_Proceso("El registro #" + (++index).ToString() + " actualizó información en la BD." + System.Environment.NewLine);
                        else
                            Log_Proceso("Error intentar actualizar la BD con la información del registro #" + (++index).ToString() + System.Environment.NewLine);
                    }
                    break;
            }

            return Get_Proximo_Proceso();
        }


        private static eProcesos Proc_Novedades()
        {
            return eProcesos.p3_Finalizado;
        }


        private static eProcesos Set_Error_Irrecuperable()
        {
            Estado = eStatusProc.sError;
            Proceso_Actual = eProcesos.p3_Finalizado;
            return Proceso_Actual;
        }

        private static eProcesos Get_Proximo_Proceso()
        {
            var porc_ret = eProcesos.p0_Sin_Proceso;
            switch (SubProceso_Actual)
            {
                case eSubProc.esp_SinProceso:
                case eSubProc.esp_ad1_GetDotRemota:
                case eSubProc.esp_ad2_ActDotLocal:
                    porc_ret = eProcesos.p1_Act_Dotacion;
                    break;
                case eSubProc.esp_in1_GenLotes:
                case eSubProc.esp_in2_InfLotes:
                    porc_ret = eProcesos.p2_Inf_Novedades;
                    break;
                case eSubProc.esp_Finalizado:
                default:
                    porc_ret = eProcesos.p3_Finalizado;
                    break;
            }
            return porc_ret;
        }

    }

}





















































