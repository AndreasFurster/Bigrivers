using Bigrivers.Server.Data;
using Bigrivers.Server.Model;

namespace Bigrivers.Server.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BigriversDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BigriversDb context)
        {
            context.Artists.RemoveRange(context.Artists);
            context.Events.RemoveRange(context.Events);
            context.Performances.RemoveRange(context.Performances);
            context.Genres.RemoveRange(context.Genres);
            context.Locations.RemoveRange(context.Locations);

            // Create Genres
            Genre Rock = new Genre
            {
                Name = "Rock",
                Artists = new List<Artist>()
            };
            Genre Pop = new Genre
            {
                Name = "Pop",
                Artists = new List<Artist>()
            };
            Genre Blues = new Genre
            {
                Name = "Blues",
                Artists = new List<Artist>()
            };

            // Create Location
            Location Sterrenburg = new Location
            {
                Street = "Dordtsestraat",
                Zipcode = "1234 CS",
                City = "Dordrecht",
                Stagename = "Sterrenburg",
                Status = true,
                Events = new List<Event>()
            };

            // Create Artists
            Artist Queen = new Artist
            {
                Name = "Queen",
                Description = "Best group ever (to some people)",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/queenofficial",
                Website = "http://www.queenonline.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };

            Artist JusBie = new Artist
            {
                Name = "Justin Bieber",
                Description = "All the teenage girls!!!",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/JustinBieberVEVO",
                Website = "http://www.justinbiebermusic.com",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };

            Artist BruMar = new Artist
            {
                Name = "Bruno Mars",
                Description = "Lazy Billionaire",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/ElektraRecords",
                Website = "http://www.brunomars.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };

            // Create Events
            Event TGF = new Event
            {
                Title = "Teen Girl Fest",
                Description = "Everything an annoying preteen girl likes",
                ShortDescription = "Everything an annoying preteen girl likes",
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
                Location = Sterrenburg
            };

            Event BreakingFree = new Event
            {
                Title = "Breaking Free",
                Description = "One of the best groups ever here!",
                ShortDescription = "One of the best groups ever here!",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
            };

            // Create Performances
            Performance QueenBreakingFree = new Performance
            {
                Description = "Queen live at Breaking Free",
                Start = BreakingFree.Start,
                End = BreakingFree.End,
                Status = true,
                Artist = Queen,
                Event = BreakingFree
            };

            Performance BieberFest = new Performance
            {
                Description = "Justin Bieber does stuff",
                Start = TGF.Start,
                End = TGF.End,
                Status = true,
                Artist = JusBie,
                Event = TGF
            };

            Queen.Performances.Add(QueenBreakingFree);
            Queen.Genres.Add(Rock);

            JusBie.Performances.Add(BieberFest);
            JusBie.Genres.Add(Pop);

            BruMar.Genres.Add(Pop);

            BreakingFree.Performances.Add(QueenBreakingFree);
            TGF.Performances.Add(BieberFest);

            Rock.Artists.Add(Queen);
            Pop.Artists.Add(JusBie);
            Pop.Artists.Add(BruMar);

            context.Genres.AddOrUpdate(Rock);
            context.Genres.AddOrUpdate(Pop);

            //context.Locations.AddOrUpdate();
            //context.Artists.AddOrUpdate();
            //context.Events.AddOrUpdate();
            //context.Performances.AddOrUpdate();

            context.SaveChanges();
        }
    }
}
