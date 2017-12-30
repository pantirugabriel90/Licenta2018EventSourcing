using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Task : AggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string IssuedBy { get; set; }
    }
}
