using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Bigrivers.Server.Model;
using Bigrivers.Server.Data;

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
            Performance perf = new Performance();

            art.Name = "Queen";
            art.Description = "Best group ever (to some people)";

            art.Performances = new List<Performance>();
            art.Performances.Add(perf);

            perf.Start = DateTime.Now;
            perf.End = DateTime.Now.AddDays(1);
            perf.Status = true;
            perf.Description = "Descr";

            perf.Artist = art;
            perf.Event = null;


            using (BigriversDb ctx = new BigriversDb())
            {
                ctx.Artists.Add(art);
                ctx.Performances.Add(perf);
                ctx.SaveChanges();

                List<Artist> artists = ctx.Artists
                    .Include(a => a.Performances)
                    .Where(a => a.Status)
                    .ToList();

                return artists;
            }
        }
    }
}
