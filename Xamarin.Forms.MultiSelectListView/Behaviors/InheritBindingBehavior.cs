using System;
namespace Xamarin.Forms.MultiSelectListView
{
    public class InheritBindingBehavior<T> : Behavior<T> where T : BindableObject
    {
        private bool _inheritedBindingContedt;

        protected T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject = bindable;
            InheritBindingContext(bindable);

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            InheritBindingContext(AssociatedObject);
        }

        private void InheritBindingContext(T bindableObject)
        {
            if (BindingContext == null || _inheritedBindingContedt)
            {
                BindingContext = bindableObject.BindingContext;
                _inheritedBindingContedt = true;
            }
        }

        protected override void OnDetachingFrom(T bindable)
        {
            BindingContext = null;
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }
    }
}
