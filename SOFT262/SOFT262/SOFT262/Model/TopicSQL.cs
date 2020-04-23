using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SOFT262.Model
{
    [Table("Topics")]
    public class TopicSQL : INotifyPropertyChanged
    {
        [PrimaryKey]
        public string TopicName { get; set; }

        private int cardCount = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CardCount
        {
            get => cardCount;
            set
            {
                if (cardCount == value) return;

                cardCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CardCount)));
            }
        }
    }
}
