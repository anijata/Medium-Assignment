using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Medium_Assignment.API;

namespace Medium_Assignment.API.Controllers
{
    public class OrganizationsController : ApiController
    {
        private ApplicationDbContext DbContext;

        public OrganizationsController() {
            DbContext = new ApplicationDbContext();

        }

        // GET: api/Organizations
        [ResponseType(typeof(IEnumerable<OrganizationDTO>))]
        public IHttpActionResult GetOrganizations()
        {
            var organizations = DbContext.Organizations.Include(c => c.AspNetUser).ToList();

            var organizationsDTO = organizations.Select(org => new OrganizationDTO(org)).ToList();
            
           return Ok(organizationsDTO);
        }

        // GET: api/Organizations/5
        [ResponseType(typeof(OrganizationDTO))]
        public IHttpActionResult GetOrganization(int id)
        {
            var organization = DbContext.Organizations
                .Where(c => c.Id==id)
                .Include(c => c.AspNetUser)
                .FirstOrDefault();

            if (organization == null)
            {
                return NotFound();
            }

            var organizationsDTO = new OrganizationDTO(organization);

            return Ok(organizationsDTO);
        }

        // PUT: api/Organizations/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrganization(int id, Organization organization)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != organization.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(organization).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrganizationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Organizations
        //[ResponseType(typeof(OrganizationDTO))]
        //public IHttpActionResult PostOrganization(OrganizationDTO organizationDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    DbContext.Organizations.Add(organization);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = organization.Id }, organization);
        //}

        // DELETE: api/Organizations/5
        //[ResponseType(typeof(Organization))]
        //public IHttpActionResult DeleteOrganization(int id)
        //{
        //    Organization organization = db.Organizations.Find(id);
        //    if (organization == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Organizations.Remove(organization);
        //    db.SaveChanges();

        //    return Ok(organization);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool OrganizationExists(int id)
        //{
        //    return db.Organizations.Count(e => e.Id == id) > 0;
        //}
    }
}