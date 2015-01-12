using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Client.DAL
{
    public class DAL : Default.Container
    {
        public DAL(Uri serviceRoot)
            : base(serviceRoot)
        {
        }
    }
}
