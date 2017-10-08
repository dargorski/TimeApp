using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeApp.Controllers
{
    public class TrainConnectionDTO
    {
        public string TrainId { get; set; }
        public Boolean leaf { get; set; }
        public List<TrainConnectionItemDTO> children { get; set; }



    }
}