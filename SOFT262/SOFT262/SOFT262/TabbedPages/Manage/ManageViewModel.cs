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
        protected INavigation Navigation => Application.Current.MainPage.Navigation;
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
        public void TopicModifyPage(TopicSQL topic)
        {
            ManageLoadedCardsPage topicPage = new ManageLoadedCardsPage(topic); //Pass topic through to the next page, to get the cards in VM
            //NavigationPage testPage = new NavigationPage(topicPage); //Creates a new navigation page
            _ = Navigation.PushAsync(topicPage);
            
        }
    }
}
