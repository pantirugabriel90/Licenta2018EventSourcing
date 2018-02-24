using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Views.Entities;

namespace Services.Commands.Task
{
    public class CreateTaskCommand : ICommand
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; }
        public double Hours { get; set; }
        public string IssuedBy { get; set; }

        public CreateTaskCommand()
        {
                
        }
        public CreateTaskCommand(string issuedBy, string title, string content, List<Tag> tags, double hours)
        {
            Title = title;
            Content = content;
            Tags = tags;
            Hours = hours;
            IssuedBy = issuedBy;
        }
    }
}
