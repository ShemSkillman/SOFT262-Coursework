using SOFT262.Creation;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace SOFT262.Model
{
    public class MainModel
    {
        private static MainModel instance;

        const string fileName = "RevisionCards1.db3";
        string dbPath => System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        SQLiteConnection conn; 
        TableMapping cardsMapping, topicsMapping;

        public static MainModel Instance { get
            {
                if (instance != null) return instance;

                return instance = new MainModel();
            }
        }

        public MainModel()
        {
            conn = new SQLiteConnection(dbPath); 

            conn.CreateTable<RevisionCardSQL>();
            conn.CreateTable<TopicSQL>();

            cardsMapping = conn.GetMapping(typeof(RevisionCardSQL));
            topicsMapping = conn.GetMapping(typeof(TopicSQL));
        }

        public List<string> TopicNames
        {
            get
            {
                List<string> topicNames = new List<string>();
                foreach(var topic in conn.Table<TopicSQL>().ToList())
                {
                    topicNames.Add(topic.Topic);
                }

                return topicNames;
            }
        }

        public void AddNewCard(string topicName, string question, string answer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(topicName) || string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                {
                    throw new Exception("Topic, Question or Answer not filled in correctly!");
                }

                conn.Insert(new RevisionCardSQL { Topic = topicName, Question = question, Answer = answer });

                var topicObj = AddNewTopic(topicName);
                topicObj.CardCount++;
                conn.Update(topicObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TopicSQL AddNewTopic(string topicName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(topicName))
                {
                    throw new Exception("Topic not filled in correctly!");
                }

                var topic = conn.Find(topicName, topicsMapping) as TopicSQL;
                if (topic != null) return topic;

                topic = new TopicSQL { Topic = topicName };
                conn.Insert(topic);
                return topic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTopic(string topicName)
        {
            try
            {
                conn.Delete(topicName, topicsMapping);

                List<RevisionCardSQL> cardsToBeDeleted = new List<RevisionCardSQL>();

                var allRevisionCards = conn.Table<RevisionCardSQL>().ToList();
                foreach(var revisionCard in allRevisionCards)
                {
                    if (revisionCard.Topic.Equals(topicName))
                    {
                        conn.Delete(revisionCard);
                    }
                }                
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public void DeleteCard(RevisionCardSQL cardToRemove)
        {
            try
            {
                conn.Delete(cardToRemove);
                var topic = conn.Find(cardToRemove.Topic, topicsMapping) as TopicSQL;
                topic.CardCount--;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void ModifyCard(RevisionCardSQL revisionCard, string newTopic, 
            string newQuestion, string newAnswer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newTopic) || string.IsNullOrWhiteSpace(newQuestion) || string.IsNullOrWhiteSpace(newAnswer))
                {
                    throw new Exception("Topic, Question or Answer not filled in correctly!");
                }

                revisionCard.Topic = newTopic;
                revisionCard.Question = newQuestion;
                revisionCard.Answer = newAnswer;

                conn.Update(revisionCard);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
