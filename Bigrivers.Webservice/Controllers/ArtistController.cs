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

            using (BigriversDb ctx = new BigriversDb())
            {
                l = ctx.Artists.ToList();
            }

            return l;
        }
    }
}
