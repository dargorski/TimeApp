using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeApp.Models
{
    public class TrainConnection
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Start { get; set; }

        [Required]
        public String Destination { get; set; }

        [Required]
        public TrainConnectionType ConnectionType { get; set; }

        [JsonIgnore]
        public virtual ICollection<Station> Stations { get; set; }
    }
}