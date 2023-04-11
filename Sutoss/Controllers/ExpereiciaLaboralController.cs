using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using Sutoss.Domain.Services.Domain.Services.Interfaces;
using Sutoss.Domain.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sutoss.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpereiciaLaboralsController : ControllerBase
    {
        private readonly ILogger<ExpereiciaLaboralsController> _logger;
        private readonly IExpereiciaLaboralsService _service;

        public ExpereiciaLaboralsController(ILogger<ExpereiciaLaboralsController> logger, IExpereiciaLaboralsService service)
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
        public async Task<IActionResult> Create(ExpereiciaLaboralRequest newExpereiciaLaboral)
        {
            try 
            {
                return Ok(await _service.Create(newExpereiciaLaboral  ));
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
        public async Task<IActionResult> Update(ExpereiciaLaboralRequest ExpereiciaLaboral)
        {
            try
            {
                return Ok(await _service.Update(ExpereiciaLaboral  ));
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
                var result = await _service.Delete(id);
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
