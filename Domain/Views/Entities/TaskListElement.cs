using System;

namespace Domain.Views.Entities
{
    public class TaskListElement
    {
        public Guid Id { get; set; }
        public bool Completed { get; set; }
        public string IssuedBy { get; set; }
        public string Title { get; set; }

    }
}
