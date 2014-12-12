using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Artist> Artists { get; set; }
    }
}
