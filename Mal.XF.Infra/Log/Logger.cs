using Mal.XF.Infra.Extensions;
using System;

namespace Mal.XF.Infra.Log
{
    public class Logger : ILogger
    {
        private readonly LogManager logManager;

        public Logger(LogManager logManager)
        {
            this.logManager = logManager;
        }

        public void Debug(string message)
            => this.WriteLog(LogSeverity.Debug, message);

        public void Info(string message)
            => this.WriteLog(LogSeverity.Info, message);

        public void Warning(string message)
            => this.WriteLog(LogSeverity.Warning, message);

        public void Error(string message)
            => this.WriteLog(LogSeverity.Error, message);

        public void Error(string message, Exception e)
            => this.WriteLog(LogSeverity.Error, message, e?.DumpAsString());

        private void WriteLog(LogSeverity severity, string message, string data = null)
            => this.logManager.WriteLog(new LogItem(severity, message, data));
    }
}
