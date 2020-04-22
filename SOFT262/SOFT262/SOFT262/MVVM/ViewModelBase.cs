using SOFT262.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SOFT262.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected MainModel model;
        IPageHelper pageHelper;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(IPageHelper p)
        {
            pageHelper = p;
            model = MainModel.Instance;
            model.PropertyChanged += OnPropertyChanged;
        }

        //Called when property changes in the model
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        //Called from within the viewmodel when a property changes
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
