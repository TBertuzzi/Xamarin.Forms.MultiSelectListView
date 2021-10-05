using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MultiSelectListView
{
    [ContentProperty(nameof(DataView))]
    public class SelectableCell : ViewCell
    {
        public enum DirectionEnum
        {
            Right = 0,
            Left = 1
        }

        public static readonly BindableProperty DirectionProperty =
            BindableProperty.CreateAttached("Direction", typeof(DirectionEnum), typeof(SelectableCell), DirectionEnum.Right, BindingMode.TwoWay);


        public DirectionEnum Direction
        {
            get => (DirectionEnum)GetValue(DirectionProperty);
            set
            {
                SetValue(DirectionProperty, value);
            }
        }

        private Grid rootGrid;
        private View dataView;
        private View checkView;

        public SelectableCell()
        {
            var teste = this.Parent.Parent;

            rootGrid = new Grid
            {
                Padding = 12,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            View = rootGrid;

            var check = new BoxView
            {
                Color = Color.CornflowerBlue,
                WidthRequest = 12,
                HeightRequest = 12,
            };
            CheckView = check;

            var text = new Label();
            text.SetBinding(Label.TextProperty, ".");
            DataView = text;
        }

        public View CheckView
        {
            get { return checkView; }
            set
            {
                if (checkView == value || View != rootGrid)
                    return;

                OnPropertyChanging();

                if (checkView != null)
                {
                    checkView.RemoveBinding(VisualElement.IsVisibleProperty);
                    rootGrid.Children.Remove(checkView);
                }

                checkView = value;

                if (checkView != null)
                {
                    checkView.SetBinding(VisualElement.IsVisibleProperty, nameof(SelectableItem.IsSelected));

                    if (Direction == DirectionEnum.Right)
                        Grid.SetColumn(checkView, 1);
                    else
                        Grid.SetColumn(checkView, 0);

                    Grid.SetColumnSpan(checkView, 1);
                    Grid.SetRow(checkView, 0);
                    Grid.SetRowSpan(checkView, 1);
                    checkView.HorizontalOptions = LayoutOptions.End;
                    checkView.VerticalOptions = LayoutOptions.Center;
                    rootGrid.Children.Add(checkView);
                }

                OnPropertyChanged();
            }
        }

        public View DataView
        {
            get { return dataView; }
            set
            {
                if (dataView == value || View != rootGrid)
                    return;

                OnPropertyChanging();

                if (dataView != null)
                {
                    dataView.RemoveBinding(BindingContextProperty);
                    rootGrid.Children.Remove(dataView);
                }

                dataView = value;

                if (dataView != null)
                {
                    dataView.SetBinding(BindingContextProperty, nameof(SelectableItem.Data));
                    //  Grid.SetColumn(dataView, 0);

                    if (Direction == DirectionEnum.Right)
                        Grid.SetColumn(dataView, 0);
                    else
                        Grid.SetColumn(dataView, 1);

                    Grid.SetColumnSpan(dataView, 1);
                    Grid.SetRow(dataView, 0);
                    Grid.SetRowSpan(dataView, 1);
                    dataView.HorizontalOptions = LayoutOptions.StartAndExpand;
                    dataView.VerticalOptions = LayoutOptions.FillAndExpand;
                    rootGrid.Children.Add(dataView);
                }

                OnPropertyChanged();
            }
        }
    }
}
