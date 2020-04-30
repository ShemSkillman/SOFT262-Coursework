using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ManageLoadedCardsPage(TopicSQL topic)
        {
            InitializeComponent();
            vm = new ManageLoadedCardsVM(this, topic);
            BindingContext = vm;
        }

        public Task MessagePopup(string messageTitle, string message)
        {
            throw new NotImplementedException();
        }
    }
}