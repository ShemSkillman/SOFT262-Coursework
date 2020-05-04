using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOFT262.Model;

namespace UnitTesting
{
    [TestClass]
    public class DataModelTest
    {
        string path;

        [TestInitialize]
        public void Setup()
        {
            string fileName = "test.db3";
            string saveLocation = @"C:\Users\Public";
            path = System.IO.Path.Combine(saveLocation, fileName);
        }

        [TestMethod]
        public void TestGetTopicByName()
        {
            DataModel model = new DataModel(path)
            {
                RevisionGroups = new Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>>()
            };

            //Topic objects and associated topic names to compare later
            string[] topicNames = { "Xamarin", "C#", "Java", "F#", "Python" };
            TopicSQL[] topics = new TopicSQL[topicNames.Length];

            //Set local dictionary
            for (int i = 0; i < topicNames.Length; i++)
            {
                topics[i] = new TopicSQL() { TopicName = topicNames[i] };
                model.RevisionGroups.Add(topics[i], new ObservableCollection<RevisionCardSQL>());
            }

            //Check that all topics can be retrieved by name
            for (int i = 0; i < topicNames.Length; i++)
            {
                var fetchedTopic = model.GetTopicByName(topicNames[i]);
                Assert.AreEqual(topics[i], fetchedTopic);
            }

        }

        [TestMethod]
        public void TestSaveTopic()
        {
            //Setup
            DataModel model = new DataModel(path);
            model.DeleteAll(); //Completely clears the data!!!! DO NOT USE IN ACTUAL CODE - TESTING METHOD
            model.LoadData();
            Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>> test = model.RevisionGroups;
            TopicSQL testTopic = new TopicSQL();
            testTopic.TopicName = "Xamarin";

            //Test
            model.SaveTopic(testTopic);

            //Assert
            Assert.AreEqual(test, model.RevisionGroups);

        }
        [TestMethod]
        public void TestDeleteTopic()
        {
            //Setup
            DataModel model = new DataModel(path);
            model.DeleteAll(); //Completely clears the data!!!! DO NOT USE IN ACTUAL CODE - TESTING METHOD
            model.LoadData();
            Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>> test = model.RevisionGroups;
            TopicSQL testTopic = new TopicSQL();
            testTopic.TopicName = "Xamarin";
            model.SaveTopic(testTopic);

            //Test
            model.SaveDeleteTopic(testTopic);

            //Assert
            Assert.AreEqual(0, model.RevisionGroups.Count);
        }

        [TestMethod]
        public void TestSaveAndDeleteCard()
        {
            DataModel model = new DataModel(path);
            model.DeleteAll(); //Completely clears the data!!!! DO NOT USE IN ACTUAL CODE - TESTING METHOD

            //Setup
            RevisionCardSQL[] testCards = new RevisionCardSQL[5];
            string[] topicNames = { "Pancakes", "Chemistry", "Nuclear Physics" };

            //Save to file
            for (int i = 0; i < topicNames.Length; i++)
            {
                model.SaveTopic(new TopicSQL() { TopicName = topicNames[i] });
                for (int j = 0; j < testCards.Length; j++)
                {
                    testCards[j] = new RevisionCardSQL() { Topic = topicNames[i], Answer = "A" + j.ToString(), Question = "Q" + j.ToString()};
                    model.SaveCard(testCards[j]);
                }
            }            

            //Read from file
            model.LoadData();

            //Test
            for (int i = 0; i < topicNames.Length; i++)
            {
                for (int j = 0; j < testCards.Length; j++)
                {
                    var topic = model.GetTopicByName(topicNames[i]);
                    RevisionCardSQL fetchedCard = model.RevisionGroups[topic][j];

                    Assert.AreEqual("Q" + j.ToString(), fetchedCard.Question);
                    Assert.AreEqual("A" + j.ToString(), fetchedCard.Answer);
                }
            }
            //Setup for testing of deleting cards
            for (int i = 0; i < model.RevisionGroups.Count; i++)
            {
                var topic = model.GetTopicByName(topicNames[i]);
                int count = model.RevisionGroups[topic].Count;
                while (model.RevisionGroups[topic].Count > 0)
                {
                    model.SaveDeleteCard(model.RevisionGroups[topic][0]);
                }
                Assert.AreEqual(0, model.RevisionGroups[topic].Count); 
            }
        }

    }
}
