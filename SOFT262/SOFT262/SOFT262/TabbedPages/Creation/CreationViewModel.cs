using SOFT262.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SOFT262.Creation
{
    public class CreationViewModel
    {
        MainModel model;

        int topicIndex;

        public int TopicIndex
        {
            get => topicIndex;
            set
            {
                if (topicIndex == value) return;

                topicIndex = value;
            }
        }

        public CreationViewModel(MainModel model)
        {
            this.model = model;
        }
    }
}
