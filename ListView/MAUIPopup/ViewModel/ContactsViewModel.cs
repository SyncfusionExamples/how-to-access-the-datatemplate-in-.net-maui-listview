using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.XPath;

namespace MAUIPopup
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Contacts> Items { get; set; }

        #endregion

        #region Fields

        Random random = new Random(123456789);

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            Items = new ObservableCollection<Contacts>();

            for (int i = 0; i < CustomerNames.Count(); i++)
            {
                var contact = new Contacts(CustomerNames[i], random.Next(720, 799).ToString() + " - " + random.Next(3010, 3999).ToString());
                contact.ContactImage = ImageSource.FromResource("ListViewXamarin.Images.Image" + random.Next(0, 28) + ".png", typeof(MainPage));
                Items.Add(contact);
            }
        }

        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
        };

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
