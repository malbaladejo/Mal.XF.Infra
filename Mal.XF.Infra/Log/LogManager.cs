using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mal.XF.Infra.Log
{
    internal class LogManager : ILogManager
    {
        public const string LogKey = "LogKey";

        public IReadOnlyCollection<LogItem> GetLogs()
        {
            throw new NotImplementedException();
        }

        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        private static T GetProperty<T>(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                var data = (string)Application.Current.Properties[key];
                return JsonConvert.DeserializeObject<T>(data);
            }

            return default(T);
        }
    }
}
