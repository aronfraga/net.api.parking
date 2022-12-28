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

        public UserRepository(Context dbcontext){
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<User>> GetAllUsers(){
            return await _dbcontext.Users.Include(data => data.Vehicles).ToListAsync();
        }
        /*
        protected Context dbContext(){
            return _dbcontext;
        }

        Task<User> IUserRepository.GetOneUser(){
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.InsertUser(){
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.UpdateUser(){
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteUser(){
            throw new NotImplementedException();
        }*/
    }
}
