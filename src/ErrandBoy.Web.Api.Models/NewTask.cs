﻿using System;
using System.Collections.Generic;

namespace ErrandBoy.Web.Api.Models
{
    public class NewTask
    {
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public List<User> Assignees { get; set; }
    }
}
