using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bigrivers.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo!");
            
            // send webservice request to localhost:<port>/api/Artist/Index
            Communicator c = new Communicator();

            c.HowToMakeRequestsToHttpBasedServices();
            

            // pause
            Console.ReadLine();
        }



    }
}
