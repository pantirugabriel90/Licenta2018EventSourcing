using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.ContextEntities
{
    public class TaskListElement
    {
        public Guid Id { get; set; }
        public bool Completed { get; set; }
        [Display(Name = "Issued By")]
        public string IssuedBy { get; set; }
        public string Title { get; set; }

    }
}
