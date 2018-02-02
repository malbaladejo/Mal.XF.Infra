using System.Collections.Generic;

namespace Mal.XF.Infra.Log
{
    public interface ILogManager
    {
        IReadOnlyCollection<LogItem> GetLogs();

        void ClearLog();
    }
}
