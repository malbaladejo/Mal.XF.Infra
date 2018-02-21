using Newtonsoft.Json;
using System;

namespace Mal.XF.Infra.Log
{
    public class LogItem
    {
        public LogItem(LogSeverity severity, string message, string data = null)
            : this(severity, message, data, DateTime.Now)
        {

        }

        [JsonConstructor]
        public LogItem(LogSeverity severity, string message, string data, DateTime dateTime)
        {
            Severity = severity;
            DateTime = dateTime;
            Message = message;
            this.Data = data;
        }

        public LogSeverity Severity { get; }
        public DateTime DateTime { get; }
        public string Message { get; }
        public string Data { get; }
    }
}
