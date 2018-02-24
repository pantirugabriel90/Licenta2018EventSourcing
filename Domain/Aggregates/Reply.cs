using System;

namespace Domain
{
    public class Reply
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IssuedBy { get; set; }
    }
}
