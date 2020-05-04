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

        public int CardIndex { get; set; } = 0;

        private Random rng = new Random();
        public SummaryViewModel(IPageHelper p) : base(p)
        {
            TopicIndex = 0;
            if (RevisionCards != null)
            {
                DisplayText = RevisionCards[0].Question;
            }
            else
            {
                DisplayText = "Create some revision cards!";
            }
            SetCommands();
        }

        private void SetCommands()
        {
            FlipCardCommand = new Command(execute: () =>
            {
                if (RevisionCards == null || RevisionCards.Count < 1)
                {
                    return;
                }
                if (displayText == RevisionCards[CardIndex].Question)
                {
                    DisplayText = RevisionCards[CardIndex].Answer;
                }
                else if (displayText == RevisionCards[CardIndex].Answer)
                {
                    DisplayText = RevisionCards[CardIndex].Question;
                }
                else
                {
                    DisplayText = RevisionCards[CardIndex].Question; //Default when null
                }
            });

            NextIndexCommand = new Command(execute: () =>
            {
                if ((CardIndex + 1) >= RevisionCards.Count)
                {
                    CardIndex = 0;
                    DisplayText = RevisionCards[CardIndex].Question;
                }
                else
                {
                    CardIndex = CardIndex + 1;
                    DisplayText = RevisionCards[CardIndex].Question;
                }
            });

            LastIndexCommand = new Command(execute: () =>
            {
                if ((CardIndex - 1) < 0)
                {
                    CardIndex = RevisionCards.Count - 1;
                    DisplayText = RevisionCards[CardIndex].Question;
                }
                else
                {
                    CardIndex = CardIndex - 1;
                    DisplayText = RevisionCards[CardIndex].Question;
                }
            });

            ShuffleCommand = new Command(execute: () =>
            {
                Shuffle(RevisionCards);
                CardIndex = 0;
                DisplayText = RevisionCards[CardIndex].Question;
            });
        }

        //Constructor used for testing which uses collection from testing
        public SummaryViewModel() { }


        //Shuffle code adapted from: https://stackoverflow.com/questions/273313/randomize-a-listt
        public void Shuffle(ObservableCollection<RevisionCardSQL> revisionCards)
        {
            int n = revisionCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = revisionCards[k];
                revisionCards[k] = revisionCards[n];
                revisionCards[n] = value;
            }

            OnPropertyChanged(nameof(RevisionCards));
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
        public ICommand ShuffleCommand { get; private set; }
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
