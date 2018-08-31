using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAcceso
{
    public class ServiceLayerException: Exception
    {
        public ServiceLayerException()
            : base() { }

        public ServiceLayerException(string message)
            : base(message) { }

        public ServiceLayerException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ServiceLayerException(string message, Exception innerException)
            : base(message, innerException) { }

        public ServiceLayerException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
