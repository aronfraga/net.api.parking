using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Repositories;
using ParkingApp.Data;

namespace ParkingApp.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        
        private readonly IUserRepository _userRepository;
        
        public AccountController(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            return Ok(await _userRepository.GetAllUsers());
        }

    }
}
