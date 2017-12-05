using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mal.XF.Infra.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> list, IEnumerable<T> items)
        {
            foreach (var item in items)
                list.Add(item);
        }

        public static void Override<T>(this ObservableCollection<T> list, IEnumerable<T> items)
        {
            list.Clear();
            list.AddRange(items);
        }
    }
}
