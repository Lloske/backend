using Lloske.API._2._DTOs;
using Lloske.API._3._Mappers;
using Lloske.BLL.CustomExeptions;
using Lloske.BLL._1._1_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Lloske.API._1._Controllers
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
        #region TUTO IActionResult
        //IActionResult est une interface dans ASP.NET Core utilisée pour représenter le résultat d'une action d'un contrôleur.
        //Cela permet à votre action de retourner différents types de résultats HTTP tels que Ok, NotFound, BadRequest, CreatedAtAction, etc.
        //En utilisant IActionResult, votre action de contrôleur peut retourner un résultat HTTP approprié en fonction de la logique de votre application.
        #endregion
        public IActionResult GetAll()
        {
            IEnumerable<UserPersonnalInformationDTO> result = _UserPersonnalInformationService.GetAll().Select(i => i.ToDTO());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserPersonnalInformationDTO))]
        [ProducesResponseType(404, Type = typeof(string))]
        #region TUTO FromRoute 
        // FromRoute = paramètre userId récupérer depuis l'url
        #endregion
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
        #region TUTO From body 
        // From body = données pour le userPersonnalInformation récupérées dans le corps de la requete HTTP 
        #endregion
        public IActionResult Insert([FromBody] UserPersonnalInformationDataDTO userPersonnalInformation)
        {
            UserPersonnalInformationDTO result = _UserPersonnalInformationService.Create(userPersonnalInformation.ToModel()).ToDTO();
            //201 Created
            return CreatedAtAction(nameof(GetById), new { userId = result.Id }, result);
            //return StatusCode(StatusCodes.Status501NotImplemented);

        }

        [HttpPatch("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserPersonnalInformationDTO))] // Ok
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404, Type = typeof(string))] // Not found
        [ProducesResponseType(405, Type = typeof(string))] // Method not allowed
        public IActionResult Update([FromRoute] int userId, [FromBody] UserPersonnalInformationDataDTO userPersonnalInformation)
        {
            UserPersonnalInformationDTO result = _UserPersonnalInformationService.Update(userId, userPersonnalInformation.ToModel()).ToDTO();
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
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
