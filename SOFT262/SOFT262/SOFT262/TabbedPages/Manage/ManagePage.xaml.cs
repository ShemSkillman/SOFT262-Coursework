using SOFT262.MVVM;
using SOFT262.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOFT262.Manage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePage : ContentPage, IPageHelper
    {
        private ManageViewModel vm;
        public ManagePage()
        {
            InitializeComponent();

            TopicsListView.ItemTapped += TopicsListView_ItemTapped;
            vm = new ManageViewModel(this);
            BindingContext = vm;
        }

        public async Task MessagePopup(string messageTitle, string message)
        {
            await DisplayAlert(messageTitle, message, "OK");
        }
        public void TopicsListView_ItemTapped (object sender, ItemTappedEventArgs e)
        {
            TopicSQL topic;
            topic = (TopicSQL)e.Item;
            vm.TopicModifyPage(topic);
        }


    }

}