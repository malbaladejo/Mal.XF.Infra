using Newtonsoft.Json;
using System;

namespace Mal.XF.Infra.Log
{
    public class LogItem
    {
        public LogItem(LogSeverity severity, string message)
            : this(severity, message, DateTime.Now)
        {

        }

        [JsonConstructor]
        public LogItem(LogSeverity severity, string message, DateTime dateTime)
        {
            Severity = severity;
            DateTime = dateTime;
            Message = message;
        }

        public LogSeverity Severity { get; }
        public DateTime DateTime { get; }
        public string Message { get; }
    }
}
