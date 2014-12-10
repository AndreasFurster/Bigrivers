using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Bigrivers.Model;
using Bigrivers.Data;

namespace Bigrivers.Webservice.Controllers
{
    // default way to reach this controller is:
    // localhost/api/Artist/Index
    public class ArtistController : ApiController
    {
        [HttpGet]
        public List<Artist> Index()
        {
            List<Artist> l = new List<Artist>();

            Artist a = new Artist(1, "U2");
            a.AddMessage("U2 rocks...");
            Artist b = new Artist(2, "Sting");
            b.AddMessage("New album in 2015?!");
            b.AddMessage("Best artist ever.");
            Artist c = new Artist(3, "Pearl Jam");

            l.Add(a);
            l.Add(b);
            l.Add(c);

            using (BigriversDb x = new BigriversDb())
            {
                x.Artists.Add(a);
                x.Artists.Add(b);
                x.Artists.Add(c);
                x.SaveChanges();
            }

            return l;
        }
    }
}
