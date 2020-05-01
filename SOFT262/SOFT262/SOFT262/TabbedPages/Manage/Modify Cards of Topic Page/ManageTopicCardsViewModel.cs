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
    class ManageTopicCardsViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ModifyCardCommand { get; private set; }

        TopicSQL selectedTopic;

        public string ChosenTopic { get => selectedTopic.TopicName; }

        public bool IsOptionsVisible
        {
            get => selectedRevisionCard != null;
        }

        public bool IsNoCardsNoticeVisible
        {
            get => RevisionCards.Count < 1;
        }

        private RevisionCardSQL selectedRevisionCard;
        public RevisionCardSQL SelectedRevisionCard
        {
            get => selectedRevisionCard;
            set
            {
                if (selectedRevisionCard == value) return;

                selectedRevisionCard = value;

                OnPropertyChanged(nameof(IsOptionsVisible));
                OnPropertyChanged();
            }
        }

        public ManageTopicCardsViewModel(IPageHelper p, TopicSQL topic) : base(p)
        {
            selectedTopic = topic;

            CancelCommand = new Command(execute: () => SelectedRevisionCard = null);

            DeleteCommand = new Command(execute: () =>
            {
                model.DeleteCard(SelectedRevisionCard);
            });

            ModifyCardCommand = new Command(execute: () =>
            {
                CardModifyPage(selectedRevisionCard);
            });
        }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(RevisionCards));
            OnPropertyChanged(nameof(IsNoCardsNoticeVisible));
            SelectedRevisionCard = null; //Reset selection
        }


        public ObservableCollection<RevisionCardSQL> RevisionCards
        {
            get => model.GetRevisionCardsOfTopic(selectedTopic);
        }

        public void CardModifyPage(RevisionCardSQL card)
        {
            //Pass topic through to the next page, to get the cards in VM
            ManageModifyCardPage modifyCardPage = new ManageModifyCardPage(card);
            _ = Navigation.PushAsync(modifyCardPage);

        }
    }
}
