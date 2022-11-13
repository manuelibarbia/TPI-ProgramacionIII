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
                List<User> users = _userRepository.GetUsers();
                List<UserResponse> usersList = new();
                foreach (var user in users)
                {
                    UserResponse response = new()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            UserName = user.UserName,
                            DNI = user.DNI,
                            Password = user.Password,
                            Email = user.Email,
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
        [Route("getUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User? user = _userRepository.GetSingleUser(id);
                UserResponse response = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
                    Password = user.Password,
                    Email = user.Email,
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("createUser")]
        public IActionResult CreateUser(AddUserRequest request)
        {
            try
            {
                List<User> users = _userRepository.GetUsers();
                ValidateDNI(users, request.DNI);
                User user = new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.UserName,
                    DNI = request.DNI,
                    Password = request.Password,
                    Email = request.Email
                };
                UserResponse response = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
                    Password = user.Password,
                    Email = user.Email,
                };
                _userRepository.AddUser(user);
                return Created("Usuario creado", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.RemoveUser(id);
                return Ok("Usuario borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("modifyName/{id}/{newName}")]
        public IActionResult ModifyName(int id, string newName)
        {
            try
            {
                _userRepository.EditName(id, newName);
                return Ok("Nombre editado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySurname/{id}/{newSurname}")]
        public IActionResult ModifySurname(int id, string newSurname)
        {
            try
            {
                _userRepository.EditSurname(id, newSurname);
                return Ok("Apellido editado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
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
