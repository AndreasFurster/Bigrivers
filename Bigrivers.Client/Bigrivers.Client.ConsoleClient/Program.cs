using System;

namespace Bigrivers.Client.ConsoleClient
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
