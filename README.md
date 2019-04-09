# Xamarin.Forms.MultiSelectListView

 Select multiple rows in a listview with xamarin.forms.
 
 By default the listview control lets you only select one row at a time. The MultiSelectListView control uses a modified ObservableCollection to mark which rows have been selected.
 
 You can use any image to mark the selected row.
 
 ###### This is the component, works on iOS, Android and UWP.
 
![](https://raw.githubusercontent.com/TBertuzzi/Xamarin.Forms.MultiSelectListView/master/Resources/select.png)
 
**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|MultiSelectListView|[![NuGet](https://buildstats.info/nuget/Xamarin.Forms.MultiSelectListView)](https://www.nuget.org/packages/Xamarin.Forms.MultiSelectListView/)|
|Build status|[![Build status](https://ci.appveyor.com/api/projects/status/github/TBertuzzi/xamarin-forms-multiselectlistview?branch=master&svg=true)](https://ci.appveyor.com/project/ThiagoBertuzzi/xamarin-forms-multiselectlistview)|

**Build History**

[![Build history](https://buildstats.info/appveyor/chart/ThiagoBertuzzi/xamarin-forms-multiselectlistview?buildCount=33)](https://ci.appveyor.com/project/ThiagoBertuzzi/xamarin-forms-multiselectlistview/history)

**Platform Support**

MultiSelectListView is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms

## Setup / Usage

Basically the key is to use the MultiSelectObservableCollection instead of the conventional ObservableCollection.

```csharp

public MultiSelectObservableCollection<User> Users { get; }

```

The "IsSelected" property notifies when an object has been selected.

in the Xaml file we must declare our control xmlns: lv = "clr-namespace: Xamarin.Forms.MultiSelectListView; assembly = Xamarin.Forms.MultiSelectListView", for example . 

Then use the new MultiSelect.Enable property to enable the multiple selection in the listview.

we must use the SelectableCell that contains the property to inform the icon of the selection

```csharp

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MultiSelectListViewSample"
             x:Class="MultiSelectListViewSample.MainPage"
            xmlns:lv="clr-namespace:Xamarin.Forms.MultiSelectListView;assembly=Xamarin.Forms.MultiSelectListView" Padding="0,20,0,0">

    <StackLayout>
        <ListView x:Name="lvwUsers" 
            HasUnevenRows="true"
            SeparatorVisibility="Default" 
            ItemsSource="{Binding Users}"
                  lv:MultiSelect.Enable="true">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <lv:SelectableCell x:Name="SelectableCell">

                        <lv:SelectableCell.CheckView>
                            <Image Source="select.png" WidthRequest="30" HeightRequest="30"></Image>
                        </lv:SelectableCell.CheckView>

                        <lv:SelectableCell.DataView>
                            <StackLayout Orientation="Vertical" Padding="20,0,20,0">
                                <Label Text="{Binding Name}" FontSize="17" ></Label>
                            </StackLayout>
                        </lv:SelectableCell.DataView>

                    </lv:SelectableCell>

                </DataTemplate>
            </ListView.ItemTemplate>

        </ListView>
    </StackLayout>

</ContentPage>




```


SelectedItemBehavior to execute the command when the SelectedItem event occurs in ListView. Pass the item selected in ListView to Command. If ClearSelected property is true, SelectedItem property of ListView is cleared after command execution. Default ClearSelected property value is true.

You can use the object of the selected line

```csharp

  <ListView.Behaviors>
        <lv:SelectedItemBehavior Command="{Binding DisplayNameCommand}"/>
  </ListView.Behaviors>

```

Or specify the property you want to pass as a parameter

```csharp

  <ListView.Behaviors>
       <lv:SelectedItemBehavior Command="{Binding DisplayNameCommand}" PropertyName="Name"/
  </ListView.Behaviors>

```


The complete example can be downloaded here: https://github.com/TBertuzzi/Xamarin.Forms.MultiSelectListView/tree/master/MultiSelectListViewSample



