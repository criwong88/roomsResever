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
    public class roomsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/rooms
        public IQueryable<rooms> Getrooms()
        {
            return db.rooms;
        }

        // GET: api/rooms/5
        [ResponseType(typeof(rooms))]
        public IHttpActionResult Getrooms(int id)
        {
            rooms rooms = db.rooms.Find(id);
            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        // PUT: api/rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrooms(int id, rooms rooms)
        {

            if (id != rooms.id)
            {
                return BadRequest();
            }

            db.Entry(rooms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomsExists(id))
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

        // POST: api/rooms
        [ResponseType(typeof(rooms))]
        public IHttpActionResult Postrooms(rooms rooms)
        {

            db.rooms.Add(rooms);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rooms.id }, rooms);
        }

        // DELETE: api/rooms/5
        [ResponseType(typeof(rooms))]
        public IHttpActionResult Deleterooms(int id)
        {
            rooms rooms = db.rooms.Find(id);
            if (rooms == null)
            {
                return NotFound();
            }

            db.rooms.Remove(rooms);
            db.SaveChanges();

            return Ok(rooms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool roomsExists(int id)
        {
            return db.rooms.Count(e => e.id == id) > 0;
        }
    }
}