using AgendaDemo.Entities;
using AgendaDemo.Models;
using AgendaDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Helpers;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly Security _security;

        public UserController(UserRepository userRepository, Security security)
        {
            _userRepository = userRepository;
            _security = security;
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
                    Password = _security.CreateSHA512(dto.Password + "salt"),
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

