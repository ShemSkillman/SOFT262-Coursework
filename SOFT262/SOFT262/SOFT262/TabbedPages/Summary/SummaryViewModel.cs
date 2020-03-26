using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SOFT262.Model;

namespace SOFT262.Summary
{
    public class SummaryViewModel : INotifyPropertyChanged
    {
        private MainModel model;

        public event PropertyChangedEventHandler PropertyChanged;        

        public SummaryViewModel(MainModel model)
        {
            this.model = model;
        }
    }
}
