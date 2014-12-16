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
    builder.EntitySet<Performance>("Performances");
    builder.EntitySet<Artist>("Artists"); 
    builder.EntitySet<Event>("Events"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class PerformancesController : ODataController
    {
        private readonly BigriversDb _db = new BigriversDb();
        // GET: odata/Performances
        [EnableQuery]
        public IQueryable<Performance> GetPerformances()
        {
            return _db.Performances;
        }

        // GET: odata/Performances(5)
        [EnableQuery]
        public SingleResult<Performance> GetPerformance([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Performances.Where(performance => performance.Id == key));
        }

        // PUT: odata/Performances(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Performance> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performance = _db.Performances.Find(key);
            if (performance == null)
            {
                return NotFound();
            }

            patch.Put(performance);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformanceExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(performance);
        }

        // POST: odata/Performances
        public IHttpActionResult Post(Performance performance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Performances.Add(performance);
            _db.SaveChanges();

            return Created(performance);
        }

        // PATCH: odata/Performances(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Performance> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performance = _db.Performances.Find(key);
            if (performance == null)
            {
                return NotFound();
            }

            patch.Patch(performance);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformanceExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(performance);
        }

        // DELETE: odata/Performances(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var performance = _db.Performances.Find(key);
            if (performance == null)
            {
                return NotFound();
            }

            _db.Performances.Remove(performance);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Performances(5)/Artist
        [EnableQuery]
        public SingleResult<Artist> GetArtist([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Performances.Where(m => m.Id == key).Select(m => m.Artist));
        }

        // GET: odata/Performances(5)/Event
        [EnableQuery]
        public SingleResult<Event> GetEvent([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Performances.Where(m => m.Id == key).Select(m => m.Event));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerformanceExists(int key)
        {
            return _db.Performances.Count(e => e.Id == key) > 0;
        }
    }
}