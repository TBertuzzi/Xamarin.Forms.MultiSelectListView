using System;
using System.Reflection;
using System.Windows.Input;

namespace Xamarin.Forms.MultiSelectListView
{
    public class SelectedItemBehavior : InheritBindingBehavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SelectedItemBehavior));

        public static readonly BindableProperty ClearSelectedProperty =
            BindableProperty.Create(nameof(Command), typeof(bool), typeof(SelectedItemBehavior), true);

        public static readonly BindableProperty PropertyPathProperty =
            BindableProperty.Create(nameof(PropertyPath), typeof(string), typeof(SelectedItemBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public bool ClearSelected
        {
            get => (bool)GetValue(ClearSelectedProperty);
            set => SetValue(ClearSelectedProperty, value);
        }

        public string PropertyPath
        {
            get => (string)GetValue(PropertyPathProperty);
            set => SetValue(PropertyPathProperty, value);
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += OnItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= OnItemSelected;
            base.OnDetachingFrom(bindable);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command == null || e.SelectedItem == null)
                return;

            object parameter;
            if (PropertyPath != null)
            {
                var propertyNames = PropertyPath.Split('.');
                object propertyValue = e.SelectedItem;
                foreach (var propertyName in propertyNames)
                {
                    var propInfo = propertyValue.GetType().GetTypeInfo().GetDeclaredProperty(propertyName);
                    propertyValue = propInfo.GetValue(propertyValue);
                    if (propertyValue == null)
                    {
                        break;
                    }
                }
                parameter = propertyValue;
            }
            else
            {
                parameter = e.SelectedItem;
            }

            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }

            if (ClearSelected)
            {
                AssociatedObject.SelectedItem = null;
            }
        }
    }
}
