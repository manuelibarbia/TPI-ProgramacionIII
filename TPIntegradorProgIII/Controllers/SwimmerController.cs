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
    public class SwimmerController : ControllerBase
    {

        private readonly ISwimmerRepository _swimmerRepository;

        public SwimmerController(ISwimmerRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }

        [HttpGet]
        [Route("getAllSwimmers")]
        public IActionResult GetAllSwimmers()
        {
            try
            {
                List<Swimmer> users = _swimmerRepository.GetUsers();
                List<SwimmerResponse> usersList = new();
                foreach (var user in users)
                {
                    SwimmerResponse response = new()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            UserName = user.UserName,
                            DNI = user.DNI,
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
        [Route("getSwimmerById/{id}")]
        public IActionResult GetSwimmerById(int id)
        {
            try
            {
                Swimmer? user = _swimmerRepository.GetSingleUser(id);
                SwimmerResponse response = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
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
        [Route("createSwimmer")]
        public IActionResult CreateSwimmer(AddSwimmerRequest request)
        {
            try
            {
                List<Swimmer> users = _swimmerRepository.GetUsers();
                ValidateDNI(users, request.DNI);
                Swimmer user = new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.UserName,
                    DNI = request.DNI,
                    Password = request.Password,
                    Email = request.Email
                };
                SwimmerResponse response = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    DNI = user.DNI,
                    Email = user.Email,
                };
                _swimmerRepository.AddUser(user);
                return Created("Usuario creado", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteSwimmer/{id}")]
        public IActionResult DeleteSwimmer(int id)
        {
            try
            {
                _swimmerRepository.RemoveUser(id);
                return Ok("Usuario borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("modifySwimmerName/{id}/{newName}")]
        public IActionResult ModifyName(int id, string newName)
        {
            try
            {
                _swimmerRepository.EditName(id, newName);
                return Ok("Nombre editado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySwimmerSurname/{id}/{newSurname}")]
        public IActionResult ModifySurname(int id, string newSurname)
        {
            try
            {
                _swimmerRepository.EditSurname(id, newSurname);
                return Ok("Apellido editado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateDNI(List<Swimmer> users, string DNI)
        {
            var inUse = users.FirstOrDefault(u => u.DNI == DNI);
            if (inUse != null)
            {
                throw new Exception("DNI ya registrado");
            }
        }
    }
}
