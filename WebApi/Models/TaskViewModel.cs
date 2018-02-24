using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Hours { get; set; }
        public DateTime Date { get; set; }
        public bool CompletedStatus { get; set; }
        public double LoggedHours { get; set; }
    }
}
