using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyApi.Framework
{
    public class EmergencyException : Exception
    {
        private Dictionary<string, object> Parameters { get; set; }


        public EmergencyException()
        {
            Parameters = new Dictionary<string, object>();
        }

        public EmergencyException(string message) : base(message)
        {
            Parameters = new Dictionary<string, object>();
        }

        public EmergencyException(string message, int code)
            : base(message)
        {
            Code = code;
            Parameters = new Dictionary<string, object>();
        }


        public EmergencyException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args))
        {
        }

        public EmergencyException(string message, Dictionary<string, object> parameters)
            : base(message)
        {
            Parameters = parameters;
        }

        public void AddParameter(string key, object value)
        {
            Parameters.Add(key, value);
        }

        public int Code { get; set; }


    }
}