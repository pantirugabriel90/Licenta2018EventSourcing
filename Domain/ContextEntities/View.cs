using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ContextEntities
{
    public class View
    {
        public int Id { get; set; }
        public string ViewName { get; set; }
        public int NumberOfProcessedEvent { get; set; }
        public DateTimeOffset DateOfLastProcessedEvent { get; set; }
    }
}
