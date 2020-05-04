using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;


namespace SOFT262.Model
{
    public class DataModel
    {
        const string fileName = "RevisionCards2.db3";
        string DbPath => System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);

        readonly SQLiteConnection conn;

        public Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>> RevisionGroups { get; set; }

        public DataModel()
        {
            conn = new SQLiteConnection(DbPath);
            Setup();
        }

        public DataModel(string filePath)
        {
            conn = new SQLiteConnection(filePath);
            Setup();
        }

        private void Setup()
        {
            conn.CreateTable<RevisionCardSQL>();
            conn.CreateTable<TopicSQL>();
            LoadData();
        }

        public void LoadData()
        {
            RevisionGroups = new Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>>();

            var topics = conn.Table<TopicSQL>().ToList();
            foreach (var topic in topics)
            {
                RevisionGroups[topic] = new ObservableCollection<RevisionCardSQL>();
            }

            var revisionCards = conn.Table<RevisionCardSQL>().ToList();
            foreach (var revisionCard in revisionCards)
            {
                TopicSQL topic = GetTopicByName(revisionCard.Topic);
                RevisionGroups[topic].Add(revisionCard);
            }
        }
        public TopicSQL GetTopicByName(string topicName)
        {
            foreach (var topic in RevisionGroups.Keys)
            {
                if (topic.TopicName.Equals(topicName)) return topic;
            }

            return null;
        }

        public void SaveTopic(TopicSQL topic)
        {
            if (RevisionGroups.ContainsKey(topic)) // Topic is present so must be updated
            {
                conn.Update(topic);
            }
            else // Topic not present so must be saved as new
            {
                RevisionGroups[topic] = new ObservableCollection<RevisionCardSQL>();
                conn.Insert(topic);
            }
        }

        public void SaveCard(RevisionCardSQL revisionCard)
        {
            var topic = GetTopicByName(revisionCard.Topic);
            if (RevisionGroups[topic].Contains(revisionCard)) // Revision card present so must be updated
            {
                conn.Update(revisionCard);
            }
            else // Revision card not present so must be saved as new
            {
                RevisionGroups[topic].Add(revisionCard);
                conn.Insert(revisionCard);

                topic.CardCount += 1;
                SaveTopic(topic); // Save topic card count increase
            }
        }

        public void SaveDeleteTopic(TopicSQL topic)
        {
            if (!RevisionGroups.ContainsKey(topic)) return;

            foreach (var revisionCard in RevisionGroups[topic])
            { 
                conn.Delete(revisionCard); //Delete all cards in topic
            }

            RevisionGroups[topic] = null;
            RevisionGroups.Remove(topic);

            conn.Delete(topic);
        }

        public void SaveDeleteCard(RevisionCardSQL revisionCard)
        {
            var topic = GetTopicByName(revisionCard.Topic);
            if (!RevisionGroups[topic].Contains(revisionCard)) return;

            RevisionGroups[topic].Remove(revisionCard);
            conn.Delete(revisionCard);

            topic.CardCount -= 1;
            SaveTopic(topic); //Save topic card count decrease
        }

        public void DeleteAll()
        {
            conn.DeleteAll(conn.GetMapping(typeof(TopicSQL)));
            conn.DeleteAll(conn.GetMapping(typeof(RevisionCardSQL)));
            RevisionGroups.Clear();
        }
    }
}
