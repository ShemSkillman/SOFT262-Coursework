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
            DataModel model = new DataModel(path);

            model.LoadData();
            Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>> test = model.RevisionGroups;
            TopicSQL testTopic = new TopicSQL();
            testTopic.TopicName = "Xamarin";
            model.SaveTopic(testTopic);
            Assert.AreEqual(test, model.RevisionGroups);

        }

        [TestMethod]
        public void TestSaveCard()
        {
            DataModel model = new DataModel(path);

            RevisionCardSQL[] testCards = new RevisionCardSQL[5];
            string[] topicNames = { "Pancakes", "Chemistry", "Nuclear Physics" };

            for (int i = 0; i < topicNames.Length; i++)
            {
                for (int j = 0; j < testCards.Length; j++)
                {
                    testCards[j] = new RevisionCardSQL() { ID = j, Topic = topicNames[i] };
                    model.SaveCard(testCards[j]);
                }
            }
            

            model.LoadData();


        }
    }
}
