using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ContextEntities
{
    public class StudentStatistics
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public double Grade { get; set; }
        public int StarterTopics { get; set; }
        public int NumberOfReplies { get; set; }
        public int StartedTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int LoggedHours { get; set; }
    }
}
