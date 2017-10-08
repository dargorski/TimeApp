using Newtonsoft.Json.Linq;
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
        public TrainConnectionDTO GetTrainConnections()
        {
            List<TrainConnectionItemDTO> itemList = new List<TrainConnectionItemDTO>();

            DbSet<TrainConnection> results = db.TrainConnections;
            foreach (TrainConnection trainConnection in results)
            {
                List<TrainConnectionItemDTO> stations = new List<TrainConnectionItemDTO>();
                foreach (Station station in trainConnection.Stations)
                {
                    stations.Add(new TrainConnectionItemDTO() { TrainId = -station.Id, Station = station.Name, ArrivalTime = station.ArrivalTime?.ToString("HH:mm"), DepartureTime = station.DepartureTime?.ToString("HH:mm"), leaf = true });
                }

                String route = trainConnection.Start + " - " + trainConnection.Destination;
                TrainConnectionItemDTO item = new TrainConnectionItemDTO() { TrainId = trainConnection.Id, TrainName = trainConnection.Name, Route = route, Type = trainConnection.ConnectionType.ToString(), leaf = false, children = stations };
                itemList.Add(item);
            }

            TrainConnectionDTO dto = new TrainConnectionDTO() { TrainId = "root", leaf = false, children = itemList };

            return dto;

        }

        // POST: api/TrainConnections
        [ResponseType(typeof(TrainConnection))]
        public IHttpActionResult PostTrainConnection(TrainConnection trainConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainConnections.Add(trainConnection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainConnection.Id }, trainConnection);
        }

        // DELETE: api/TrainConnections/
        [ResponseType(typeof(TrainConnection))]
        public IHttpActionResult DeleteTrainConnection([FromBody]Object idObject)
        {

            int id;

            if (idObject.GetType() == typeof(JObject))
            {
                JObject jsonObject = (JObject)idObject;
                id = (int)jsonObject.GetValue("TrainId");
            }
            else
            {
                JArray jsonArray = (JArray)idObject;
                JToken jsonToken = jsonArray[0];
                id = (int)jsonToken["TrainId"];
            }

            TrainConnection trainConnection = db.TrainConnections.Find(id);
            if (trainConnection == null)
            {
                return NotFound();
            }

            db.TrainConnections.Remove(trainConnection);
            db.SaveChanges();

            return Ok(trainConnection);

        }

    }
}
