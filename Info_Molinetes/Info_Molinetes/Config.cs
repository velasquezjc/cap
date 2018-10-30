using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Info_Molinetes
{
    public class Config
    {
        public static string Key_Cnn_DB_Molinetes = "DB_Molinetes";
        public static string Key_Cnn_DB_DB_RRHH = "DB_RRHH";



        public static string get_path_script( string file_name )
        {
            return System.IO.Directory.GetCurrentDirectory() + @"\export\" + file_name; ;
        }

        public static string[] get_files_names(string filter)
        {
            string path = get_path_script( string.Empty );
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            Array.Sort(files, StringComparer.InvariantCulture);
            return files;
        }
    }
}
