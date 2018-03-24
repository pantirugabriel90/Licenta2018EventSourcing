using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Views.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string IssuedBy { get; set; }
        public DateTime Date { get; set; }
        public List<Reply> Replies { get; set; }
    }

    public class Reply
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }
    }
}
