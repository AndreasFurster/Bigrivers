using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Bigrivers.Server.Model;
using Bigrivers.Server.Data;
using System;

namespace Bigrivers.Server.Webservice.Controllers
{
    // default way to reach this controller is:
    // localhost/api/Artist/Index
    public class ArtistController : ApiController
    {
        [HttpGet]
        public List<Artist> Index()
        {
            Artist art = new Artist();
            art.Description = "Dit is een voorbeeldje.";


            Performance perf = new Performance
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Status = true,
                Description = "Descr"
            };

            perf.Artist = art;
            perf.Event = null;

            art.Performances = new List<Performance>();
            art.Performances.Add(perf);


            using (BigriversDb ctx = new BigriversDb())
            {
                ctx.Artists.Add(art);
                ctx.SaveChanges();
                return ctx.Artists
                    .Where(a => a.Status)
                    .ToList();
            }
        }
    }
}
