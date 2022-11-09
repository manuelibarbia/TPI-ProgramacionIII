using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(UserRepository userRepository)
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
                    BirthDate = dto.BirthDate,
                    CreatedDate = DateTime.Now,
                    Id = users.Max(x => x.Id) + 1,
                    Password = dto.Password,
                    UserName = dto.UserName,
                };
                _userRepository.Add(user);
                UserResponse response = new UserResponse()
                {
                    UserName = dto.UserName,
                    BirthDate = dto.BirthDate,
                    CreatedDate = user.CreatedDate,
                    Id = user.Id,
                    Password = user.Password,
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
                            BirthDate = user.BirthDate,
                            CreatedDate = user.CreatedDate,
                            Id = user.Id,
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

