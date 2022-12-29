using Azure;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.Data.Repositories;
using ParkingApp.Model;
using ParkingApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data {   
    public class UserRepository : IUserRepository {

        public readonly Context _dbcontext;
        Checker check = new Checker();

        public UserRepository(Context dbcontext){
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            return await _dbcontext.Users
                .Include(data => data.Vehicles)
                .Where(data => data.Active == true)
                .ToListAsync();
        }
        
        public async Task<User> GetOneUser(int id){
            var response =  await _dbcontext.Users
                .AsNoTracking()
                .Include(data => data.Vehicles)
                .FirstOrDefaultAsync(data => data.Id == id);
            
            check.IsNull(response, "user");
            return response;
        }
        
        public async Task<User> InsertUser(User user){
            check.UserEntry(user);
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }
        
        public async Task<User> UpdateUser(User user){
            check.IsNull(user.Id, "id");
            var UserToUpdate = await GetOneUser(user.Id);           
            check.IsNull(UserToUpdate, "user");
            check.UserEntry(user);          
            
            _dbcontext.Users.Update(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }
        
        public async Task<bool> DeleteUser(int id){
            check.IsNull(id, "id");
            var response = await _dbcontext.Users
                .AsNoTracking()
                .Include(data => data.Vehicles)
                .FirstOrDefaultAsync(data => data.Id == id);

            _dbcontext.Users.Update(response);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
