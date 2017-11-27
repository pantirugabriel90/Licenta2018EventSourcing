using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Schedule
{
    public class TaskCreatedCommand : ICommand
    {
        public int ExpectedVersion => throw new NotImplementedException();
    }
}
