using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    public class RevisionCard
    {
        string Topic { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public RevisionCard(string topic, string question, string answer)
        {
            Topic = topic;
            Question = question;
            Answer = answer;
        }
    }
}
