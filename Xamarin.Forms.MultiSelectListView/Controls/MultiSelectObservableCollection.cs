using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Xamarin.Forms.MultiSelectListView
{
    public class MultiSelectObservableCollection<T> : ObservableCollection<SelectableItem<T>>
    {
        public MultiSelectObservableCollection()
            : base()
        {
        }

        public MultiSelectObservableCollection(IEnumerable<T> collection)
            : base(collection.Select(c => new SelectableItem<T>(c)))
        {
        }

        public MultiSelectObservableCollection(IEnumerable<SelectableItem<T>> collection)
            : base(collection)
        {
        }

        public IEnumerable<T> SelectedItems => Items.Where(i => i.IsSelected).Select(i => i.Data);

        public IEnumerable<T> UnselectedItems => Items.Where(i => !i.IsSelected).Select(i => i.Data);

        public void Add(T item, bool selected = false)
        {
            Add(new SelectableItem<T>(item, selected));
        }

        public void Insert(int index, T item, bool selected = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Insert(index, new SelectableItem<T>(item, selected));
        }

        public bool IsSelected(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var idx = IndexOf(item);
            return idx != -1 && Items[idx].IsSelected;
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            for (var i = 0; i < Count; i++)
            {
                if (item.Equals(Items[i].Data))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var i = IndexOf(item);
            if (i != -1)
            {
                RemoveAt(i);
                return true;
            }
            return false;
        }
    }
}
