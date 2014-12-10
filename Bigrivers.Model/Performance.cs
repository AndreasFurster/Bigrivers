using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Performance
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Event Event { get; set; }
        public virtual bool Status { get; set; }
    }
}
