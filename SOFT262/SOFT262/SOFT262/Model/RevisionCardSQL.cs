using SQLite;
using System;

namespace SOFT262.Model
{
    [Table("RevisionCards")]
    public class RevisionCardSQL
    {
        [PrimaryKey, AutoIncrement, Ignore]
        public int ID { get; set; }
        public string Topic { get; set; }

        [MaxLength(1000)]
        public string Question { get; set; }

        [MaxLength(1000)]
        public string Answer { get; set; }        
    }
}
