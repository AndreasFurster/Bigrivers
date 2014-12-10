using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Location
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Stagename { get; set; }

        public virtual List<Event> Events { get; set; }

    }
}
