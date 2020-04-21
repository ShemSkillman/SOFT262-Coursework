using SQLite;
using System;

namespace SOFT262.Model
{
    [Table("RevisionCards")]
    public class RevisionCardSQL
    {
        public string Topic { get; set; }

        [MaxLength(250), Unique]
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
