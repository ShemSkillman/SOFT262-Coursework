using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOFT262.TabbedPages.Manage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageModifyCardPage : ContentPage, IPageHelper
    {
        public ManageModifyCardPage(RevisionCardSQL revisionCard)
        {
            InitializeComponent();

            BindingContext = new ManageModifyCardViewModel(this, revisionCard);
        }

        public async Task MessagePopup(string messageTitle, string message)
        {
            await DisplayAlert(messageTitle, message, "OK");
        }
    }
}