using Mal.XF.Infra.Log;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace Mal.XF.Infra.Pages.Log
{
    internal class SeverityViewModel : BindableBase
    {
        public SeverityViewModel(LogSeverity severity, bool isSelected = true)
        {
            Severity = severity;
            this.IsSelected = isSelected;
        }

        public void InitializeFromLogItems(IReadOnlyCollection<LogItem> items)
        {
            this.NumberOfItems = items?.Count(i => i.Severity == this.Severity) ?? 0;
            this.IsEnabled = this.NumberOfItems > 0;
        }

        public bool IsMatch(LogItem item) => this.IsSelected && item.Severity == this.Severity;

        public LogSeverity Severity { get; }

        private int numberOfItems;
        public int NumberOfItems
        {
            get { return this.numberOfItems; }
            internal set { this.SetProperty(ref this.numberOfItems, value); }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set { this.SetProperty(ref this.isSelected, value); }
        }


        private bool isEnabled;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            private set { this.SetProperty(ref this.isEnabled, value); }
        }
    }
}