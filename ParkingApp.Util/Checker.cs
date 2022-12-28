using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Model;

namespace ParkingApp.Util {
    
    public class Checker {

        public void UserEntry(User user){

            if (user.Email == null || user.Email is not string)
                throw new Exception("The email cannot be empty and must be a string");

            if (!new EmailAddressAttribute().IsValid(user.Email))
                throw new Exception("The email is not correct");

            if (user.Password == null || user.Password is not string)
                throw new Exception("The password cannot be empty and must be a string");

            if (user.FirstName == null || user.FirstName is not string)
                throw new Exception("The first name cannot be empty and must be a string");

            if (user.LastName == null || user.LastName is not string)
                throw new Exception("The last name cannot be empty and must be a string");

        }

    }

}
