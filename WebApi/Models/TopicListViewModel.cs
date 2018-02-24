using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class TopicListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string IssuedBy { get; set; }
        public DateTime Date { get; set; }
    }
}
