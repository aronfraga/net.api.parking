using Microsoft.EntityFrameworkCore;
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
            return await _dbcontext.Users.Include(data => data.Vehicles).ToListAsync();
        }
        
        public async Task<User> GetOneUser(int id){
            return await _dbcontext.Users.FindAsync(id);
        }
        
        public async Task<User> InsertUser(User user){
            check.UserEntry(user);
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }
        /*
        Task<bool> IUserRepository.UpdateUser(){
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteUser(){
            throw new NotImplementedException();
        }*/
    }
}
