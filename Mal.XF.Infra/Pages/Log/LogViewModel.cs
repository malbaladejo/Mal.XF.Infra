using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Log;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LogViewModel : BindableBase, INavigationAware
    {
        private readonly ILogManager logManager;
        private IReadOnlyCollection<LogItem> logsItems;
        public LogViewModel(ILogManager logManager)
        {
            this.logManager = logManager;
            this.LogsItems = new ObservableCollection<LogItem>();
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
            this.RefreshFilter();
        }

        public ICommand RefreshCommand { get; }
        public ICommand ClearCommand { get; }

        public ObservableCollection<LogItem> LogsItems { get; }

        public IReadOnlyCollection<SeverityViewModel> SeverityFilters { get; }

        private void RefreshLogs()
        {
            this.logsItems = this.logManager.GetLogs().OrderByDescending(l => l.DateTime).ToList();
            this.RefreshFilter();
        }

        private void ClearLog()
        {
            this.logsItems = null;
            this.RefreshFilter();
            this.logManager.ClearLog();
        }

        private void RefreshFilter()
        {
            this.SeverityFilters.ForEach(i => i.InitializeFromLogItems(this.logsItems));
            this.LogsItems.Clear();

            if (this.logsItems == null)
                return;

            var filteredItems = this.logsItems.Where(i => this.SeverityFilters.Any(f => f.IsMatch(i)));
            this.LogsItems.AddRange(filteredItems);
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
