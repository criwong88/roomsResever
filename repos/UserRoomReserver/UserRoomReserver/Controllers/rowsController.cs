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
    public class rowsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/rows
        public IQueryable<rowsReserve> GetrowsReserve()
        {
            return db.rowsReserve;
        }

        // GET: api/rows/5
        [ResponseType(typeof(rowsReserve))]
        public IHttpActionResult GetrowsReserve(int id)
        {
            rowsReserve rowsReserve = db.rowsReserve.Find(id);
            if (rowsReserve == null)
            {
                return NotFound();
            }

            return Ok(rowsReserve);
        }

        // PUT: api/rows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutrowsReserve(int id, rowsReserve rowsReserve)
        {


            if (id != rowsReserve.id)
            {
                return BadRequest();
            }

            db.Entry(rowsReserve).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rowsReserveExists(id))
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

        // POST: api/rows
        [ResponseType(typeof(rowsReserve))]
        public IHttpActionResult PostrowsReserve(rowsReserve rowsReserve)
        {

            db.rowsReserve.Add(rowsReserve);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rowsReserve.id }, rowsReserve);
        }

        // DELETE: api/rows/5
        [ResponseType(typeof(rowsReserve))]
        public IHttpActionResult DeleterowsReserve(int id)
        {
            rowsReserve rowsReserve = db.rowsReserve.Find(id);
            if (rowsReserve == null)
            {
                return NotFound();
            }

            db.rowsReserve.Remove(rowsReserve);
            db.SaveChanges();

            return Ok(rowsReserve);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool rowsReserveExists(int id)
        {
            return db.rowsReserve.Count(e => e.id == id) > 0;
        }
    }
}