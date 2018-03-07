using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Forms.MultiSelectListView
{
    public class MultiSelect
    {

        public static readonly BindableProperty EnableProperty =
             BindableProperty.CreateAttached("Enable", typeof(bool), typeof(ListView), false, propertyChanged: OnMultiSelectChanged);

        public static bool GetIsMultiSelect(BindableObject view) => (bool)view.GetValue(EnableProperty);

        public static void SetIsMultiSelect(BindableObject view, bool value) => view.SetValue(EnableProperty, value);

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
