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
    builder.EntitySet<Genre>("Genres");
    builder.EntitySet<Artist>("Artists"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class GenresController : ODataController
    {
        private readonly BigriversDb db = new BigriversDb();
        // GET: odata/Genres
        [EnableQuery]
        public IQueryable<Genre> GetGenres()
        {
            return db.Genres;
        }

        // GET: odata/Genres(5)
        [EnableQuery]
        public SingleResult<Genre> GetGenre([FromODataUri] int key)
        {
            return SingleResult.Create(db.Genres.Where(genre => genre.Id == key));
        }

        // PUT: odata/Genres(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Genre> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = db.Genres.Find(key);
            if (genre == null)
            {
                return NotFound();
            }

            patch.Put(genre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(genre);
        }

        // POST: odata/Genres
        public IHttpActionResult Post(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genres.Add(genre);
            db.SaveChanges();

            return Created(genre);
        }

        // PATCH: odata/Genres(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Genre> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = db.Genres.Find(key);
            if (genre == null)
            {
                return NotFound();
            }

            patch.Patch(genre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(genre);
        }

        // DELETE: odata/Genres(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var genre = db.Genres.Find(key);
            if (genre == null)
            {
                return NotFound();
            }

            db.Genres.Remove(genre);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Genres(5)/Artists
        [EnableQuery]
        public IQueryable<Artist> GetArtists([FromODataUri] int key)
        {
            return db.Genres.Where(m => m.Id == key).SelectMany(m => m.Artists);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreExists(int key)
        {
            return db.Genres.Count(e => e.Id == key) > 0;
        }
    }
}