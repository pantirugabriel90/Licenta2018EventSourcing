using Domain.Events;
using Domain.Events.Tasks;

namespace ViewProcessor
{
    public interface IEventsHandler
    {
        void Handle(TaskCreatedEvent message);
        void Handle(TaskUpdatedEvent message);
        void Handle(TaskStatusChangedEvent message);
    }
}
