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
        [HttpPost]
        public IActionResult AddUser(AddUserRequest dto)
        {
            try
            {
                List<User> users = _userRepository.GetAll();
                User user = new User()
                {
                    Id = users.Max(x => x.Id) + 1,
                    Password = dto.Password,
                    UserName = dto.UserName,
                };
                _userRepository.Add(user);
                UserResponse response = new UserResponse()
                {
                    UserName = dto.UserName,
                    Id = user.Id,
                };
                return Created("Sucessfully created", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<User> users = _userRepository.GetAll();
                List<UserResponse> response = new List<UserResponse>();
                foreach (var user in users)
                {
                    response.Add(
                        new UserResponse()
                        {
                            UserName = user.UserName,
                            Id = user.Id,
                            Password = user.Password,
                        }
                    );
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_userRepository.Get(id));
        }
    }
}
