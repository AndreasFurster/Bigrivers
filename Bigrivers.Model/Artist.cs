using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.Model
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<string> Messages { get; set; }

        public Artist(int id, string name)
        {
            this.Messages = new List<string>();
            this.Id = id;
            this.Name = name;
        }

        public void AddMessage(string message)
        {
            this.Messages.Add(message);
        }
    }
}
