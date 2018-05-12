using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.Events;

namespace EventsConsummer.Handlers
{
    public class GradeStatisticsHandler : IEventsHandler
    {
        public const string ViewName = "GradeStatistics";
        private ApplicationContext _context { get; }

        public GradeStatisticsHandler()
        {
            _context = new ApplicationContext();
        }

        public void Handle(TaskCreatedEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.StartedTasks = student.StartedTasks + 1;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.StartedTasks = students.Average(ss => ss.StartedTasks);
            _context.SaveChanges();
        }


        public void Handle(TaskUpdatedEvent message)
        {
        }

        public void Handle(TaskStatusChangedEvent message)
        {
          
        }

        public void Handle(TopicCreatedEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.StarterTopics = student.StarterTopics + 1;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.StartedTopics = students.Average(ss => ss.StarterTopics);
            _context.SaveChanges();
        }

        public void Handle(TopicUpdatedEvent message)
        {
        }

        public void Handle(ReplyUpdatedEvent message)
        {
        }

        public void Handle(NewReplyAddedEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.NumberOfReplies = student.NumberOfReplies + 1;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.NumberOfReplies = students.Average(ss => ss.NumberOfReplies);
            _context.SaveChanges();
        }

        public void Handle(TaskCompletedEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.CompletedTasks = student.CompletedTasks + 1;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.CompletedTasks = students.Average(ss => ss.CompletedTasks);
            _context.SaveChanges();
        }

        public void Handle(TaskReopenEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.CompletedTasks = student.CompletedTasks - 1;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.CompletedTasks = students.Average(ss => ss.CompletedTasks);
            _context.SaveChanges();
        }

        public void Handle(TaskHoursLoggedEvent message)
        {
            var grade = _context.StudentStatistics.FirstOrDefault(sg => sg.Username == message.IssuedBy).Grade;
            var students = _context.StudentStatistics.Where(ss => ss.Grade == grade);
            var student = students.FirstOrDefault(ss => ss.Username == message.IssuedBy);
            student.LoggedHours = student.LoggedHours + message.Hours;

            var gradeStatistics = _context.GradesStatistics.FirstOrDefault(gs => gs.Grade == grade);
            gradeStatistics.LoggedHours = students.Average(ss => ss.LoggedHours);
            _context.SaveChanges();
        }
    }
}
