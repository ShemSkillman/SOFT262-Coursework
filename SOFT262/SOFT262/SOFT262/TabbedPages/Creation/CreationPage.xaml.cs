using SOFT262.Model;
using SOFT262.TabbedPages.Creation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOFT262.Creation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPage : ContentPage, ICreationPageHelper
    {
        public CreationPage()
        {
            InitializeComponent();

            BindingContext = new CreationViewModel(this);
        }
        //INavigation IPage.NavigationProxy { get => Navigation; }

        public async Task MessagePopup(string messageTitle, string message)
        {
            await DisplayAlert(messageTitle, message, "OK");
        }
    }
}