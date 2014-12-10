using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Show
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Artist ShowArtist { get; set; }
        public virtual Location ShowLocation{ get; set; }


    }
}
