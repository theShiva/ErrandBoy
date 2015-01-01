using System;
using System.Collections.Generic;

namespace ErrandBoy.Web.Api.Models
{
    public class Task
    {
        private List<Link> _links { get; set; }

        public long TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? StartedOnDate { get; set; }
        public DateTime? DueOnDate { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public DateTime? CompletedOnDate { get; set; }
        public Status CurrentStatus { get; set; }
        public List<User> Assignees { get; set; }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
