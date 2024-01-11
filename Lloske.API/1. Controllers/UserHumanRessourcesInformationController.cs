﻿using Lloske.API._2._DTOs;
using Lloske.API._3._Mappers;
using Lloske.BLL._1._1_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lloske.API._1._Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHumanRessourcesInformationController : ControllerBase
    {
        private readonly IUserHumanRessourcesInformation _UserHumanRessourcesInformationService;

        public UserHumanRessourcesInformationController(IUserHumanRessourcesInformation userHumanRessourcesInformationService)
        {
            _UserHumanRessourcesInformationService = userHumanRessourcesInformationService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserHumanRessourcesInformationDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<UserHumanRessourcesInformationDTO> result = _UserHumanRessourcesInformationService.GetAll().Select(i => i.ToDTO());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserHumanRessourcesInformationDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetById([FromRoute] int userId)
        {
            UserHumanRessourcesInformationDTO? result = _UserHumanRessourcesInformationService.GetById(userId)?.ToDTO();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
            //return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UserHumanRessourcesInformationDTO))]
        public IActionResult Insert([FromBody] UserHumanRessourcesInformationDataDTO userPersonnalInformation)
        {
            UserHumanRessourcesInformationDTO result = _UserHumanRessourcesInformationService.Create(userPersonnalInformation.ToModel()).ToDTO();

            //201 Created
            return CreatedAtAction(nameof(GetById), new { userId = result.Id }, result);
            //return StatusCode(StatusCodes.Status501NotImplemented);

        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404, Type = typeof(string))]
        [ProducesResponseType(409, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Delete([FromRoute] int userId)
        {
            bool deleted;
            try
            {
                deleted = _UserHumanRessourcesInformationService.Delete(userId);
            }
            //catch (NotFoundException nFEx)
            //{
            //    return NotFound("Ingredient not found");
            //}
            //catch (AlreadyUsedException aUEx)
            //{
            //    return Conflict("Ingredient already used in a recipe");
            //}
            catch (Exception ex)
            {
                // Toute autre Exception qui n'est ni NotFoundException, ni AlreadyUsedExeption
                // ! A mettre toujours en dernier catch
                return BadRequest(ex.Message);
            }

            return deleted ? NoContent() : NotFound("User not found");

            //return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
