using SOFT262.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SOFT262.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected MainModel model;
        readonly IPageHelper pageHelper;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(IPageHelper p)
        {
            pageHelper = p;
            model = MainModel.Instance;
            model.OnUpdate += RefreshUI;
        }

        //Called whenever data in the model is changed
        //All UI that displays data stored in the model is refreshed
        protected abstract void RefreshUI();

        //Called from within the viewmodel when a property changes
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
