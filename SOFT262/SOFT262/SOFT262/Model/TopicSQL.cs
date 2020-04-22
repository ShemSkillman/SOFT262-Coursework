using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262.Model
{
    [Table("Topics")]
    public class TopicSQL
    {
        [PrimaryKey, Unique]
        public string Topic { get; set; }
        public int CardCount { get; set; } = 0;
    }
}
