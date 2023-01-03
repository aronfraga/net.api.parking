using ParkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data.Repositories {
    public interface ISpotRepository {

        Task<IEnumerable<Spot>> GetSpotStatus();
        Task<string> CreateSpot(int id);
        Task<string> UpdateSpot(int id, bool status);
        //Task<Spot> DeleteSpot(int id);

    }
}
