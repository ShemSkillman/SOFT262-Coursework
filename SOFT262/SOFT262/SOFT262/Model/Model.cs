using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    class Model
    {
        List<RevisionGroup> revisionGroups;

        public List<RevisionGroup> RevisionGroups { get; }

        public void CreateRevisionGroup(string topic)
        {
            foreach (var group in revisionGroups)
            {
                // Check if topic of same name exists
                if (group.Topic.Equals(topic)) return;
            }

            RevisionGroup newGroup = new RevisionGroup(topic);
            revisionGroups.Add(newGroup);
        }
    }
}
