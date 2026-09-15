# How to access a named ListView inside a XAML DataTemplate in .NET MAUI (SfListView)?

The [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listView) enables access to a named ListView defined inside the DataTemplate of a [Popup](https://help.syncfusion.com/maui/popup/getting-started) by using a Behavior.

**XAML:**

In SfPopup.ContentTemplate, add behavior to the parent of the ListView.

```
    <StackLayout>
        <Button x:Name="clickToShowPopup"
            Text="ClickToShowPopup"
            VerticalOptions="Start"
            HorizontalOptions="Center"/>
        <popup:SfPopup x:Name="popup" WidthRequest="350" HeightRequest="350" ShowFooter="False" ShowHeader="False">
            <popup:SfPopup.BindingContext>
                <local:ContactsViewModel/>
            </popup:SfPopup.BindingContext>
            <popup:SfPopup.ContentTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.Behaviors>
                            <local:GridBehavior/>
                        </Grid.Behaviors>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="50"/>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>

                        <Button Text="Find ListView" Grid.Row="0" x:Name="listviewButton"/>
                        <sfListView:SfListView    x:Name="listView"  ItemSpacing="5" 
                                                    ItemsSource="{Binding Items}" 
                                                    SelectionMode="Single" Grid.Row="1">
                            <sfListView:SfListView.ItemTemplate>
                                <DataTemplate>
                                    <Grid x:Name="grid" RowSpacing="1">
                                       ...
                                    </Grid>
                                </DataTemplate>
                            </sfListView:SfListView.ItemTemplate>
                        </sfListView:SfListView>
                    </Grid>
                </DataTemplate>
            </popup:SfPopup.ContentTemplate>
        </popup:SfPopup>
    </StackLayout>
```

**C#**

In the ChildAdded event, you can get the instance of ListView.
 
 ```
 public class GridBehavior : Behavior<Grid>
{
    Grid grid;
    SfListView listView;
    protected override void OnAttachedTo(BindableObject bindable)
    {
       grid = bindable as Grid;
        grid.ChildAdded += Grid_ChildAdded;
    }
    //Method 1 : Get SfListView reference using Grid.ChildAdded Event
    private void Grid_ChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is SfListView)
        {
            listView = e.Element as SfListView;
            listView.RefreshView();
        }
    }
    protected override void OnDetachingFrom(BindableObject bindable)
    {
        grid.ChildAdded -= Grid_ChildAdded;
        listView = null;
        grid = null;
        base.OnDetachingFrom(bindable);
    }
}
 ```

**C#**

Alternatively, you can use the [FindByName](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.element.findbyname?view=net-maui-8.0) method to get the ListView from the Parent element.
 
 ```
 public class GridBehavior : Behavior<Grid>
{
    Grid grid;
    SfListView listView;
    Button button;
    protected override void OnAttachedTo(BindableObject bindable)
    {
        grid = bindable as Grid;
        grid.ChildAdded += Grid_ChildAdded;
    }
    private void Grid_ChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is Button)
        {
            button = e.Element as Button;
            button.Clicked += Button_Clicked;
        }
    }
    //Method 2 : Get SfListView reference using FindByName
    private void Button_Clicked(object sender, EventArgs e)
    {
        listView = grid.FindByName<SfListView>("listView");
        App.Current.MainPage.DisplayAlert("Information", "ListView instance obtained", "Ok");
        listView.ItemTapped += ListView_ItemTapped;
    }
 
    private void ListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Information", "ListView ItemTapped", "Ok");
    }
 
    protected override void OnDetachingFrom(BindableObject bindable)
    {
        button.Clicked -= Button_Clicked;
        grid.ChildAdded -= Grid_ChildAdded;
        listView.ItemTapped -= ListView_ItemTapped;
        listView = null;
        button = null;
        grid = null;
        base.OnDetachingFrom(bindable);
    }
}
 ```

Download the complete sample from [GitHub](https://github.com/SyncfusionExamples/how-to-access-the-datatemplate-in-.net-maui-listview).

**Conclusion:**

I hope you enjoyed learning how to access a named ListView inside a XAML DataTemplate in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listView) feature tour page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications. 

Check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
