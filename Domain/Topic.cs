using System;
using System.Collections.Generic;

namespace Domain
{
    public class Topic
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Reply> Replies { get; set; }
        public string IssuedBy { get; set; }
    } 
}
                    