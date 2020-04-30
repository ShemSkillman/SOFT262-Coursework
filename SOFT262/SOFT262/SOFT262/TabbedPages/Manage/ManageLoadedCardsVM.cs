using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using SOFT262.Model;
using SOFT262.MVVM;
using Xamarin.Forms;

namespace SOFT262.TabbedPages.Manage
{
    class ManageLoadedCardsVM : ViewModelBase
    {
        public ICommand CancelCommand { get; set; }

        private bool isVisible;
        public bool IsVisible
        {
            get => selectedRevisionCard != null;
            set
            {
                if (isVisible == value) return;

                isVisible = value;
            }
        }

        private RevisionCardSQL selectedRevisionCard;
        public RevisionCardSQL SelectedRevisionCard
        {
            get => SelectedRevisionCard;
            set
            {
                if (selectedRevisionCard == value) return;

                selectedRevisionCard = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public ManageLoadedCardsVM(IPageHelper p, TopicSQL topic) : base(p)
        {
            RevisionCards = model.GetRevisionCardsOfTopic(topic);

            CancelCommand = new Command(execute: () => SelectedRevisionCard = null);
        }

        protected override void RefreshUI()
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<RevisionCardSQL> RevisionCards { get; set; }
    }
}
