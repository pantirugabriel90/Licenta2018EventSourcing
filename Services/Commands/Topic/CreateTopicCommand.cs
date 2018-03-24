using CQRSlite.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class CreateTopicCommand : ICommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }

        public CreateTopicCommand()
        {
                
        }

        public CreateTopicCommand(string title, string content,string issuedBy) {

            Title = title;
            Content = content;
            Date = DateTime.UtcNow;
            IssuedBy = issuedBy;
        }
    }
}
