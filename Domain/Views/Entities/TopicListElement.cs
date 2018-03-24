using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Views.Entities
{
    public class TopicListElement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime LastActivity { get; set; }
        public int NumberOfReplies { get; set; }
        public string IssuedBy { get; set; }

    }
}
