using SOFT262.Model;
using SOFT262.MVVM;
using SOFT262.TabbedPages.Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SOFT262.Manage
{
    public class ManageViewModel : ViewModelBase
    {
        int topicIndex = -1;
        public ManageViewModel(IPageHelper p) : base(p)
        {

        }

        public ObservableCollection<TopicSQL> AllTopics { get => model.AllTopics; }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(AllTopics));
        }

        public List<string> TopicNames
        {
            get
            {
                var topics = model.AllTopics;
                List<string> topicNames = new List<string>();
                foreach (var topic in topics)
                {
                    topicNames.Add(topic.TopicName);
                }

                topicNames.Insert(0, "New Topic");
                return topicNames;
            }
        }

        public int TopicIndex
        {
            get => topicIndex;
            set
            {
                if (topicIndex == value) return;

                topicIndex = value;
                OnPropertyChanged();
            }
        }
        //Event handler for the tapped event
        public async Task TopicModifyPage(TopicSQL topic)
        {
            ObservableCollection<RevisionCardSQL> revisionCards = model.GetRevisionCardsOfTopic(topic);
            ManageLoadedCardsPage topicPage = new ManageLoadedCardsPage();
            NavigationPage MainPage = new NavigationPage(topicPage);
            await MainPage.PushAsync(MainPage);
            //Create a new page based on the topicName being passed.
        }
    }
}
