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
        [Route("getOne/{id}")]
        public IActionResult GetSingleUser(int id)
        {
            try
            {
                User? user = _userRepository.GetOne(id);
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
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
                    Password = user.Password,
                    Email = user.Email,
                };
                _userRepository.Add(user);
                return Created("Usuario creado", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removeUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok("Usuario borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("modifyName")]
        public IActionResult ModifyName(int id, string newName)
        {
            try
            {
                _userRepository.ModifyName(id, newName);
                return Ok("Nombre editado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySurname")]
        public IActionResult ModifySurname(int id, string newSurname)
        {
            try
            {
                _userRepository.ModifySurname(id, newSurname);
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
