using CQRSlite.Commands;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.Topic
{
    public class TopicCommandHandler : ICommandHandler<CreateTopicCommand>,ICommandHandler<UpdateTopicCommand>, ICommandHandler<AddNewReplyCommand>, ICommandHandler<UpdateReplyCommand>
    {
        private readonly ISession _session;

        public TopicCommandHandler(ISession session)
        {
            _session = session;
        }
        public async System.Threading.Tasks.Task Handle(CreateTopicCommand command)
        {
            var topic = new Domain.Topic(Guid.NewGuid(), command.Title, command.Content, command.Date, command.IssuedBy);
            await _session.Add(topic);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(UpdateTopicCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.UpdateMainTopic(command.AggregateId, command.Title, command.Content, command.UpdateDate, command.IssuedBy);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(UpdateReplyCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.UpdateReply(command.AggregateId, command.Content, command.Date, command.IssuedBy, command.ReplyId);
            await _session.Commit();
        }

        public async System.Threading.Tasks.Task Handle(AddNewReplyCommand command)
        {
            var topic = await _session.Get<Domain.Topic>(command.AggregateId);
            topic.AddNewReply(command.AggregateId,command.Content,command.Date,command.IssuedBy,Guid.NewGuid());
            await _session.Commit();
        }
    }
}
