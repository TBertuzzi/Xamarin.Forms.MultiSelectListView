# Xamarin.Forms.MultiSelectListView

 Select multiple rows in a listview with xamarin.forms.
 
 By default the listview control lets you only select one row at a time. The MultiSelectListView control uses a modified ObservableCollection to mark which rows have been selected.
 
**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|MultiSelectListView|[![NuGet](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/Xamarin.Forms.MultiSelectListView/)|

**Platform Support**

MultiSelectListView is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms

## Setup / Usage

Basically the key is to use the MultiSelectObservableCollection instead of the conventional ObservableCollection.

```csharp

public MultiSelectObservableCollection<User> Users { get; }

```

The "IsSelected" property notifies when an object has been selected.

in the Xaml file we must declare our control xmlns: lv = "clr-namespace: Xamarin.Forms.MultiSelectListView; assembly = Xamarin.Forms.MultiSelectListView", for example . 

Then use the new MultiSelect ListView.MultiSelect property to enable the multiple selection in the listview.

we must use the Selectable ViewCell that contains the property to inform the icon of the selection

```csharp

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MultiSelectListViewSample"
             x:Class="MultiSelectListViewSample.MainPage"
            xmlns:lv="clr-namespace:Xamarin.Forms.MultiSelectListView;assembly=Xamarin.Forms.MultiSelectListView" Padding="0,20,0,0">

    <StackLayout>
        <ListView x:Name="lvwDiretoria" 
            HasUnevenRows="true"
            SeparatorVisibility="Default" 
            ItemsSource="{Binding Users}"
                  lv:MultiSelectListView.MultiSelect="true">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <lv:SelectableViewCell x:Name="SelectableCell">

                        <lv:SelectableViewCell.CheckView>
                            <Image Source="select.png" WidthRequest="30" HeightRequest="30"></Image>
                        </lv:SelectableViewCell.CheckView>

                        <lv:SelectableViewCell.DataView>
                            <StackLayout Orientation="Vertical" Padding="20,0,20,0">
                                <Label Text="{Binding Name}" FontSize="17" ></Label>
                            </StackLayout>
                        </lv:SelectableViewCell.DataView>

                    </lv:SelectableViewCell>

                </DataTemplate>
            </ListView.ItemTemplate>

        </ListView>
    </StackLayout>

</ContentPage>



```


The complete example can be downloaded here: https://github.com/TBertuzzi/Xamarin.Forms.MultiSelectListView/tree/master/MultiSelectListViewSample



