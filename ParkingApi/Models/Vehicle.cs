using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ParkingApi.Models {
    public class Vehicle {

        public int Id { get; set; }
        public string Plate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
