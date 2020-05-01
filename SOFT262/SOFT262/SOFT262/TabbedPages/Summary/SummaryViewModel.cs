using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SOFT262.Model;
using SOFT262.MVVM;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SOFT262.Summary
{
    public class SummaryViewModel : ViewModelBase
    {
        int topicIndex = -1;
        private string selectedTopic;
        private string displayText;
        private int cardIndex = 0;

        public SummaryViewModel(IPageHelper p) : base(p)
        {
            TopicIndex = 0;
            FlipCardCommand = new Command(execute: () =>
            {
                if (displayText == RevisionCards[cardIndex].Question)
                {
                    DisplayText = RevisionCards[cardIndex].Answer;
                }
                else if (displayText == RevisionCards[cardIndex].Answer)
                {
                    DisplayText = RevisionCards[cardIndex].Question;
                }
                else
                {
                    DisplayText = RevisionCards[cardIndex].Question; //Default when null
                }
            });
            NextIndexCommand = new Command(execute: () =>
            {
                if ((cardIndex + 1) >= RevisionCards.Count)
                {
                    cardIndex = 0;
                    DisplayText = RevisionCards[cardIndex].Question;
                }
                else
                {
                    cardIndex = cardIndex + 1;
                    DisplayText = RevisionCards[cardIndex].Question;
                }
            });
            LastIndexCommand = new Command(execute: () =>
            {
                if ((cardIndex - 1) < 0)
                {
                    cardIndex = RevisionCards.Count - 1;
                    DisplayText = RevisionCards[cardIndex].Question;
                }
                else
                {
                    cardIndex = cardIndex - 1;
                    DisplayText = RevisionCards[cardIndex].Question;
                }
            });

        }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(TopicNames));
            OnPropertyChanged(nameof(RevisionCards));
        }

        public ObservableCollection<RevisionCardSQL> RevisionCards 
        { 
            get
            {
                if (selectedTopic == null) return null;

                TopicSQL topic = model.GetTopicByName(selectedTopic);
                return model.GetRevisionCardsOfTopic(topic);
            }

        }


        //Variables

        public ICommand FlipCardCommand { get; private set; }
        public ICommand NextIndexCommand { get; private set; }
        public ICommand LastIndexCommand { get; private set; }
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
                return topicNames;
            }
        }
        public string DisplayText
        {
            get => displayText;
            set
            {
                if (displayText == value) return;
                displayText = value;
                OnPropertyChanged();
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
        public string SelectedTopic
        {
            get => selectedTopic;
            set
            {
                if (selectedTopic == value) return;
                selectedTopic = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(RevisionCards));
            }
        }

    }
}
