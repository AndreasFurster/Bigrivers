using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using Bigrivers.Server.Data;
using Bigrivers.Server.Model;

namespace Bigrivers.Server.Webservice.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Bigrivers.Server.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Artist>("Artists");
    builder.EntitySet<Genre>("Genres"); 
    builder.EntitySet<Performance>("Performances"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class ArtistsController : ODataController
    {
        private readonly BigriversDb _db = new BigriversDb();
        // GET: odata/Artists
        [EnableQuery]
        public IQueryable<Artist> GetArtists()
        {
            return _db.Artists;
        }

        // GET: odata/Artists(5)
        [EnableQuery]
        public SingleResult<Artist> GetArtist([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Artists.Where(artist => artist.Id == key));
        }

        // PUT: odata/Artists(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Artist> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artist = _db.Artists.Find(key);
            if (artist == null)
            {
                return NotFound();
            }

            patch.Put(artist);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(artist);
        }

        // POST: odata/Artists
        public IHttpActionResult Post(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Artists.Add(artist);
            _db.SaveChanges();

            return Created(artist);
        }

        // PATCH: odata/Artists(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Artist> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artist = _db.Artists.Find(key);
            if (artist == null)
            {
                return NotFound();
            }

            patch.Patch(artist);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(artist);
        }

        // DELETE: odata/Artists(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var artist = _db.Artists.Find(key);
            if (artist == null)
            {
                return NotFound();
            }

            _db.Artists.Remove(artist);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Artists(5)/Genres
        [EnableQuery]
        public IQueryable<Genre> GetGenres([FromODataUri] int key)
        {
            return _db.Artists.Where(m => m.Id == key).SelectMany(m => m.Genres);
        }

        // GET: odata/Artists(5)/Performances
        [EnableQuery]
        public IQueryable<Performance> GetPerformances([FromODataUri] int key)
        {
            return _db.Artists.Where(m => m.Id == key).SelectMany(m => m.Performances);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int key)
        {
            return _db.Artists.Count(e => e.Id == key) > 0;
        }
    }
}