using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ReplyViewModel
    {
        public Guid Id { get; set; }
        public Guid ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }
    }
}
