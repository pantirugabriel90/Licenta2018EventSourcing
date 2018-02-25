using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Views.Entities
{
    public class Task
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public double LoggedHours { get; set; }
        public double Hours { get; set; }
        public DateTime Date { get; set; }
        public List<Tag> Tags { get; set; }
        public bool CompletedStatus { get; set; }
        public Task()
        {
        }
        public Task(Guid id, string title, string content, List<Tag> tags, double hours, DateTime date,bool completedStatus,double loggedHours)
        {

            Id = id;
            Title = title;
            CompletedStatus = completedStatus;
            Content = content;
            Tags = tags;
            LoggedHours = loggedHours;
            Hours = hours;
            Date = date;


        }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
