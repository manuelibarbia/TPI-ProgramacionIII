// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                List<UserResponse> usersList = new();
                foreach (var user in users)
                {
                    UserResponse response = new()
                        {
                            UserName = user.UserName,
                            Id = user.Id,
                            Password = user.Password,
                        };
                    usersList.Add(response);
                }
                return Ok(usersList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getOne/{id}")]
        public IActionResult GetSingleUser(int id)
        {
            User? user = _userRepository.GetOne(id);
            UserResponse response = new()
            {
                Name = user.Name,
                UserName = user.UserName,
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("addUser")]
        public IActionResult AddUser(AddUserRequest dto)
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                ValidateDNI(users, dto.DNI);
                User user = new()
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                    UserName = dto.UserName,
                    DNI = dto.DNI,
                    Password = dto.Password,
                    Email = dto.Email
                };
                UserResponse response = new()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
                    Email = user.Email
                };
                _userRepository.Add(user);
                return Created("Usuario creado", response);
            }
            catch(Exception error)
            {
                return Problem(error.Message);
            }
        }

        [HttpDelete]
        [Route("removeUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("Usuario borrado");
        }

        [NonAction]
        public void ValidateDNI(List<User> users, string DNI)
        {
            var inUse = users.FirstOrDefault(u => u.DNI == DNI);
            if (inUse != null)
            {
                throw new Exception("DNI ya registrado");
            }
        }
    }
}
