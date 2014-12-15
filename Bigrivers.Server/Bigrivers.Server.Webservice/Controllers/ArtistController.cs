using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using Bigrivers.Server.Model;
using Bigrivers.Server.Data;


namespace Bigrivers.Server.Webservice.Controllers
{
    // default way to reach this controller is:
    // localhost/api/Artist/Index
    public class ArtistController : ODataController
    {
        BigriversDb _ctx = new BigriversDb();

        [Queryable]
        public Artist GetArtist()
        {

        }

    }
}
