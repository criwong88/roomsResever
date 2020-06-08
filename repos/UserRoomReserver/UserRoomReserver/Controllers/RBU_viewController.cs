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
using UserRoomReserver.Models;

namespace UserRoomReserver.Controllers
{
    public class RBU_viewController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/RBU_view
        public IQueryable<RBU_view> GetRBU_view()
        {
            return db.RBU_view;
        }

        // GET: api/RBU_view/5
        [ResponseType(typeof(RBU_view))]
        public IHttpActionResult GetRBU_view(int id)
        {
            RBU_view rBU_view = db.RBU_view.Find(id);
            if (rBU_view == null)
            {
                return NotFound();
            }

            return Ok(rBU_view);
        }

        // PUT: api/RBU_view/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRBU_view(int id, RBU_view rBU_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rBU_view.id)
            {
                return BadRequest();
            }

            db.Entry(rBU_view).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RBU_viewExists(id))
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

        // POST: api/RBU_view
        [ResponseType(typeof(RBU_view))]
        public IHttpActionResult PostRBU_view(RBU_view rBU_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RBU_view.Add(rBU_view);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RBU_viewExists(rBU_view.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rBU_view.id }, rBU_view);
        }

        // DELETE: api/RBU_view/5
        [ResponseType(typeof(RBU_view))]
        public IHttpActionResult DeleteRBU_view(int id)
        {
            RBU_view rBU_view = db.RBU_view.Find(id);
            if (rBU_view == null)
            {
                return NotFound();
            }

            db.RBU_view.Remove(rBU_view);
            db.SaveChanges();

            return Ok(rBU_view);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RBU_viewExists(int id)
        {
            return db.RBU_view.Count(e => e.id == id) > 0;
        }
    }
}