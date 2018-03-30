using Mal.XF.Infra.Collections;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Log;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LogViewModel : BindableBase, INavigationAware
    {
        private IReadOnlyCollection<LogItem> logsItems;
        private bool isBusy;
        private bool isLazyBusy;
        private readonly MockedLoadLogItemStrategy loadLogItemStrategy;

        public LogViewModel()
        {
            this.loadLogItemStrategy = new MockedLoadLogItemStrategy();
            this.LogsItems = new LazyObservableCollection<LogItem>(this.loadLogItemStrategy, 10);
            this.RefreshCommand = new DelegateCommand(this.RefreshLogs);
            this.ClearCommand = new DelegateCommand(this.ClearLog);

            this.SeverityFilters = new[]
            {
                new SeverityViewModel(LogSeverity.Debug),
                new SeverityViewModel(LogSeverity.Info),
                new SeverityViewModel(LogSeverity.Error)
            };
            this.SeverityFilters.ForEach(f => f.PropertyChanged += FilterSelectionChanged);
        }

        private void FilterSelectionChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SeverityViewModel.IsSelected))
                this.RefreshFilterAsync();
        }

        public bool IsBusy
        {
            get { return this.isBusy; }
            private set { this.SetProperty(ref this.isBusy, value); }
        }

        public bool IsLazyBusy
        {
            get { return this.isLazyBusy; }
            private set { this.SetProperty(ref this.isLazyBusy, value); }
        }


        public ICommand RefreshCommand { get; }
        public ICommand ClearCommand { get; }

        public LazyObservableCollection<LogItem> LogsItems { get; }

        public IReadOnlyCollection<SeverityViewModel> SeverityFilters { get; }

        private async void RefreshLogs()
        {
            try
            {
                this.IsBusy = true;
                //this.logsItems = this.logManager.GetLogs().OrderByDescending(l => l.DateTime).ToList();
                this.loadLogItemStrategy.Reset();
                //await this.RefreshFilterAsync();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private async void ClearLog()
        {
            try
            {
                this.logsItems = null;
                await this.RefreshFilterAsync();
                //this.logManager.ClearLog();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private Task RefreshFilterAsync()
        {
            return Task.Run(() =>
            {
                this.SeverityFilters.ForEach(i => i.InitializeFromLogItems(this.logsItems));
                this.LogsItems.Clear();

                if (this.logsItems == null)
                    return;

                var filteredItems = this.logsItems.Where(i => this.SeverityFilters.Any(f => f.IsMatch(i)));
                this.LogsItems.AddRange(filteredItems);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // Nothing to do
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.RefreshLogs();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // Nothing to do
        }
    }
}
