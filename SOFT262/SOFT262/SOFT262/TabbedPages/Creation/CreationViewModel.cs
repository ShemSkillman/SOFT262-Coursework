using SOFT262.Model;
using SOFT262.TabbedPages.Creation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOFT262.Creation
{
    public class CreationViewModel
    {
        MainModel model;
        private ICreationPageHelper viewHelper;
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
        public ICommand CreateCardClick { get; private set; }
        public CreationViewModel(MainModel model, ICreationPageHelper p) : base()
        {
            this.model = model;
            viewHelper = p;
            CreateCardClick = new Command(execute: async () =>
            {
                string newTopic = await viewHelper.AskForString("New Topic", "What would you like the new topic name to be?");
                if (newTopic == null) return;
                
            }
            );
        }
    }
}
