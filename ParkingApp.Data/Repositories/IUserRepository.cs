using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Model;

namespace ParkingApp.Data.Repositories {
    
    public interface IUserRepository {

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetOneUser(int id);
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);

    }

}