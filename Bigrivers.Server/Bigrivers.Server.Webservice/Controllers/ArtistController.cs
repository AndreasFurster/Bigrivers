using System.Data.Entity;
using System.Linq;
using System.Web.OData;
using Bigrivers.Server.Data;
using Bigrivers.Server.Model;

namespace Bigrivers.Server.Webservice.Controllers
{
    // default way to reach this controller is:
    // localhost/api/Artist/Index
    public class ArtistController : ODataController
    {
        private readonly BigriversDb _ctx = new BigriversDb();

        [EnableQuery]
        public IQueryable<Artist> GetArtist()
        {
            return _ctx.Artists
                .Include(a => a.Performances)
                .Include(a => a.Genres);
        }
    }
}