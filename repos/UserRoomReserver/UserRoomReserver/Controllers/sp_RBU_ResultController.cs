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
    public class sp_RBU_ResultController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/sp_RBU_Result
        public IQueryable<sp_RBU_Result> Getsp_RBU_Result()
        {
            return db.sp_RBU_Result;
        }

        // GET: api/sp_RBU_Result/5
        [ResponseType(typeof(sp_RBU_Result))]
        public IHttpActionResult Getsp_RBU_Result(int id)
        {
            sp_RBU_Result sp_RBU_Result = db.sp_RBU_Result.Find(id);
            if (sp_RBU_Result == null)
            {
                return NotFound();
            }

            return Ok(sp_RBU_Result);
        }

        // PUT: api/sp_RBU_Result/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsp_RBU_Result(int id, sp_RBU_Result sp_RBU_Result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sp_RBU_Result.id)
            {
                return BadRequest();
            }

            db.Entry(sp_RBU_Result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sp_RBU_ResultExists(id))
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

        // POST: api/sp_RBU_Result
        [ResponseType(typeof(sp_RBU_Result))]
        public IHttpActionResult Postsp_RBU_Result(sp_RBU_Result sp_RBU_Result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sp_RBU_Result.Add(sp_RBU_Result);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sp_RBU_Result.id }, sp_RBU_Result);
        }

        // DELETE: api/sp_RBU_Result/5
        [ResponseType(typeof(sp_RBU_Result))]
        public IHttpActionResult Deletesp_RBU_Result(int id)
        {
            sp_RBU_Result sp_RBU_Result = db.sp_RBU_Result.Find(id);
            if (sp_RBU_Result == null)
            {
                return NotFound();
            }

            db.sp_RBU_Result.Remove(sp_RBU_Result);
            db.SaveChanges();

            return Ok(sp_RBU_Result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sp_RBU_ResultExists(int id)
        {
            return db.sp_RBU_Result.Count(e => e.id == id) > 0;
        }
    }
}