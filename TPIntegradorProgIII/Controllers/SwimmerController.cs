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
                List<Swimmer> swimmers = _swimmerRepository.GetSwimmers();
                List<SwimmerResponse> swimmersList = new();
                foreach (var swimmer in swimmers)
                {
                    SwimmerResponse response = new()
                        {
                            Id = swimmer.Id,
                            Name = swimmer.Name,
                            Surname = swimmer.Surname,
                            UserName = swimmer.UserName,
                            DNI = swimmer.DNI,
                            Email = swimmer.Email,
                            TrialId = swimmer.TrialId
                        };
                    swimmersList.Add(response);
                }
                return Ok(swimmersList);
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
                Swimmer? swimmer = _swimmerRepository.GetSingleSwimmer(id);
                SwimmerResponse response = new()
                {
                    Id = swimmer.Id,
                    Name = swimmer.Name,
                    Surname = swimmer.Surname,
                    UserName = swimmer.UserName,
                    DNI = swimmer.DNI,
                    Email = swimmer.Email,
                    TrialId = swimmer.TrialId
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
                List<Trial> trials = _swimmerRepository.GetExistingTrials();
                ValidateTrialId(trials, request.TrialId);

                List<Swimmer> swimmers = _swimmerRepository.GetSwimmers();
                ValidateDNI(swimmers, request.DNI);
                Swimmer swimmer = new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.UserName,
                    DNI = request.DNI,
                    Password = request.Password,
                    Email = request.Email,
                    TrialId = request.TrialId
                };
                SwimmerResponse response = new()
                {
                    Id = swimmer.Id,
                    Name = swimmer.Name,
                    Surname = swimmer.Surname,
                    UserName = swimmer.UserName,
                    DNI = swimmer.DNI,
                    Email = swimmer.Email,
                    TrialId = swimmer.TrialId
                };
                _swimmerRepository.AddSwimmer(swimmer);
                return Created("Nadador creado", response);
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
                _swimmerRepository.RemoveSwimmer(id);
                return Ok("Nadador borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySwimmerName/{id}/{newName}")]
        public IActionResult ModifySwimmerName(int id, string newName)
        {
            try
            {
                _swimmerRepository.EditSwimmerName(id, newName);
                return Ok("Nombre editado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySwimmerSurname/{id}/{newSurname}")]
        public IActionResult ModifySwimmerSurname(int id, string newSurname)
        {
            try
            {
                _swimmerRepository.EditSwimmerSurname(id, newSurname);
                return Ok("Apellido editado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateDNI(List<Swimmer> swimmers, string DNI)
        {
            var inUse = swimmers.FirstOrDefault(u => u.DNI == DNI);
            if (inUse != null)
            {
                throw new Exception("DNI ya registrado");
            }
        }

        [NonAction]
        public void ValidateTrialId(List<Trial> trials, int trialId)
        {
            var trialExists = trials.FirstOrDefault(m => m.Id == trialId);
            if (trialExists == null)
            {
                throw new Exception("Trial no encontrado, revisar Id.");
            }
        }
    }
}
