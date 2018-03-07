using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Forms.MultiSelectListView
{
    public class MultiSelectListView
    {

        public static readonly BindableProperty MultiSelectProperty =
             BindableProperty.CreateAttached("IsMultiSelect", typeof(bool), typeof(ListView), false, propertyChanged: OnMultiSelectChanged);

        public static bool GetIsMultiSelect(BindableObject view) => (bool)view.GetValue(MultiSelectProperty);

        public static void SetIsMultiSelect(BindableObject view, bool value) => view.SetValue(MultiSelectProperty, value);

        private static void OnMultiSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var listView = bindable as ListView;
            if (listView != null)
            {
                // Remove event
                listView.ItemSelected -= OnItemSelected;

                // Add new event to Multiple Select
                if (true.Equals(newValue)) 
                {
                    listView.ItemSelected += OnItemSelected;
                }
            }
        }

        private static void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as SelectableItem;
            if (item != null)
            {
                // toggle the selection property
                item.IsSelected = !item.IsSelected;
            }

            // deselect the item
            ((ListView)sender).SelectedItem = null;
        }


    }
}
