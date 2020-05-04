using SOFT262.Model;
using SOFT262.MVVM;
using SOFT262.TabbedPages.Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOFT262.Manage
{
    public class ManageViewModel : ViewModelBase
    {
        //Command variables
        public ICommand ViewCardsCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        //Constructor
        public ManageViewModel(IPageHelper p) : base(p)
        {
            CancelCommand = new Command(() => SelectedTopic = null);

            DeleteCommand = new Command(() =>
            {
                try
                {
                    model.DeleteTopic(SelectedTopic.TopicName);
                    SelectedTopic = null; //Reset Selection
                }
                catch(Exception ex)
                {
                    p.MessagePopup("Error occurred", ex.Message);
                }

            });

            ViewCardsCommand = new Command(() => TopicCardsModifyPage(SelectedTopic));
        }
        
        public ObservableCollection<TopicSQL> AllTopics { get => model.AllTopics; }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(AllTopics));
            OnPropertyChanged(nameof(IsNoTopicsNoticeVisible));
            OnPropertyChanged(nameof(IsOptionsVisible));
        }

        private TopicSQL selectedTopic;
        public TopicSQL SelectedTopic
        {
            get => selectedTopic;
            set
            {
                if (selectedTopic == value) return;

                selectedTopic = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsOptionsVisible));
            }
        }

        public bool IsOptionsVisible
        {
            get => selectedTopic != null; //Hide selected topic
        }

        public bool IsNoTopicsNoticeVisible
        {
            get => AllTopics.Count < 1;
        }

        
        //Event handler for the tapped event
        public void TopicCardsModifyPage(TopicSQL topic)
        {
            //Pass topic through to the next page, to get the cards in VM
            ManageLoadedCardsPage topicPage = new ManageLoadedCardsPage(topic); 
            _ = Navigation.PushAsync(topicPage);
            
        }
    }
}
