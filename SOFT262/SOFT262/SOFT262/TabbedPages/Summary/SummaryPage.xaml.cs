using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOFT262.Summary
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryPage : ContentPage, IPageHelper
    {
        SummaryViewModel vm;
        
        public SummaryPage()
        {
            InitializeComponent();
            vm = new SummaryViewModel(this);
            BindingContext = vm;
        }

        public Task MessagePopup(string messageTitle, string message)
        {
            throw new NotImplementedException();
        }

        private void listTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            vm.TopicChosen();
        }
    }
}