using System;

namespace Mal.XF.Infra.Log
{
    public class LogItem
    {
        public LogItem(LogSeverity severity, DateTime dateTime, string message)
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
