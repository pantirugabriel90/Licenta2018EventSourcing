using System;
using System.Collections.Generic;
using System.Text;
using Domain.Events;

namespace ViewProcessor
{
    public interface IEventsHandler
    {
        void Handle(TaskCreatedEvent message);
        void Handle(TaskUpdatedEvent message);
        void Handle(TaskStatusChangedEvent message);
        void Handle(TopicCreatedEvent message);
        void Handle(TopicUpdatedEvent message);
        void Handle(ReplyUpdatedEvent message);
        void Handle(NewReplyAddedEvent message);
    }
}
