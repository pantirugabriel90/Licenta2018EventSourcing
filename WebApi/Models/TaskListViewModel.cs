using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class TaskListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
