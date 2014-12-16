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
    builder.EntitySet<Location>("Locations");
    builder.EntitySet<Event>("Events"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class LocationsController : ODataController
    {
        private readonly BigriversDb _db = new BigriversDb();
        // GET: odata/Locations
        [EnableQuery]
        public IQueryable<Location> GetLocations()
        {
            return _db.Locations;
        }

        // GET: odata/Locations(5)
        [EnableQuery]
        public SingleResult<Location> GetLocation([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Locations.Where(location => location.Id == key));
        }

        // PUT: odata/Locations(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Location> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = _db.Locations.Find(key);
            if (location == null)
            {
                return NotFound();
            }

            patch.Put(location);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(location);
        }

        // POST: odata/Locations
        public IHttpActionResult Post(Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Locations.Add(location);
            _db.SaveChanges();

            return Created(location);
        }

        // PATCH: odata/Locations(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Location> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var location = _db.Locations.Find(key);
            if (location == null)
            {
                return NotFound();
            }

            patch.Patch(location);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(location);
        }

        // DELETE: odata/Locations(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var location = _db.Locations.Find(key);
            if (location == null)
            {
                return NotFound();
            }

            _db.Locations.Remove(location);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Locations(5)/Events
        [EnableQuery]
        public IQueryable<Event> GetEvents([FromODataUri] int key)
        {
            return _db.Locations.Where(m => m.Id == key).SelectMany(m => m.Events);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocationExists(int key)
        {
            return _db.Locations.Count(e => e.Id == key) > 0;
        }
    }
}