namespace Mal.XF.Infra.Log
{
    internal class Logger : ILogger
    {
        private readonly LogManager logManager;

        public Logger(LogManager logManager)
        {
            this.logManager = logManager;
        }

        public void Debug(string message)
            => this.WriteLog(message, LogSeverity.Debug);

        public void Info(string message)
            => this.WriteLog(message, LogSeverity.Info);

        public void Error(string message)
            => this.WriteLog(message, LogSeverity.Error);

        private void WriteLog(string message, LogSeverity severity)
            => this.logManager.WriteLog(new LogItem(severity, message));
    }
}
