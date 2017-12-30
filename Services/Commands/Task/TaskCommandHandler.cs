using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Task
{
    public class TaskCommandHandler : ICommandHandler<TaskCreatedCommand> , ICommandHandler<TaskUpdatedCommand>
    {
        private readonly ISession _session;

        public TaskCommandHandler(ISession session)
        {
            _session = session;
        }
        public async System.Threading.Tasks.Task Handle(TaskCreatedCommand command)
        {
            var task = new Domain.Task(command.AggregateId,command.IssuedBy,command.Title,command.Content,command.Tags,command.Hours,command.Date);
            await _session.Add(task);
            await _session.Commit();
        }

        public System.Threading.Tasks.Task Handle(TaskUpdatedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
