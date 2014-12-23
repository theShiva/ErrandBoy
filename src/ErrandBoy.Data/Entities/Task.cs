using System;
using System.Collections.Generic;

namespace ErrandBoy.Data.Entities
{
    public class Task
    {
        private readonly IList<User> _users = new List<User>();
  
        public virtual long TaskId { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? StartedOnDate { get; set; }
        public virtual DateTime? DueOnDate { get; set; }
        public virtual DateTime? CompletedOnDate { get; set; }
        public virtual Status CurrentStatus { get; set; }
        public virtual DateTime? CreatedOnDate { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual IList<User> Users
        {
            get { return _users; } 
        }

        public virtual byte[] Version { get; set; }

    }
}
