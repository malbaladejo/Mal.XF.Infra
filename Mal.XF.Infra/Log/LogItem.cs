using System;

namespace Mal.XF.Infra.Log
{
    public class LogItem
    {
        public LogItem(LogSeverity severity, string message, string data, DateTime dateTime, string className, string methodName)
        {
            this.Severity = severity;
            this.DateTime = dateTime;
            this.Message = message;
            this.Data = data;
            this.ClassName = className;
            this.MethodName = methodName;
        }

        public LogSeverity Severity { get; }
        public DateTime DateTime { get; }
        public string Message { get; }
        public string Data { get; }
        public string ClassName { get; }
        public string MethodName { get; }
    }
}
