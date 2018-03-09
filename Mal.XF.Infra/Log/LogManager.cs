using Mal.XF.Infra.Threading;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mal.XF.Infra.Log
{
    public class LogManager : ILogManager
    {
        public const string LogKey = "LogKey";
        private readonly ActionDelayed writeLogActionDelayed;
        private List<LogItem> logItems;

        public LogManager()
        {
            this.writeLogActionDelayed = new ActionDelayed();
        }

        public IReadOnlyCollection<LogItem> GetLogs()
        {
            this.EnsureLogItems();
            return this.logItems;
        }

        public void WriteLog(LogItem item)
        {
            this.EnsureLogItems();
            this.logItems.Add(item);
            this.writeLogActionDelayed.Start(this.WriteLogWithDelay);
        }

        public void WriteLogWithDelay()
        {
            // Fire and forget
            Task.Run(async () =>
            {
                await SetPropertyAsync(LogKey, this.logItems);
            });
        }

        public async void ClearLog()
        {
            this.logItems = null;
            await SetPropertyAsync(LogKey, string.Empty);
        }

        private void EnsureLogItems()
        {
            if (this.logItems == null)
            {
                var items = GetProperty<IReadOnlyCollection<LogItem>>(LogKey);
                this.logItems = items == null ? new List<LogItem>() : new List<LogItem>(items);
            }
        }

        private static T GetProperty<T>(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                var data = (string)Application.Current.Properties[key];
                try
                {
                    return JsonConvert.DeserializeObject<T>(data);
                }
                catch (Exception)
                {
                    // Nothing to do
                }
            }

            return default(T);
        }

        private static async Task SetPropertyAsync(string key, object value)
        {
            Application.Current.Properties[key] = JsonConvert.SerializeObject(value);
            await Application.Current.SavePropertiesAsync();
        }
    }
}
