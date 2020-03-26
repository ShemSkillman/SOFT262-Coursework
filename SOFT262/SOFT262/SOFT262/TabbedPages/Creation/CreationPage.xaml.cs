﻿using SOFT262.Model;
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
    public partial class CreationPage : ContentPage
    {
        public CreationPage(CreationViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}