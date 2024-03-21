using Syncfusion.Maui.Core;
using Syncfusion.Maui.Popup;
using System.ComponentModel;
using System.Reflection;

namespace MAUIPopup;

public partial class MainPage : ContentPage
{
	public MainPage()
    {
        InitializeComponent();
		this.BindingContext = new ContactsViewModel();
    }

    private void ClickToShowPopup_Clicked(object sender, EventArgs e)
	{
		popup.Show();

		// Shows SfPopupLayout at the center.
		//popupLayout.Show();

		// Shows SfPopupLayout at the specified X and y position.
		//popupLayout.Show(100, 100);

		// Shows SfPopupLayout at the position relative to the specified view.
		//popupLayout.ShowRelativeToView(label, RelativePosition.AlignBottom);
	}
}

