using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeApp.Models
{
    public enum TrainConnectionType { Intercity, Pendolino, Regio };

    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        // Foreign Key               
        public int TrainConnectionId { get; set; }

        // Navigation property       
        [ForeignKey("TrainConnectionId")]

        public TrainConnection TrainConnection { get; set; }
    }
}