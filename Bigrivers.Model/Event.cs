using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Price { get; set; }
        public bool TicketRequired { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }

        public virtual List<Performance> Performances { get; set; }
        public virtual Location Location { get; set; }

    }
}
