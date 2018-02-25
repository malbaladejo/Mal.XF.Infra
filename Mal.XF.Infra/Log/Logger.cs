using Mal.XF.Infra.Extensions;
using System;
using System.Runtime.CompilerServices;

namespace Mal.XF.Infra.Log
{
    public class Logger : ILogger
    {
        private readonly LogManager logManager;

        public Logger(LogManager logManager)
        {
            this.logManager = logManager;
        }

        public void Debug(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Debug, message);

        public void Info(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Info, message);

        public void Warning(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Warning, message);

        public void Error(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Error, message);

        public void Error(string message, Exception e, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Error, message, e?.DumpAsString());

        private void WriteLog(LogSeverity severity, string message, string data = null, string filePath = null, string memberName = null)
            => this.logManager.WriteLog(new LogItem(severity, message, data, DateTime.Now, filePath, memberName));
    }
}
