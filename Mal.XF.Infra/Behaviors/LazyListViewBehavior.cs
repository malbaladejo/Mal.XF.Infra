using Mal.XF.Infra.Collections;
using System.Collections;
using Xamarin.Forms;

namespace Mal.XF.Infra.Behaviors
{
    public class LazyListViewBehavior : BehaviorBase<ListView>
    {
        private ActivityIndicator activityIndicator;

        protected override void OnAttachedTo(ListView list)
        {
            base.OnAttachedTo(list);
            this.AssociatedObject.ItemAppearing += OnItemAppearing;
            this.AssociatedObject.PropertyChanged += this.OnAssociatedObjectPropertyChanged;

            this.EnsureActivityIndicator();

            this.AssociatedObject.Footer = this.activityIndicator;
        }

        protected override void OnDetachingFrom(ListView list)
        {
            base.OnDetachingFrom(list);
            this.AssociatedObject.ItemAppearing -= OnItemAppearing;
			this.AssociatedObject.PropertyChanged -= this.OnAssociatedObjectPropertyChanged;
        }

        private void OnAssociatedObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(this.AssociatedObject.ItemsSource))
                return;

            var binding = new Binding(nameof(ILazyObservableCollection.IsBusy))
            {
                Source = this.AssociatedObject.ItemsSource
            };

            activityIndicator?.SetBinding(VisualElement.IsVisibleProperty, binding);

            var lazyObservableCollection = this.AssociatedObject.ItemsSource as ILazyObservableCollection;
            lazyObservableCollection?.LoadItemsAsync();
        }

        private void EnsureActivityIndicator()
        {
            if (this.activityIndicator != null)
                return;

            this.activityIndicator = new ActivityIndicator
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 20,
                IsRunning = true
            };
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var lazyObservableCollection = this.AssociatedObject.ItemsSource as ILazyObservableCollection;
            lazyObservableCollection?.LoadItemsAsync(e.Item);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var listView = (ListView)bindable;
            listView.ItemsSource = newvalue as IEnumerable;

            var activityIndicator = listView.Footer as ActivityIndicator;
            var binding = new Binding(nameof(ILazyObservableCollection.IsBusy))
            {
                Source = newvalue
            };

            activityIndicator?.SetBinding(VisualElement.IsVisibleProperty, binding);

            var lazyObservableCollection = newvalue as ILazyObservableCollection;
            lazyObservableCollection?.LoadItemsAsync();
        }
    }
}