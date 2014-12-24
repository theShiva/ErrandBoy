using System.Collections.Generic;

namespace ErrandBoy.Web.Api.Models
{
    public class User
    {
        private IList<Link> _links = new List<Link>();
 
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Link> Links { get; set; }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
