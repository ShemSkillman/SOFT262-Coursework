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
        public ICommand DeleteCommand { get; set; }

        private bool isVisible;

        TopicSQL selectedTopic;
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
            get => selectedRevisionCard;
            set
            {
                if (selectedRevisionCard == value) return;

                selectedRevisionCard = value;

                OnPropertyChanged(nameof(IsVisible));
                OnPropertyChanged();
            }
        }

        public ManageLoadedCardsVM(IPageHelper p, TopicSQL topic) : base(p)
        {
            selectedTopic = topic;

            CancelCommand = new Command(execute: () => SelectedRevisionCard = null);

            DeleteCommand = new Command(execute: () =>
            {
                model.DeleteCard(SelectedRevisionCard);
            });
        }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(RevisionCards));
        }


        public ObservableCollection<RevisionCardSQL> RevisionCards
        {
            get => model.GetRevisionCardsOfTopic(selectedTopic);
        }
    }
}
