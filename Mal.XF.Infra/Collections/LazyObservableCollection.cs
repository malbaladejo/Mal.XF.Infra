using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Collections
{
    public class LazyObservableCollection<T> : ObservableCollection<T>
    {
        private readonly ILoadItemsStrategy<T> loadItemsStrategy;
        private readonly int pageSize;
        private bool isBusy;

        private int lastIndex = 0;
        private int lastLoadedPage = 0;

        public LazyObservableCollection(ILoadItemsStrategy<T> loadItemsStrategy, int pageSize)
        {
            this.loadItemsStrategy = loadItemsStrategy;
            this.pageSize = pageSize;
            this.CollectionChanged += this.OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    this.lastIndex = 0;
                    this.lastLoadedPage = 0;
                    break;
            }
        }

        public async Task LoadItemsAsync(T item)
        {
            if (this.IsBusy)
                return;

            var pageNumber = this.GetPageNumber(item);

            if (pageNumber < this.lastLoadedPage)
                return;

            this.lastLoadedPage++;
            this.IsBusy = true;
            try
            {
                var newItems = await this.loadItemsStrategy.LoadItemsAsync(this.lastLoadedPage, this.pageSize);
                foreach (var newItem in newItems)
                    this.Add(newItem);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private int GetPageNumber<T>(T item)
        {
            var index = this.GetIndex(item);
            var pageNumber = index / this.pageSize;
            return pageNumber;
        }

        private int GetIndex<T>(T item)
        {
            for (int i = lastIndex; i < this.Count; i++)
            {
                if (this[i].Equals(item))
                {
                    this.lastIndex = i;
                    return i;
                }
            }

            return -1;
        }

        public bool IsBusy
        {
            get { return this.isBusy; }
            private set
            {
                this.isBusy = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.IsBusy)));
            }
        }
    }

    public interface ILoadItemsStrategy<T>
    {
        Task<IReadOnlyCollection<T>> LoadItemsAsync(int pageNumber, int pageSize);
    }
}
