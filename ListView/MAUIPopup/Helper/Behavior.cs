using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;
using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIPopup
{
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
        //Method 1 : Get SfListView reference using Grid.ChildAdded Event
        private void Grid_ChildAdded(object sender, ElementEventArgs e)
        {
            if (e.Element is SfListView)
            {
                listView = e.Element as SfListView;
              
            }
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
            var container = listView.GetVisualContainer();
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

    public class ContentPageBehavior : Behavior<ContentPage>
    {
        ContentPage page;
        SfPopup popupLayout;
        Button button;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            page = bindable;
            popupLayout = bindable.FindByName<SfPopup>("popup");
            button = bindable.FindByName<Button>("clickToShowPopup");
            button.Clicked += Button_Clicked;
            base.OnAttachedTo(bindable);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            popupLayout.Show();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            button.Clicked -= Button_Clicked;
            base.OnDetachingFrom(bindable);
        }
    }
}
