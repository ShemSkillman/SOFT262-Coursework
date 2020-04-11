using SOFT262.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262
{
    public class SQLConnection
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }
        public SQLConnection(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<RevisionCardSQL>();
        }

        public void AddNewCard(string Topic, string Question, string Answer)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(Topic) || string.IsNullOrEmpty(Question) || string.IsNullOrEmpty(Answer))
                {
                    throw new Exception("Topic, Question or Answer not inserted correctly!");
                }
                result = conn.Insert(new RevisionCardSQL { Topic = Topic, Answer = Answer, Question = Question });
               
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed with error: {0}", ex.Message);
            }
        }

        public List<RevisionCardSQL> GetAllCards()
        {
            try
            {
                return conn.Table<RevisionCardSQL>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data with error: {0}", ex.Message);
            }

            return new List<RevisionCardSQL>();
        }
        public List<RevisionCardSQL> GetAllTopics()
        {
            var allTopics = conn.Query<RevisionCardSQL>("Select distinct topic from RevisionCards");
            return allTopics;
            
        }
    }
}
