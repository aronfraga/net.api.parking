using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Repositories;
using ParkingApp.Model;
using ParkingApp.Util;

namespace ParkingApp.Data {
    public class SpotRepository : ISpotRepository {

        public readonly Context _dbcontext;
        Checker check = new Checker();

        public SpotRepository(Context dbcontext){
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Spot>> GetSpotStatus() {
            return await _dbcontext.Spots.ToListAsync();
        }

        public async Task<string> CreateSpot(int quantity) { 
            for (int i = 1; i <= quantity; i++) {
                Spot spot = new Spot();
                await _dbcontext.Spots.AddAsync(spot);
                await _dbcontext.SaveChangesAsync();
            }
            return $"There are {quantity} new spots available...";
        }

        public async Task<string> UpdateSpot(int id, bool status) {
            var spot = await _dbcontext.Spots.FindAsync(id);
            check.IsNull(spot, "Spot");
            spot.Status = status;
            await _dbcontext.SaveChangesAsync();
            string SpotStatus = status ? "Available" : "Not Available";
            return $"The status spot {id} was change to {SpotStatus}";
        }

    }
}

