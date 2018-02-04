using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mal.XF.Infra.Log
{
    internal class LogManager : ILogManager
    {
        public const string LogKey = "LogKey";

        public IReadOnlyCollection<LogItem> GetLogs()
            => GetProperty<IReadOnlyCollection<LogItem>>(LogKey);

        public async void WriteLog(LogItem item)
        {
#pragma warning disable CS4014 
            // Fire and forget
            Task.Run(async () =>
            {
                var logs = this.GetLogs();

                await SetPropertyAsync(LogKey,
                    logs.Concat(new[] { item }));
            });
#pragma warning restore CS4014 
        }

        public async void ClearLog()
        {
            await SetPropertyAsync(LogKey, string.Empty);
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

        private static async Task SetPropertyAsync(string key, object value)
        {
            Application.Current.Properties[key] = JsonConvert.SerializeObject(value);
            await Application.Current.SavePropertiesAsync();
        }
    }
}
