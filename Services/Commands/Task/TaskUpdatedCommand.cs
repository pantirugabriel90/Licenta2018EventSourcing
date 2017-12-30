﻿using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class TaskUpdatedCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string IssuedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public double Hours { get; set; }
        public DateTime UpdateDate { get; set; }

        public TaskUpdatedCommand(Guid aggregateId, string issuedBy, string title, string description, List<string> tags, double hours, DateTime updateDate)
        {
            AggregateId = aggregateId;
            IssuedBy = issuedBy;
            Title = title;
            Description = description;
            Tags = tags;
            Hours = hours;
            UpdateDate = updateDate;
        }
    }
}
