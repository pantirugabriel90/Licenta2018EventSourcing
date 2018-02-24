using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Task
{
    public class TaskCommandHandler : ICommandHandler<CreateTaskCommand> , ICommandHandler<TaskUpdatedCommand>, ICommandHandler<TaskStatusChangedCommand>
    {
        private readonly ISession _session;

        public TaskCommandHandler(ISession session)
        {
            _session = session;
        }
        public async System.Threading.Tasks.Task Handle(CreateTaskCommand command)
        {
            var task = new Domain.Task(Guid.NewGuid(),command.IssuedBy,command.Title,command.Content,command.Tags,command.Hours);
            await _session.Add(task);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(TaskUpdatedCommand command)
        {
            var task = await _session.Get<Domain.Task>(command.AggregateId);
            task.UpdateTaskDetails(command.AggregateId, command.IssuedBy, command.Title, command.Description, command.Tags, command.Hours, command.Date);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(TaskStatusChangedCommand command)
        {
            var task = await _session.Get<Domain.Task>(command.AggregateId);
            task.CompleteTask(command.AggregateId,command.IssuedBy);
            await _session.Commit();
        }
    }
}
