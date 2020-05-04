using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOFT262.Model;

namespace UnitTesting
{
    [TestClass]
    class DataModelTest
    {
        [TestMethod]
        public void TestGetTopicByName()
        {
            DataModel model = new DataModel
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
            for(int i = 0; i < topicNames.Length; i++)
            {
                var fetchedTopic = model.GetTopicByName(topicNames[i]);
                Assert.Equals(fetchedTopic, topics[i]);
            }
            
        }
        [TestMethod]
        public void TestSaveTopic()
        {
            DataModel model = new DataModel();

            model.LoadData();
            Dictionary<TopicSQL, ObservableCollection<RevisionCardSQL>> test = model.RevisionGroups;
            TopicSQL testTopic = new TopicSQL();
            testTopic.TopicName = "Xamarin";
            model.SaveTopic(testTopic);
            Assert.AreEqual(test, model.RevisionGroups);
            
        }
    }
}
