using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    class RevisionGroup
    {
        public string Topic { get; }
        List<RevisionCard> revisionCards = new List<RevisionCard>();

        public RevisionGroup(string topic)
        {
            Topic = topic;
        }

        public void AddRevisionCard(string question, string answer)
        {
            RevisionCard newCard = new RevisionCard(this, question, answer);

            revisionCards.Add(newCard);
        }
    }
}
