using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Mal.XF.Infra.Layouts
{
    /// <summary>
    /// For repeated content without a automatic scroll view. Supports DataTemplates, Horizontal and Vertical layouts !
    /// </summary>
    /// <remarks>
    /// Warning TODO NO Visualization or Paging! Handle this in your view model.
    /// </remarks>
    public class ItemsStackLayout : StackLayout
    {
        #region Bindable
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<ItemsStackLayout, IEnumerable>(p => p.ItemsSource, default(IEnumerable<object>), BindingMode.TwoWay, null, ItemsSourceChanged);
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create<ItemsStackLayout, DataTemplate>(p => p.ItemTemplate, default(DataTemplate));

        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void ItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var itemsLayout = (ItemsStackLayout)bindable;
            itemsLayout.SetItems();
        }

        #endregion

        #region item rendering

        protected virtual void SetItems()
        {
            Children.Clear();

            if (ItemsSource == null)
            {
                ObservableSource = null;
                return;
            }

            foreach (var item in ItemsSource)
                Children.Add(GetItemView(item));

            if (this.IsObservableItemSource)
                this.ObservableSource = new ObservableCollection<object>(ItemsSource.Cast<object>());
        }

        private bool IsObservableItemSource => this.ItemsSource.GetType().GetTypeInfo().IsGenericType
                                              && this.ItemsSource.GetType().GetGenericTypeDefinition() == typeof(ObservableCollection<>);

        protected virtual View GetItemView(object item)
        {
            var content = this.GetItemTemplate();

            var view = content as View;
            if (view == null)
                return null;

            view.BindingContext = item;

            return view;
        }

        private View GetItemTemplate()
        {
            if (this.ItemTemplate != null)
                return this.ItemTemplate.CreateContent() as View;

            return new ContentView();
        }

        private ObservableCollection<object> observableSource;

        protected ObservableCollection<object> ObservableSource
        {
            get { return observableSource; }
            set
            {
                if (observableSource != null)
                    observableSource.CollectionChanged -= CollectionChanged;

                observableSource = value;

                if (observableSource != null)
                    observableSource.CollectionChanged += CollectionChanged;
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        int index = e.NewStartingIndex;
                        foreach (var item in e.NewItems)
                            Children.Insert(index++, GetItemView(item));
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    {
                        var item = ObservableSource[e.OldStartingIndex];
                        Children.RemoveAt(e.OldStartingIndex);
                        Children.Insert(e.NewStartingIndex, GetItemView(item));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        Children.RemoveAt(e.OldStartingIndex);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {
                        Children.RemoveAt(e.OldStartingIndex);
                        Children.Insert(e.NewStartingIndex, GetItemView(ObservableSource[e.NewStartingIndex]));
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Children.Clear();
                    foreach (var item in ItemsSource)
                        Children.Add(GetItemView(item));
                    break;
            }
        }
        #endregion
    }
}
