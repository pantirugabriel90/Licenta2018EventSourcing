using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ContextEntities
{
    public class GradeStatistics
    {
        public int Id { get; set; }
        public double Grade { get; set; }
        public double CompletedTasks { get; set; }
        public double StartedTasks { get; set; }
        public double StartedTopics { get; set; }
        public double NumberOfReplies { get; set; }
        public double LoggedHours { get; set; }
    }
}
