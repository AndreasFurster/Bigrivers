using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRivers.Client.Frontend.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string CreatedByIdentityUserId { get; set; }
        public string ModifiedByIdentityUserId { get; set; }
        public DateTime PublishedStart { get; set; }
        public DateTime PublishedEnd { get; set; }
        public int Parent { get; set; }
        public bool Status { get; set; }
    }
}
