using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class TaskCompletedCommand:ICommand
    {
        public Guid AggregateId { get; set; }
        public bool Completed { get; set; }
        public string IssuedBy { get; set; }

        public TaskCompletedCommand(Guid aggregateId,bool completed,string issuedBy)
        {
            AggregateId = aggregateId;
            Completed = completed;
            IssuedBy = issuedBy;
        }
    }
}
