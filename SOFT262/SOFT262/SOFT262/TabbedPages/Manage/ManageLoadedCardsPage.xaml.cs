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
    public partial class ManageLoadedCardsPage : ContentPage, IPageHelper
    {
        private ManageLoadedCardsVM vm;
        public ManageLoadedCardsPage()
        {
            InitializeComponent();
            vm = new ManageLoadedCardsVM(this);
            BindingContext = vm;
        }

        public Task MessagePopup(string messageTitle, string message)
        {
            throw new NotImplementedException();
        }
    }
}