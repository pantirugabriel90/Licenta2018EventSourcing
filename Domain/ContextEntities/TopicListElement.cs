using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ContextEntities
{
    public class TopicListElement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
        [Display(Name = "Replies")]
        public int NumberOfReplies { get; set; }
        [Display(Name = "Issued By")]
        public string IssuedBy { get; set; }

    }
}
