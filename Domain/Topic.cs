using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Topic : AggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Reply> Replies { get; set; }
        public string IssuedBy { get; set; }
    } 
}
                    