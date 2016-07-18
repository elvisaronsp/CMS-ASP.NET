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
using CMS.DataServices;

namespace CMS.API.Controllers
{
    public class MenusController : ApiController
    {
        private readonly IMenuService menu;

        public MenusController(IMenuService menu)
        {
            this.menu = menu;
        }

        // GET: api/Menus
        public IQueryable<Menu> GetMenus()
        {
            return menu.All();
        }

        // GET: api/Menus/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(Guid id)
        {
            Menu menu = this.menu.GetById(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/Menus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenu(Guid id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.Id)
            {
                return BadRequest();
            }
            this.menu.Update(menu);
          
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Menus
        [ResponseType(typeof(Menu))]
        public IHttpActionResult PostMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var menuId =  this.menu.Add(menu);
            
            try
            {
                return this.Ok(menuId);
            }
            catch (DbUpdateException)
            {
                if (MenuExists(menu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

           // return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult DeleteMenu(Guid id)
        {
            if(!menu.Delete(id))
                return NotFound();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                menu.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(Guid id)
        {
            if (menu.GetById(id) != null)
                return true;
            else
                return false;
        }
    }
}