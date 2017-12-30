using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Topic
{
    public class TopicCommandHandler : ICommandHandler<TopicCreatedCommand>,ICommandHandler<TopicUpdatedCommand>, ICommandHandler<NewReplyCommand>, ICommandHandler<ReplyUpdatedCommand>
    {
        private readonly ISession _session;

        public TopicCommandHandler(ISession session)
        {
            _session = session;
        }
        public async System.Threading.Tasks.Task Handle(TopicCreatedCommand command)
        {
            var topic = new Domain.Topic(command.AggregateId, command.Title, command.Content, command.Date, command.IssuedBy);
            await _session.Add(topic);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(TopicUpdatedCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.UpdateMainTopic(command.AggregateId, command.Title, command.Content, command.UpdateDate, command.IssuedBy);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(ReplyUpdatedCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.UpdateReply(command.AggregateId, command.Content, command.Date, command.IssuedBy, command.ReplyId);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(NewReplyCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.AddNewReply(command.AggregateId,command.Content,command.Date,command.IssuedBy,command.ReplyId);
            await _session.Commit();
        }
    }
}
