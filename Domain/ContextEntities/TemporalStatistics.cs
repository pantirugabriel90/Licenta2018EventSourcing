using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ContextEntities
{
    public class TemporalStatistics
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public int StarterTopics { get; set; }
        public int NumberOfReplies { get; set; }
        public int StartedTasks { get; set; }
        public int CompletedTasks { get; set; }
        public double LoggedHours { get; set; }
    }
}
