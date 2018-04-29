using CQRSlite.Commands;
using CQRSlite.Domain;
using Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Commands.Topic
{
    public class TopicCommandHandler : ICommandHandler<CreateTopicCommand>, ICommandHandler<UpdateTopicCommand>, ICommandHandler<AddNewReplyCommand>, ICommandHandler<UpdateReplyCommand>
    {

        private readonly ISession _session;
        private SemaphoreSlim _semaphoreSlim;

        public TopicCommandHandler(ISession session)
        {
            _semaphoreSlim = new SemaphoreSlim(1, 1);
            _session = session;
        }

        public async System.Threading.Tasks.Task Handle(CreateTopicCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var topic = new Domain.Topic(Guid.NewGuid(), command.Title, command.Content, command.Date, command.IssuedBy);
                await _session.Add(topic);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(UpdateTopicCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var topic = await _session.Get<Domain.Topic>(command.AggregateId);
                topic.UpdateMainTopic(command.AggregateId, command.Title, command.Content, command.UpdateDate, command.IssuedBy);
                await _session.Commit();

            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(UpdateReplyCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var topic = await _session.Get<Domain.Topic>(command.AggregateId);
                topic.UpdateReply(command.AggregateId, command.Content, command.Date, command.IssuedBy, command.ReplyId);
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async System.Threading.Tasks.Task Handle(AddNewReplyCommand command)
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                var topic = await _session.Get<Domain.Topic>(command.AggregateId);
                topic.AddNewReply(command.AggregateId, command.Content, command.Date, command.IssuedBy, Guid.NewGuid());
                await _session.Commit();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
