using System.Collections.Generic;
using System.Linq;

namespace Mal.XF.Infra.Extensions
{
    public static class ListExtensions
    {
        public static void Push<T>(this List<T> list, T item)
        {
            if (list.MoveToLast(item))
                return;

            list.Add(item);
        }

        public static T Pop<T>(this List<T> list)
        {
            var lastItem = list.Last();

            list.RemoveAt(list.Count - 1);

            return lastItem;
        }

        public static bool TryPop<T>(this List<T> list, out T item)
        {
            item = default(T);

            if (list.Count == 0)
                return false;

            item = list.Pop();
            return true;
        }

        public static bool Move<T>(this List<T> list, T item, int newIdex)
        {
            var oldIndex = list.FindIndex(i => i.Equals(item));
            if (oldIndex < 0)
                return false;

            list.RemoveAt(oldIndex);
            list.Insert(newIdex, item);

            return true;
        }

        public static bool MoveToLast<T>(this List<T> list, T item)
        {
            return list.Move(item, list.Count - 1);
        }
    }
}
