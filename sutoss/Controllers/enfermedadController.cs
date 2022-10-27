using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using sutoss.Domain.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace sutoss.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class enfermedadesController : ControllerBase
    {
        private readonly ILogger<enfermedadesController> _logger;
        private readonly IenfermedadesService _service;

        public enfermedadesController(ILogger<enfermedadesController> logger, IenfermedadesService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int? s, [FromQuery] string q, [FromQuery] int? l)
        {
            try
            {
                string userId = KeyCloak.KeyCloakManager.GetExternalUserId(User); // el token de keycloak hace esto
                return Ok(await _service.GetAll(s: s, q: q, l: l));
            }
            catch (NotFoundException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status401Unauthorized, "Username or password is incorrect");
            }
            catch (Exception ex)
            {
                // Logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (NotFoundException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status401Unauthorized, "Username or password is incorrect");
            }
            catch (Exception ex)
            {
                // Logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create(enfermedadRequest newenfermedad)
        {
            try 
            {
                string userId = KeyCloak.KeyCloakManager.GetExternalUserId(User);
                return Ok(await _service.Create(newenfermedad, userId));
            }
            catch (NotFoundException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status401Unauthorized, "Username or password is incorrect");
            }
            catch (Exception ex)
            {
                // Logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(enfermedadRequest enfermedad)
        {
            try
            {
                string userId = KeyCloak.KeyCloakManager.GetExternalUserId(User);
                return Ok(await _service.Update(enfermedad, userId));
            }
            catch (NotFoundException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status401Unauthorized, "Username or password is incorrect");
            }
            catch (Exception ex)
            {
                // Logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string userId = KeyCloak.KeyCloakManager.GetExternalUserId(User);
                var result = await _service.Delete(id, userId);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                // Logger.Warn(ex);
                return StatusCode(StatusCodes.Status401Unauthorized, "Username or password is incorrect");
            }
            catch (Exception ex)
            {
                // Logger.Error(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
