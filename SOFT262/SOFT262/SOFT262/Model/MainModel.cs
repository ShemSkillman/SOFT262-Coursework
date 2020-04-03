using SOFT262.Creation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    public class MainModel
    {
        public List<RevisionGroup> RevisionGroups { get; }

        public void CreateRevisionGroup(string topic)
        {
            foreach (var group in RevisionGroups)
            {
                // Check if topic of same name exists
                if (group.Topic.Equals(topic)) return;
            }

            RevisionGroup newGroup = new RevisionGroup(topic);
            RevisionGroups.Add(newGroup);
        }

        public static implicit operator MainModel(CreationViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
