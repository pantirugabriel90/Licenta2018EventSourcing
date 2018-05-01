﻿using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class CompleteTaskCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string IssuedBy { get; set; }
    }
}
