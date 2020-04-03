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
    public class CreationViewModel : INotifyPropertyChanged
    {
        MainModel model;
        private ICreationPageHelper viewHelper;
        int topicIndex = -1;
        bool enableNewTopicNameInput = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public CreationViewModel(MainModel model)
        {
            this.model = model;
            TopicIndex = 0;
        }

        public int TopicIndex
        {
            get => topicIndex;
            set
            {
                if (topicIndex == value) return;

                topicIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TopicIndex)));

                if (topicIndex == 0) EnableNewTopicNameInput = true;
                else EnableNewTopicNameInput = false;
            }
        }

        public bool EnableNewTopicNameInput
        {
            get => enableNewTopicNameInput;
            set
            {
                if (enableNewTopicNameInput == value) return;

                enableNewTopicNameInput = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnableNewTopicNameInput)));
            }
        }

        public ICommand CreateCardClick { get; private set; }

    }
}
