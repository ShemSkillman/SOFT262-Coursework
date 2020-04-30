using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SOFT262.Model;
using SOFT262.MVVM;

namespace SOFT262.TabbedPages.Manage
{
    class ManageLoadedCardsVM : ViewModelBase
    {

        public ManageLoadedCardsVM(IPageHelper p, TopicSQL topic) : base(p)
        {
            RevisionCards = model.GetRevisionCardsOfTopic(topic);
        }

        protected override void RefreshUI()
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<RevisionCardSQL> RevisionCards { get; set; }
    }
}
