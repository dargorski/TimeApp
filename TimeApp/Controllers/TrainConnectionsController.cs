using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TimeApp.Models;

namespace TimeApp.Controllers
{
    public class TrainConnectionsController : ApiController
    {
        private TimeAppContext db = new TimeAppContext();

        // GET: api/TrainConnections
        public IQueryable<TrainConnection> GetTrainConnections()
        {
            return db.TrainConnections;
        }

        // GET: api/TrainConnections/5
        [ResponseType(typeof(TrainConnection))]
        public async Task<IHttpActionResult> GetTrainConnection(int id)
        {
            TrainConnection trainConnection = await db.TrainConnections.FindAsync(id);
            if (trainConnection == null)
            {
                return NotFound();
            }

            return Ok(trainConnection);
        }

        // PUT: api/TrainConnections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainConnection(int id, TrainConnection trainConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainConnection.Id)
            {
                return BadRequest();
            }

            db.Entry(trainConnection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainConnectionExists(id))
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

        // POST: api/TrainConnections
        [ResponseType(typeof(TrainConnection))]
        public async Task<IHttpActionResult> PostTrainConnection(TrainConnection trainConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainConnections.Add(trainConnection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainConnection.Id }, trainConnection);
        }

        // DELETE: api/TrainConnections/5
        [ResponseType(typeof(TrainConnection))]
        public async Task<IHttpActionResult> DeleteTrainConnection(int id)
        {
            TrainConnection trainConnection = await db.TrainConnections.FindAsync(id);
            if (trainConnection == null)
            {
                return NotFound();
            }

            db.TrainConnections.Remove(trainConnection);
            await db.SaveChangesAsync();

            return Ok(trainConnection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainConnectionExists(int id)
        {
            return db.TrainConnections.Count(e => e.Id == id) > 0;
        }
    }
}