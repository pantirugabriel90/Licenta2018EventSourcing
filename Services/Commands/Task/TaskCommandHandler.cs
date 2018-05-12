﻿using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using Domain;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Services.Queries;

namespace Services.Commands.Task
{
    public class TaskCommandHandler : ICommandHandler<CreateTaskCommand>, ICommandHandler<UpdateTaskCommand>, ICommandHandler<CompleteTaskCommand>, ICommandHandler<LogTaskHoursCommand>, ICommandHandler<ReopenTaskCommand>
    {
        private readonly ISession _session;
        private SemaphoreSlim _semaphoreSlim;
       
        public TaskCommandHandler(ISession session)
        {
            _semaphoreSlim = new SemaphoreSlim(1, 1);
            _session = session;
        }

        public async System.Threading.Tasks.Task Handle(CreateTaskCommand command)
        {
             _semaphoreSlim.Wait();
            try
            {
                var task = new Domain.Task(Guid.NewGuid(), command.IssuedBy, command.Title, command.Content, command.Tags, command.Hours);
                await _session.Add(task);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(UpdateTaskCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var task = await _session.Get<Domain.Task>(command.AggregateId);
                task.UpdateTaskDetails(command.AggregateId, command.IssuedBy, command.Title, command.Content, command.Tags, command.Hours, command.LoggedHours, command.CompletedStatus);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(CompleteTaskCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var task = await _session.Get<Domain.Task>(command.AggregateId);
                task.CompleteTask(command.AggregateId, command.IssuedBy);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(ReopenTaskCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var task = await _session.Get<Domain.Task>(command.AggregateId);
                task.ReopenTask(command.AggregateId, command.IssuedBy);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(LogTaskHoursCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var task = await _session.Get<Domain.Task>(command.AggregateId);
                task.LogHours(command.AggregateId, command.IssuedBy, command.HoursLogged);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

    }
}
