using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParkingApp.Model {
    public class Vehicle {

        public Vehicle(){
            this.Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Plate { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

    }
}
