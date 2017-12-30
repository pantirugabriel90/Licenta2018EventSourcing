using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Topic
{
    class TopicCommandHandler : ICommandHandler<TopicCreatedCommand>,ICommandHandler<TopicUpdatedCommand>
    {
        private readonly ISession _session;

        public TopicCommandHandler(ISession session)
        {
            _session = session;
        }
        public async System.Threading.Tasks.Task Handle(TopicCreatedCommand command)
        {
            var topic = new Domain.Topic(command.AggregateId,command.Title,command.Content,command.Date,command.Replies,command.IssuedBy);
            await _session.Add(topic);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(TopicUpdatedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
