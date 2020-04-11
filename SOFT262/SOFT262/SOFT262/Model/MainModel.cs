using SOFT262.Creation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SOFT262.Model
{
    public class MainModel : INotifyPropertyChanged
    {
        private static MainModel instance;

        public static MainModel Instance { get
            {
                if (instance != null) return instance;

                return instance = new MainModel();
            }
        }

        Dictionary<string, List<RevisionCard>> revisionGroups;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainModel()
        {
            revisionGroups = new Dictionary<string, List<RevisionCard>>();
        }

        public void CreateRevisionGroup(string topic)
        {
            if (revisionGroups.ContainsKey(topic)) return;

            revisionGroups.Add(topic, new List<RevisionCard>());

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Topics)));
        }

        public List<string> Topics
        {
            get
            {
                var topicNames = new List<string>();

                foreach (var topicName in revisionGroups.Keys)
                {
                    topicNames.Add(topicName);
                }

                topicNames.Sort();
                return topicNames;
            }            
        }

        public void CreateCard(string topic, string question, string answer)
        {
            CreateRevisionGroup(topic);

            RevisionCard newCard = new RevisionCard(topic, question, answer);
            revisionGroups[topic].Add(newCard);
        }
        public List<RevisionCardSQL> RevisionCardsList
        {

            get
            {
                return RevisionCardsList;

            }
            set
            {
                App.revisionCards.GetAllCards();
            }
        }
        public List<string> GetTopicsList() //Script to return the list of unique topics
        {
            var debug = App.revisionCards.GetAllCards();
            List<string> topicList = new List<string>();
            for (int i = 0; i < debug.Count; i++)
            {
                string result = debug[i].Topic.ToString();
                if (!topicList.Contains(result)) //Searches if the result is NOT in the main method
                {
                    topicList.Add(result);
                }
            }
            return topicList;
        }
        public void CreateCardInSQL(string topic, string question, string answer)
        {
            App.revisionCards.AddNewCard(topic, question, answer);
        }
    }
}
