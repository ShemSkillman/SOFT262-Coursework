﻿using SOFT262.Model;
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

        //Only true when creating a new topic
        bool enableNewTopicNameInput = false;

        //Fields that take user input
        string topicName = "";
        string question = "";
        string answer = "";

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateCard { get; private set; }

        public CreationViewModel(ICreationPageHelper p)
        {
            var creationHelper = p;
            model = MainModel.Instance;
            model.PropertyChanged += OnPropertyChanged;

            TopicIndex = 0;

            //Set execute code when calling the create card command
            //Resets input fields and creates card in model
            CreateCard = new Command(execute: async () =>
            {                
                string topic;
                if (TopicIndex != 0) topic = Topics[TopicIndex]; //Add to existing topic
                else topic = TopicName; //Add to new topic

                model.CreateCard(topic, question, answer);

                //Clear fields
                TopicName = "";
                Question = "";
                Answer = "";

                //Ensures that last selected topic remains selected
                TopicIndex = Topics.IndexOf(topic);

                await creationHelper.MessagePopup("Card created", "Revision card has been created and added to topic " + topic);
            });
        }

        //Called when property changes in the model
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        //Called from within the viewmodel when a property changes
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
    }
}
