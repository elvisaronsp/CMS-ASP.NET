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
using CMS.Models;
using Data;
using CMS.DataServices.Contracts;

namespace CMS.API.Controllers
{
    public class MenuLocationsController : ApiController
    {
        private readonly IMenuLocationService db;

        public MenuLocationsController(IMenuLocationService menuLocations)
        {
            db = menuLocations;
        }

        // GET: api/MenuLocations
        public IQueryable<MenuLocation> GetMenuLocations()
        {
            return db.All();
        }

        // GET: api/MenuLocations/5
        [ResponseType(typeof(MenuLocation))]
        public IHttpActionResult GetMenuLocation(Guid id)
        {
            MenuLocation menuLocation = db.GetById(id);
            if (menuLocation == null)
            {
                return NotFound();
            }

            return Ok(menuLocation);
        }

        // PUT: api/MenuLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenuLocation(Guid id, MenuLocation menuLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuLocation.Id)
            {
                return BadRequest();
            }
            
            try
            {
                this.db.Update(menuLocation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuLocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MenuLocations
        [ResponseType(typeof(MenuLocation))]
        public IHttpActionResult PostMenuLocation(MenuLocation menuLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            try
            {
                db.Add(menuLocation);
            }
            catch (DbUpdateException)
            {
                if (MenuLocationExists(menuLocation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = menuLocation.Id }, menuLocation);
        }

        // DELETE: api/MenuLocations/5
        [ResponseType(typeof(MenuLocation))]
        public IHttpActionResult DeleteMenuLocation(Guid id)
        {
            
            db.Delete(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuLocationExists(Guid id)
        {
            return db.GetById(id) != null;
        }
    }
}