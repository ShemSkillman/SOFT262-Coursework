﻿using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace SOFT262.Manage
{
    public class ManageViewModel : ViewModelBase
    {

        public ManageViewModel(IPageHelper p) : base(p)
        {

        }

        public ObservableCollection<TopicSQL> AllTopics { get => model.AllTopics; }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(AllTopics));
        }
    }
}
