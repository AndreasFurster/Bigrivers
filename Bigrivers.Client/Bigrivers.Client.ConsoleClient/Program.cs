using System;
using System.Configuration;
using System.Linq;
using Bigrivers.Client.DAL.Default;
using Bigrivers.Client.DAL.Bigrivers.Server.Model;

namespace Bigrivers.Client.ConsoleClient
{
    internal class Program
    {
        // Create AccessLayer with Uri from the App.Config
        static readonly Container AccessLayer = new Container(new Uri(ConfigurationManager.AppSettings["WebserviceUri"]));

        private static void Main(string[] args)
        {
            Console.WriteLine("Hallo!");

            var listOfRealArtists = AccessLayer.Artists.Where(a => a.Name != "Justin Bieber").ToList();

            foreach (var artist in listOfRealArtists)
            {
                Console.WriteLine("{0} heeft een mooie website: {1}!", artist.Name, artist.Website);
            }

            Console.WriteLine("\n Wil je een artiest toevoegen? (J/N)");

            if (Console.ReadLine().ToLower() == "j")
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

                AccessLayer.AddToArtists(newArtist);

                var response = AccessLayer.SaveChanges();
                Console.WriteLine("\n \n {0}", response);
            }

            // Read Sponsors
            var listOfActiveSponsors = AccessLayer.Sponsors.Where(a => a.Status).ToList();

            Console.WriteLine("");
            foreach (var sponsor in listOfActiveSponsors)
            {
                Console.WriteLine("{0} is actief als sponsor", sponsor.Name);
            }

            // Create Sponsors
            Console.WriteLine("\n Wil je een nieuw sponsor toevoegen? (J/N)");

            if (Console.ReadLine().ToLower() == "j")
            {
                var newSponsor = new Sponsor();

                Console.Write("\n \n Naam: ");
                newSponsor.Name = Console.ReadLine();

                Console.Write("\n Url: ");
                newSponsor.Url = Console.ReadLine();

                newSponsor.Priority = 0;
                newSponsor.Status = true;

                AccessLayer.AddToSponsors(newSponsor);

                var response = AccessLayer.SaveChanges();
                Console.WriteLine("\n \n De nieuwe sponsor is aangemaakt.");
            }

            // Update Sponsors
            Console.WriteLine("\n Wil je een bestaande sponsor aanpassen? (J/N)");

            if (Console.ReadLine().ToLower() == "j")
            {
                Console.WriteLine("\n \n Welke sponsor wil je aanpassen? (Naam)");
                var userInput = Console.ReadLine();

                var sponsor = AccessLayer.Sponsors.Where(a => a.Name == userInput).FirstOrDefault();

                // Check if Sponsor name is valid!
                if (sponsor != null)
                {
                    Console.Write("\n \n Huidige Naam: {0}", sponsor.Name);
                    Console.Write("\n Huidige Url: {0}", sponsor.Url);

                    Console.Write("\n \n Nieuwe Naam: ");
                    sponsor.Name = Console.ReadLine();

                    Console.Write("\n Nieuwe Url: ");
                    sponsor.Url = Console.ReadLine();

                    AccessLayer.UpdateObject(sponsor);

                    var response = AccessLayer.SaveChanges();
                    Console.WriteLine("\n \n De sponsor is aangepast");
                }
                else
                {
                    Console.WriteLine("De opgegeven naam is niet geldig.");
                }
            }

            // Delete Sponsors
            Console.WriteLine("\n Wil je een bestaande sponsor verwijderen? (J/N)");

            if (Console.ReadLine().ToLower() == "j")
            {
                Console.WriteLine("\n \n Welke sponsor wil je verwijderen? (Naam)");
                var userInput = Console.ReadLine();

                var sponsor = AccessLayer.Sponsors.Where(a => a.Name == userInput).FirstOrDefault();

                // Check if Sponsor name is valid
                if (sponsor != null)
                {
                    // Last warning before deleting Sponsor
                    Console.WriteLine("\n Weet je zeker dat je {0} als sponsor wilt verwijderen? (J/N)", sponsor.Name);

                    if (Console.ReadLine().ToLower() == "j")
                    {
                        AccessLayer.DeleteObject(sponsor);
                        var response = AccessLayer.SaveChanges();
                        Console.WriteLine("\n \n De sponsor is verwijderd!");
                    }
                    else
                    {
                        Console.WriteLine("\n De sponsor is NIET verwijderd!");
                    }
                }
                else
                {
                    Console.WriteLine("De opgegeven naam is niet geldig.");
                }
            }

            // pause
            Console.ReadLine();
        }
    }
}