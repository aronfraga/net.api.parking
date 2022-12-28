using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Model;

namespace ParkingApp.Data.Repositories {
    
    public interface IUserRepository {

        Task<IEnumerable<User>> GetAllUsers();
        //Task<User> GetOneUser();
        //Task<bool> InsertUser();
        //Task<bool> UpdateUser();
        //Task<bool> DeleteUser();
    
    }
}