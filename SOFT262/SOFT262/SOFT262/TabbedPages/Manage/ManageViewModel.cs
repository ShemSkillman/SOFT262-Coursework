using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SOFT262.Manage
{
    public class ManageViewModel : ViewModelBase
    {
        ObservableCollection<TopicSQL> topics;

        public ManageViewModel(IPageHelper p) : base(p)
        {

        }

        public ObservableCollection<TopicSQL> Topics
        {
            get => topics;
            set
            {
                if (value == topics) return;
                topics = value;
            }
        }
    }
}
