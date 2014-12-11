using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Server.Model
{
    public class Performance
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Event Event { get; set; }

    }
}
