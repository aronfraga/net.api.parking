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
                .FirstOrDefaultAsync(data => data.Id == id && data.Active != false);
            
            check.IsNull(response, "user");
            return response;
        }
        
        public async Task<User> InsertUser(User user){
            check.UserEntry(user);
            var response = await _dbcontext.Users.Where(data => data.Email == user.Email).FirstOrDefaultAsync();
            check.IsRegistered(response, "user");
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }
        
        public async Task<User> UpdateUser(User user){
            check.IsNull(user.Id, "id");
            var UpdateUser = await _dbcontext.Users.Include(data => data.Vehicles).Where(data => data.Id == user.Id).FirstOrDefaultAsync();
            check.IsNull(UpdateUser, "user");

            UpdateUser.FirstName = user.FirstName;
            UpdateUser.LastName = user.LastName;
            UpdateUser.Email = user.Email;
            UpdateUser.Password = user.Password;

            UpdateUser.Vehicles.Clear();

            foreach (var item in user.Vehicles) {
                UpdateUser.Vehicles.Add(item);
            }

            await _dbcontext.SaveChangesAsync();
            return UpdateUser;
        }
        
        public async Task<bool> DeleteUser(int id){
            check.IsNull(id, "id");
            var DeleteUser = await _dbcontext.Users.Where(data => data.Id == id).FirstOrDefaultAsync();
            
            DeleteUser.Active = false;
            
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
