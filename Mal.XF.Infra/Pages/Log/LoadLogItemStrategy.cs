using Mal.XF.Infra.Collections;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LoadLogItemStrategy : ILoadItemsStrategy<LogItem>
    {
        private IReadOnlyCollection<LogItem> logsItems;
        private readonly ILogManager logManager;

        public LoadLogItemStrategy(ILogManager logManager)
        {
            this.logManager = logManager;
        }

        public Task<IReadOnlyCollection<LogItem>> LoadItemsAsync(int pageNumber, int pageSize)
        {
            this.EnsureLogItems();


            return Task.Run(() => this.logsItems.Skip(pageNumber * pageSize)
                                                .Take(pageSize)
                                                .ToReadOnlyCollection());
        }

        public void Reset()
        {
            this.logsItems = null;
        }

        private void EnsureLogItems()
        {
            if (this.logsItems != null)
                return;

            this.logsItems = this.logManager.GetLogs().OrderByDescending(l => l.DateTime).ToList();
        }
    }

    internal class MockedLoadLogItemStrategy : ILoadItemsStrategy<LogItem>
    {
        private IReadOnlyCollection<LogItem> logsItems;

        public MockedLoadLogItemStrategy()
        {
        }

        public Task<IReadOnlyCollection<LogItem>> LoadItemsAsync(int pageNumber, int pageSize)
        {

            return Task.Run(async () =>
            {
                await Task.Delay(5000);
                this.EnsureLogItems();

                return this.logsItems.Skip(pageNumber * pageSize)
                                                 .Take(pageSize)
                                                 .ToReadOnlyCollection();
            });
        }

        public void Reset()
        {
            this.logsItems = null;
        }

        private void EnsureLogItems()
        {
            if (this.logsItems != null)
                return;

            var items = new List<LogItem>();

            for (int i = 0; i < 10000; i++)
            {
                items.Add(new LogItem(LogSeverity.Info, i.ToString(), string.Empty, DateTime.Now, string.Empty, string.Empty));
            }

            this.logsItems = items;
        }
    }
}
