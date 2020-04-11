using SOFT262.Model;
using SOFT262.TabbedPages.Creation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOFT262.Creation
{
    public class CreationViewModel : INotifyPropertyChanged
    {
        MainModel model;

        int topicIndex = -1;
        bool enableNewTopicNameInput = false;
        string topicName = "";
        string question = "";
        string answer = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public CreationViewModel(ICreationPageHelper p)
        {
            var creationHelper = p;
            model = MainModel.Instance;
            model.PropertyChanged += OnPropertyChanged;

            TopicIndex = 0;

            CreateCard = new Command(execute: async () =>
            {
                
                string topic;
                if (TopicIndex != 0) topic = Topics[TopicIndex];
                else topic = TopicName;
                model.CreateCardInSQL(topic, question, answer);
                TopicName = "";
                Question = "";
                Answer = "";
                TopicIndex = Topics.IndexOf(topic);
                await creationHelper.MessagePopup("Card created", "Revision card has been created and added to topic " + topic);

            });
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int TopicIndex
        {
            get => topicIndex;
            set
            {
                if (topicIndex == value) return;

                topicIndex = value;
                OnPropertyChanged();

                if (topicIndex == 0) EnableNewTopicNameInput = true;
                else EnableNewTopicNameInput = false;
            }
        }

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

        public List<string> Topics
        {
            get
            {
                List<string> topics = model.Topics;
                topics.Insert(0, "New Topic");
                return topics;
            }
            set
            {
                Topics = value;
            }
        }

        public ICommand CreateCard { get; private set; }

    }
}
