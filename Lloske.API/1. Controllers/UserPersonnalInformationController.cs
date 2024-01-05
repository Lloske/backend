using Lloske.API.DTOs;
using Lloske.API.Mappers;
using Lloske.BLL.CustomExeptions;
using Lloske.BLL.Interfaces;
using Lloske.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lloske.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPersonnalInformationController : ControllerBase
    {
        private readonly IUserPersonnalInformation _UserPersonnalInformationService;

        public UserPersonnalInformationController(IUserPersonnalInformation userPersonnalInformationService)
        {
            _UserPersonnalInformationService = userPersonnalInformationService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserPersonnalInformationDTO>))]
        public IActionResult GetAll()
        {
            IEnumerable<UserPersonnalInformationDTO> result = _UserPersonnalInformationService.GetAll().Select(i => i.ToDTO());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserPersonnalInformationDTO))]
        [ProducesResponseType(404)]
        public IActionResult GetById([FromRoute] int userId)
        {
            UserPersonnalInformationDTO? result = _UserPersonnalInformationService.GetById(userId)?.ToDTO();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
            //return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UserPersonnalInformationDTO))]
        public IActionResult Insert([FromBody] UserPersonnalInformationDataDTO userPersonnalInformation)
        {
            UserPersonnalInformationDTO result = _UserPersonnalInformationService.Create(userPersonnalInformation.ToModel()).ToDTO();

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
                deleted = _UserPersonnalInformationService.Delete(userId);
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
    };
}
