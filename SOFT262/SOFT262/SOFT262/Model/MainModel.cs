using SOFT262.Creation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace SOFT262.Model
{
    public class MainModel
    {
        private static MainModel instance;
        private readonly DataModel dataModel;

        public static MainModel Instance { get
            {
                if (instance != null) return instance;

                return instance = new MainModel();
            }
        }

        public MainModel()
        {
            dataModel = new DataModel();

            AllTopics = new ObservableCollection<TopicSQL>(dataModel.RevisionGroups.Keys);
        }

        public delegate void DataUpdated();
        public event DataUpdated OnUpdate;

        public ObservableCollection<TopicSQL> AllTopics { get; private set; }

        public ObservableCollection<RevisionCardSQL> GetRevisionCardsOfTopic(TopicSQL topic)
        {
            dataModel.RevisionGroups.TryGetValue(topic, out ObservableCollection<RevisionCardSQL> cardsOfTopic);

            if (cardsOfTopic == null) cardsOfTopic = new ObservableCollection<RevisionCardSQL>(); //Topic with no cards
            return cardsOfTopic;
        }

        public TopicSQL GetTopicByName(string topicName)
        {
            return dataModel.GetTopicByName(topicName);
        }

        public void AddNewCard(string topicName, string question, string answer, bool isNewTopic)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(topicName) || string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                {
                    throw new Exception("Topic, Question or Answer not filled in correctly!");
                }

                var newRevisionCard = new RevisionCardSQL { Topic = topicName, Question = question, Answer = answer };

                var topic = GetTopicByName(topicName);

                //If topic is entered by user but topic of same name already exists
                //then throw error so that user can assign card to already existing topic
                if (topic != null && isNewTopic)
                {
                    throw new Exception("Topic of name " + topicName + " already exists!");
                }
                else if (topic == null) AddNewTopic(topicName);

                dataModel.SaveCard(newRevisionCard);

                OnUpdate?.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddNewTopic(string topicName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(topicName))
                {
                    throw new Exception("Topic not filled in correctly!");
                }

                var topic = GetTopicByName(topicName);
                if (topic != null)
                {
                    throw new Exception("Topic of name " + topicName + " already exists!");
                }
                
                topic = new TopicSQL { TopicName = topicName };
                dataModel.SaveTopic(topic);

                AllTopics.Add(topic); // Update all topics list
                OnUpdate?.Invoke();
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
                var topic = GetTopicByName(topicName);
                dataModel.SaveDeleteTopic(topic);

                AllTopics.Remove(topic); // Update all topics list
                OnUpdate?.Invoke();
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
                dataModel.SaveDeleteCard(cardToRemove);
                OnUpdate?.Invoke();
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

                dataModel.SaveDeleteCard(revisionCard);

                revisionCard.Topic = newTopic;
                revisionCard.Question = newQuestion;
                revisionCard.Answer = newAnswer;

                dataModel.SaveCard(revisionCard);

                OnUpdate?.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
