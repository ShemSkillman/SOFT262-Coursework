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
        ObservableCollection<RevisionGroup> revisionGroups;

        public ManageViewModel(IPageHelper p) : base(p)
        {

        }

        public ObservableCollection<RevisionGroup> RevisionGroups
        {
            get => revisionGroups;
            set
            {
                if (value == revisionGroups) return;
                revisionGroups = value;
            }
        }
    }

    public class RevisionGroup
    {
        public string Topic { get; set; }
        public int CardCount { get; set; }

        public RevisionGroup(string topic, int cardCount) => (Topic, CardCount) = (topic, cardCount);
    }
}
