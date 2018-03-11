using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class ChangeTaskStatusCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string IssuedBy { get; set; }

        public ChangeTaskStatusCommand(Guid aggregateId,string issuedBy)
        {
            AggregateId = aggregateId;
            IssuedBy = issuedBy;
        }
    }
}
