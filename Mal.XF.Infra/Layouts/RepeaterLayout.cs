namespace Mal.XF.Infra.Layouts
{
    //public class RepeaterLayout : StackLayout
    //{
    //    #region Bindable

    //    public static readonly BindableProperty ItemsSourceProperty =
    //        BindableProperty.Create<RepeaterLayout, IEnumerable>(p => p.ItemsSource, default(IEnumerable<object>),
    //            BindingMode.TwoWay, null, ItemsSourceChanged);

    //    public static readonly BindableProperty ItemTemplateProperty =
    //        BindableProperty.Create<RepeaterLayout, DataTemplate>(p => p.ItemTemplate, default(DataTemplate));

    //    public IEnumerable ItemsSource
    //    {
    //        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
    //        set { SetValue(ItemsSourceProperty, value); }
    //    }

    //    public DataTemplate ItemTemplate
    //    {
    //        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
    //        set { SetValue(ItemTemplateProperty, value); }
    //    }

    //    private static void ItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
    //    {
    //        var itemsLayout = (RepeaterLayout)bindable;
    //        itemsLayout.SetItems();
    //    }

    //    #endregion

    //    #region item rendering

    //    private void SetItems()
    //    {
    //        Children.Clear();

    //        if (ItemsSource == null)
    //        {
    //            this.ObservableSource = null;
    //            return;
    //        }

    //        foreach (var item in ItemsSource)
    //            Children.Add(GetItemView(item));

    //        var isObs = ItemsSource.GetType().GetGenericTypeDefinition() == typeof(ObservableCollection<>);
    //        if (isObs)
    //        {
    //            this.ObservableSource = new ObservableCollection<object>(ItemsSource.Cast<object>());
    //        }
    //    }

    //    private View GetItemView(object item)
    //    {
    //        var content = ItemTemplate.CreateContent();

    //        var view = content as View;
    //        if (view == null)
    //            return null;

    //        view.BindingContext = item;

    //        return view;
    //    }

    //    private ObservableCollection<object> observableSource;

    //    private ObservableCollection<object> ObservableSource
    //    {
    //        get { return this.observableSource; }
    //        set
    //        {
    //            if (this.observableSource != null)
    //                observableSource.CollectionChanged -= this.CollectionChanged;

    //            this.observableSource = value;

    //            if (this.observableSource != null)
    //                this.observableSource.CollectionChanged += this.CollectionChanged;
    //        }
    //    }

    //    private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    //    {
    //        switch (e.Action)
    //        {
    //            case NotifyCollectionChangedAction.Add:
    //                {
    //                    int index = e.NewStartingIndex;
    //                    foreach (var item in e.NewItems)
    //                        Children.Insert(index++, GetItemView(item));
    //                }
    //                break;
    //            case NotifyCollectionChangedAction.Move:
    //                {
    //                    var item = ObservableSource[e.OldStartingIndex];
    //                    Children.RemoveAt(e.OldStartingIndex);
    //                    Children.Insert(e.NewStartingIndex, GetItemView(item));
    //                }
    //                break;
    //            case NotifyCollectionChangedAction.Remove:
    //                {
    //                    Children.RemoveAt(e.OldStartingIndex);
    //                }
    //                break;
    //            case NotifyCollectionChangedAction.Replace:
    //                {
    //                    Children.RemoveAt(e.OldStartingIndex);
    //                    Children.Insert(e.NewStartingIndex, GetItemView(ObservableSource[e.NewStartingIndex]));
    //                }
    //                break;
    //            case NotifyCollectionChangedAction.Reset:
    //                Children.Clear();
    //                foreach (var item in ItemsSource)
    //                    Children.Add(GetItemView(item));
    //                break;
    //        }
    //    }

    //    #endregion

    //    public RepeaterLayout()
    //    {

    //    }
    //}
}
