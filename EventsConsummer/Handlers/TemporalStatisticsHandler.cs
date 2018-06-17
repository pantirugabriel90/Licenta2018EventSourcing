using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.Events;

namespace EventsConsummer.Handlers
{
    class TemporalStatisticsHandler : IEventsHandler
    {
        public const string ViewName = "GradeStatistics";
        private ApplicationContext _context { get; }

        public TemporalStatisticsHandler()
        {
            _context = new ApplicationContext();
        }

        public void Handle(TaskCreatedEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s=>s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null) {
                statisticsForDay.StartedTasks = statisticsForDay.StartedTasks + 1;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, StartedTasks = 1, Date = message.TimeStamp.Date};
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }

        public void Handle(TaskUpdatedEvent message)
        {
        }

        public void Handle(TaskStatusChangedEvent message)
        {
        }

        public void Handle(TaskCompletedEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s => s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null)
            {
                statisticsForDay.CompletedTasks = statisticsForDay.CompletedTasks + 1;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, CompletedTasks = 1, Date = message.TimeStamp.Date };
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }

        public void Handle(TaskReopenEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s => s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null)
            {
                statisticsForDay.CompletedTasks = statisticsForDay.CompletedTasks - 1;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, CompletedTasks = -1, Date = message.TimeStamp.Date };
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }

        public void Handle(TaskHoursLoggedEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s => s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null)
            {
                statisticsForDay.LoggedHours = statisticsForDay.LoggedHours + message.Hours;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, LoggedHours = message.Hours, Date = message.TimeStamp.Date };
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }

        public void Handle(TopicCreatedEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s => s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null)
            {
                statisticsForDay.StarterTopics = statisticsForDay.StarterTopics + 1;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, StarterTopics = 1, Date = message.TimeStamp.Date };
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }

        public void Handle(TopicUpdatedEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ReplyUpdatedEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(NewReplyAddedEvent message)
        {
            var statisticsForDay = _context.TemporalStatistics.FirstOrDefault(s => s.Username == message.IssuedBy && s.Date.Date == message.TimeStamp.Date);

            if (statisticsForDay != null)
            {
                statisticsForDay.NumberOfReplies = statisticsForDay.NumberOfReplies + 1;
            }
            else
            {
                statisticsForDay = new Domain.ContextEntities.TemporalStatistics { Username = message.IssuedBy, NumberOfReplies = 1, Date = message.TimeStamp.Date };
                _context.TemporalStatistics.Add(statisticsForDay);
            }
            _context.SaveChanges();

        }
    }
}
