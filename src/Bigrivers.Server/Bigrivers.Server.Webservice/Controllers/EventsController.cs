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
    builder.EntitySet<Event>("Events");
    builder.EntitySet<Location>("Locations"); 
    builder.EntitySet<Performance>("Performances"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class EventsController : ODataController
    {
        private readonly BigriversDb _db = new BigriversDb();
        // GET: odata/Events
        [EnableQuery]
        public IQueryable<Event> GetEvents()
        {
            return _db.Events;
        }

        // GET: odata/Events(5)
        [EnableQuery]
        public SingleResult<Event> GetEvent([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Events.Where(@event => @event.Id == key));
        }

        // PUT: odata/Events(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Event> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = _db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            patch.Put(@event);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(@event);
        }

        // POST: odata/Events
        public IHttpActionResult Post(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Events.Add(@event);
            _db.SaveChanges();

            return Created(@event);
        }

        // PATCH: odata/Events(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Event> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = _db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            patch.Patch(@event);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(@event);
        }

        // DELETE: odata/Events(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var @event = _db.Events.Find(key);
            if (@event == null)
            {
                return NotFound();
            }

            _db.Events.Remove(@event);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Events(5)/Location
        [EnableQuery]
        public SingleResult<Location> GetLocation([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Events.Where(m => m.Id == key).Select(m => m.Location));
        }

        // GET: odata/Events(5)/Performances
        [EnableQuery]
        public IQueryable<Performance> GetPerformances([FromODataUri] int key)
        {
            return _db.Events.Where(m => m.Id == key).SelectMany(m => m.Performances);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int key)
        {
            return _db.Events.Count(e => e.Id == key) > 0;
        }
    }
}