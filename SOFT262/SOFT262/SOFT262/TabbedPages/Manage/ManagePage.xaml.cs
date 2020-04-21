using SOFT262.MVVM;
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
        public ManagePage()
        {
            InitializeComponent();

            BindingContext = new ManageViewModel(this);
        }

        public Task MessagePopup(string messageTitle, string message)
        {
            throw new NotImplementedException();
        }
    }
}