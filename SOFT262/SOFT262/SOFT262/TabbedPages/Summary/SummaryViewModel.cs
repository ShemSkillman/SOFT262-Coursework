﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using SOFT262.Model;
using SOFT262.MVVM;
using System.Collections.ObjectModel;

namespace SOFT262.Summary
{
    public class SummaryViewModel : ViewModelBase
    {

        int topicIndex = -1;
        private string selectedTopic;
        public SummaryViewModel(IPageHelper p) : base(p)
        {
        }

        protected override void RefreshUI()
        {
        }

        private ObservableCollection<RevisionCardSQL> revisionCards { get; set; }




        //Variables


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
            }
        }
        public void TopicChosen()
        {
            TopicSQL theTopic = model.GetTopicByName(selectedTopic);
            revisionCards = model.GetRevisionCardsOfTopic(theTopic);
            OnPropertyChanged();
        }

    }
}
