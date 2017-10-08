using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeApp.Controllers
{
    public class TrainConnectionItemDTO
    {
        public int TrainId { get; set; }
        public String TrainName { get; set; }
        public String Route { get; set; }
        public String Type { get; set; }
        public String Station { get; set; }
        public String ArrivalTime { get; set; }
        public String DepartureTime { get; set; }
        public List<TrainConnectionItemDTO> children;
        public Boolean leaf { get; set; }
    }
}