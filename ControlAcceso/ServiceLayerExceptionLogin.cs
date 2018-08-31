using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAcceso
{
    public class ServiceLayerExceptionLogin: ServiceLayerException
    {
        public ServiceLayerExceptionLogin(string message) : base(message)
        {

        }
    }
}
