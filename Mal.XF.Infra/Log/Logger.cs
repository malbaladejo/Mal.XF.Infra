using Mal.XF.Infra.Extensions;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Mal.XF.Infra.Log
{
    public class Logger : ILogger
    {
        private readonly LogManager logManager;
        private readonly LogSeverity minSeverity;

        public Logger(LogManager logManager, LogSeverity minSeverity)
        {
            this.logManager = logManager;
            this.minSeverity = minSeverity;
        }

        public void Debug(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Debug, message, filePath: filePath, memberName: memberName);

        public void Info(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Info, message, filePath: filePath, memberName: memberName);

        public void Warning(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Warning, message, filePath: filePath, memberName: memberName);

        public void Error(string message, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Error, message, filePath: filePath, memberName: memberName);

        public void Error(string message, Exception e, [CallerFilePath] string filePath = null, [CallerMemberName] string memberName = null)
            => this.WriteLog(LogSeverity.Error, message, e?.DumpAsString(), filePath, memberName);

        private void WriteLog(LogSeverity severity, string message, string data = null, string filePath = null,
            string memberName = null)
        {
            if ((int)minSeverity <= (int)severity)
                this.logManager.WriteLog(new LogItem(severity, message, data, DateTime.Now, filePath?.Split("\\".ToCharArray()).LastOrDefault(), memberName));
        }
    }
}
