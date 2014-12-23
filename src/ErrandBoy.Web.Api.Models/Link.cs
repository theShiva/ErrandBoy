using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrandBoy.Web.Api.Models
{
    public class Link
    {
        public virtual string Rel { get; set; }
        public virtual string Href { get; set; }
        public virtual string Method { get; set; }
    }
}
