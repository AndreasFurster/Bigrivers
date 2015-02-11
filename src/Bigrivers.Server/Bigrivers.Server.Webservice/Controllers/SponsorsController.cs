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
    builder.EntitySet<Sponsor>("Sponsors");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class SponsorsController : ODataController
    {
        private readonly BigriversDb _db = new BigriversDb();
        // GET: odata/Sponsors
        [EnableQuery]
        public IQueryable<Sponsor> GetSponsors()
        {
            return _db.Sponsors;
        }

        // GET: odata/Sponsors(5)
        [EnableQuery]
        public SingleResult<Sponsor> GetSponsor([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Sponsors.Where(sponsor => sponsor.Id == key));
        }

        // PUT: odata/Sponsors(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Sponsor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sponsor = _db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            patch.Put(sponsor);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(sponsor);
        }

        // POST: odata/Sponsors
        public IHttpActionResult Post(Sponsor sponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Sponsors.Add(sponsor);
            _db.SaveChanges();

            return Created(sponsor);
        }

        // PATCH: odata/Sponsors(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Sponsor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sponsor = _db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            patch.Patch(sponsor);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(sponsor);
        }

        // DELETE: odata/Sponsors(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var sponsor = _db.Sponsors.Find(key);
            if (sponsor == null)
            {
                return NotFound();
            }

            _db.Sponsors.Remove(sponsor);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SponsorExists(int key)
        {
            return _db.Sponsors.Count(e => e.Id == key) > 0;
        }
    }
}