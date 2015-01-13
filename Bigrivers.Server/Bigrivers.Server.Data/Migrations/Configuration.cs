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
            Genre Techno = new Genre
            {
                Name = "Techno",
                Artists = new List<Artist>()
            };
            Genre Metal = new Genre
            {
                Name = "Metal",
                Artists = new List<Artist>()
            };
            Genre Klassiek = new Genre
            {
                Name = "Klassiek",
                Artists = new List<Artist>()
            };
            Genre Nederlands = new Genre
            {
                Name = "Nederlands",
                Artists = new List<Artist>()
            };
            Genre KPop = new Genre
            {
                Name = "K-Pop",
                Artists = new List<Artist>()
            };

            // Create Location
            Location Sterrenburg = new Location
            {
                Street = "Dordtsestraat",
                Zipcode = "1234 CS",
                City = "Dordrecht",
                Stagename = "Sterrenburg Stage",
                Status = true,
                Events = new List<Event>()
            };
            Location LPP = new Location
            {
                Street = "Leerparkpromenade",
                Zipcode = "5643 LP",
                City = "Dordrecht",
                Stagename = "Davinci Stage",
                Status = true,
                Events = new List<Event>()
            };
            Location Haven = new Location
            {
                Street = "Dordtsehaven",
                Zipcode = "5565 CS",
                City = "Dordrecht",
                Stagename = "Haven Stage",
                Status = true,
                Events = new List<Event>()
            };
            Location DordtCentraal = new Location
            {
                Street = "Dordt Centraal",
                Zipcode = "3240 JS",
                City = "Dordrecht",
                Stagename = "Jonkheer Stage",
                Status = true,
                Events = new List<Event>()
            };

            // Create Artists
            Artist Queen = new Artist
            {
                Name = "Queen",
                Description = "Queen is een Engelse rockgroep. De band is opgericht in 1970 in Londen door gitarist Brian May, zanger Freddie Mercury en drummer Roger Taylor, aangevuld met bassist John Deacon in 1971. Met tientallen hits in de jaren 70, 80 en 90, is Queen een van de succesvolste popgroepen in de geschiedenis.",
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
                Description = "Justin Bieber is een Canadees zanger. Hij begon als kleuter met drummen en gitaarspelen en zong voor het eerst in het openbaar toen hij twaalf jaar oud was. Twee jaar later, nadat hij aan de hand van een video op YouTube was ontdekt, tekende hij zijn eerste platencontract, en groeide vervolgens uit tot een tieneridool.",
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
                Description = "Peter Hernandez, beter bekend als Bruno Mars, is een Amerikaans zanger, schrijver en muziekproducent.",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/ElektraRecords",
                Website = "http://www.brunomars.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Psy = new Artist
            {
                Name = "Psy",
                Description = "Psy - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/Psyofficial",
                Website = "http://www.psyofficial.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Coldplay = new Artist
            {
                Name = "Coldplay",
                Description = "Coldplay - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/ColdplayVEVO",
                Website = "http://www.coldplay.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist NicSim = new Artist
            {
                Name = "Nick & Simon",
                Description = "Nick & Simon - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/NickSimonNL",
                Website = "http://www.nicksimon.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Jamai = new Artist
            {
                Name = "Jamai",
                Description = "Jamai - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/JamaiNL",
                Website = "http://www.jamainl.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist BluesBros = new Artist
            {
                Name = "Blues Brothers",
                Description = "The Blues Brothers, more formally called The Blues Brothers' Show Band and Revue, are an American blues and rhythm and blues revivalist band founded in 1978 by comedy actors Dan Aykroyd and John Belushi as part of a musical sketch on Saturday Night Live",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/BluesBrothers",
                Website = "http://www.bluesbrothers.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist ArmVBuu = new Artist
            {
                Name = "Armin Van Buuren",
                Description = "Armin van Buuren - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/arminvanbuuren",
                Website = "http://www.arminvanbuuren.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Bastille = new Artist
            {
                Name = "Bastille",
                Description = "Bastille - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/Bastille",
                Website = "http://www.Bastille.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist FooFight = new Artist
            {
                Name = "Foo Fighters",
                Description = "Foo Fighters - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/FooFighters",
                Website = "http://www.FooFighters.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist NieGeu = new Artist
            {
                Name = "Niels Geusebroek",
                Description = "Niels Geusebroek - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/NielsGeusebroek",
                Website = "http://www.nielsgeusebroek.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Pitbull = new Artist
            {
                Name = "Pitbull",
                Description = "Pitbull - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/PitbullVEVO",
                Website = "http://www.pitbullmusic.com/",
                Facebook = null,
                Twitter = null,
                Status = true,
                Performances = new List<Performance>(),
                Genres = new List<Genre>()
            };
            Artist Script = new Artist
            {
                Name = "The Script",
                Description = "The Script - Beschrijving",
                Avatar = null,
                YoutubeChannel = "https://www.youtube.com/user/Jeroenvdboom",
                Website = "http://www.jeroenboom.com/",
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
                Description = "Music for the younger girls, like Justin Bieber and One Direction",
                ShortDescription = "Music for the younger girls",
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
                Location = Sterrenburg
            };
            Event BigEverything = new Event
            {
                Title = "BigEverything",
                Description = "All kinds of unrelated music stuffed together! Cause why not?",
                ShortDescription = "All kinds of unrelated music!",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
            };
            Event BreakingFree = new Event
            {
                Title = "Breaking Free",
                Description = "All kinds of 60's and 70's music, with a main act from Queen!",
                ShortDescription = "All kinds of 60's and 70's music",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
            };
            Event DutchParty = new Event
            {
                Title = "Dutch Party",
                Description = "Nederlandse artiesten zoals Jeroen vd Boom, Nick & Simon bij elkaar!",
                ShortDescription = "Nederlandse artiesten bij elkaar!",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
            };

            Event LiveDance = new Event
            {
                Title = "Live Dance",
                Description = "Dancing music on the big stage!",
                ShortDescription = "Dancing music!",
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(2),
                Price = 13.37m,
                TicketRequired = true,
                Status = true,
                Performances = new List<Performance>(),
            };


            // Create Performances
            Performance QueenBreakingFreeP1 = new Performance
            {
                Description = "Queen live at Breaking Free",
                Start = BreakingFree.Start.AddDays(30),
                End = BreakingFree.Start.AddDays(30).AddHours(1),
                Status = true,
                Artist = Queen,
                Event = BreakingFree
            };
            Performance BluesBrosBreakingFree = new Performance()
            {
                Description = "Blues Brothers at Breaking Free event",
                Start = QueenBreakingFreeP1.End,
                End = QueenBreakingFreeP1.End.AddHours(0.5),
                Status = true,
                Artist = BluesBros,
                Event = BreakingFree
            };
            Performance QueenBreakingFreeP2 = new Performance
            {
                Description = "Queen live at Breaking Free for the second time the evening",
                Start = BluesBrosBreakingFree.End,
                End = BluesBrosBreakingFree.End.AddHours(1.5),
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

            Queen.Performances.Add(QueenBreakingFreeP1);
            Queen.Genres.Add(Rock);

            JusBie.Performances.Add(BieberFest);
            JusBie.Genres.Add(Pop);

            BruMar.Genres.Add(Pop);

            Script.Genres.Add(Pop);

            BluesBros.Genres.Add(Blues);



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
