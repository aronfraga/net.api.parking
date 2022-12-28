using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParkingApp.Model {
    public class Spot {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GarageId { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
