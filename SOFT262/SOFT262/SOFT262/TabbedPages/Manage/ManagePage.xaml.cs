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
    public partial class ManagePage : ContentPage
    {
        public ManagePage(ManageViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}