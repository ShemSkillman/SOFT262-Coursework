using SOFT262.Model;
using SOFT262.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOFT262.TabbedPages.Manage
{
    class ManageModifyCardViewModel : ViewModelBase
    {
        int topicIndex = -1;

        //Only true when creating a new topic
        bool enableNewTopicNameInput = false;

        //Fields that take user input
        string topicName = "";
        string question = "";
        string answer = "";

        public ICommand SaveChangesCommand { get; private set; }

        public ManageModifyCardViewModel(IPageHelper p, RevisionCardSQL revisionCard) : base(p)
        {
            TopicIndex = 0;

            int originalTopicIndex = TopicNames.IndexOf(revisionCard.Topic);
            TopicIndex = originalTopicIndex;
            Question = revisionCard.Question;
            Answer = revisionCard.Answer;
            
            SaveChangesCommand = new Command(execute: async () =>
            {
                try
                {
                    string topic;
                    if (TopicIndex != 0) topic = TopicNames[TopicIndex]; //Change to existing topic
                    else topic = TopicName; //Change to new topic

                    model.ModifyCard(revisionCard, topic, question, answer);

                    //Ensures that last selected topic remains selected
                    TopicIndex = TopicNames.IndexOf(topic);

                    await p.MessagePopup("Saved changes", "Changes to revision card have been saved.");
                }
                catch (Exception ex)
                {
                    await p.MessagePopup("Error occurred", "Error: " + ex.Message);
                }
            });
        }

        protected override void RefreshUI()
        {
            OnPropertyChanged(nameof(TopicNames));
        }    

        public int TopicIndex
        {
            get => topicIndex;
            set
            {
                if (topicIndex == value) return;

                topicIndex = value;
                OnPropertyChanged();

                //First topic is always 'new topic' 
                if (topicIndex == 0) EnableNewTopicNameInput = true;
                else EnableNewTopicNameInput = false;
            }
        }

        //Enables field that takes the name of the new topic
        public bool EnableNewTopicNameInput
        {
            get => enableNewTopicNameInput;
            set
            {
                if (enableNewTopicNameInput == value) return;

                enableNewTopicNameInput = value;
                OnPropertyChanged();
            }
        }

        public string Question
        {
            get => question;
            set
            {
                if (question.Equals(value)) return;

                question = value;
                OnPropertyChanged();
            }
        }
        public string Answer
        {
            get => answer;
            set
            {
                if (answer.Equals(value)) return;

                answer = value;
                OnPropertyChanged();
            }
        }
        public string TopicName
        {
            get => topicName;
            set
            {
                if (topicName.Equals(value)) return;

                topicName = value;
                OnPropertyChanged();
            }
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
    }
}
