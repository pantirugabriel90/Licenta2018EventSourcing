﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Reply
    {

        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }
    }
}
