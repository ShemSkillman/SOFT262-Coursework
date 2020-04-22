using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SOFT262.Model;
using SOFT262.MVVM;

namespace SOFT262.Summary
{
    public class SummaryViewModel : ViewModelBase
    {
        public SummaryViewModel(IPageHelper p) : base(p)
        {
        }

        protected override void RefreshUI()
        {
        }
    }
}
