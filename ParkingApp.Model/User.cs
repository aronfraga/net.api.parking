using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParkingApp.Model {
    public class User {
        public User(){
            this.Vehicles = new HashSet<Vehicle>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonInclude]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
