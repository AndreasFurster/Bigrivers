using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Server.Model
{
    class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public int Order { get; set; }
        public int Parent { get; set; }
    }
}
