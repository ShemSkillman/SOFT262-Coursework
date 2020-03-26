using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    class RevisionCard
    {
        RevisionGroup Group { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public RevisionCard(RevisionGroup group, string question, string answer)
        {
            Group = group;
            Question = question;
            Answer = answer;
        }
    }
}
