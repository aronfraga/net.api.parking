using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data.Repositories;
using ParkingApp.Data;
using ParkingApp.Model;

namespace ParkingApp.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {

        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            try {
                var response = await _userRepository.GetAllUsers();
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUser(int id) {
            try {
                var response = await _userRepository.GetOneUser(id);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] User user) {
            try {
                var response = await _userRepository.InsertUser(user);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user) {
            try {
                var response = await _userRepository.UpdateUser(user);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            try {
                var response = await _userRepository.DeleteUser(id);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

    }
}
