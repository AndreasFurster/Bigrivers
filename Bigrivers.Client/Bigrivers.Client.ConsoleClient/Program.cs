using System;
using System.Linq;
using Bigrivers.Client.ConsoleClient.Bigrivers.Server.Model;
using Bigrivers.Client.ConsoleClient.Default;
using Microsoft.OData.Client;

namespace Bigrivers.Client.ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hallo!");

            // send webservice request to localhost:<port>/api/Artist/Index
            //Communicator c = new Communicator();

            //c.HowToMakeRequestsToHttpBasedServices();

            var odataUri = new Uri("http://localhost:54240/odata");
            var container = new Container(odataUri);

            var listOfRealArtists = container.Artists.Where(a => a.Name != "Justin Bieber").ToList();

            foreach (var artist in listOfRealArtists)
            {
                Console.WriteLine("{0} heeft een mooie website: {1}!", artist.Name, artist.Website);
            }

            Console.WriteLine("\n Wil je een artiest toevoegen? (J/N)");

            if (Console.ReadKey().Key.ToString().ToLower() == "j")
            {
                var newArtist = new Artist();

                Console.Write("\n \n Naam: ");
                newArtist.Name = Console.ReadLine();

                Console.Write("Beschrijving: ");
                newArtist.Description = Console.ReadLine();

                Console.Write("Website: ");
                newArtist.Website = Console.ReadLine();

                Console.Write("Youtube kanaal: ");
                newArtist.YoutubeChannel = Console.ReadLine();

                Console.Write("Facebook: ");
                newArtist.Facebook = Console.ReadLine();

                Console.Write("Twitter: ");
                newArtist.Twitter = Console.ReadLine();

                container.AddToArtists(newArtist);

                DataServiceResponse response = container.SaveChanges();
                Console.WriteLine("\n \n {0}", response);
            }

            // pause
            Console.ReadLine();
        }
    }
}