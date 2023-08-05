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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _service;

        public UsersController(ILogger<UsersController> logger, IUsersService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("GetAll")]
        // [Authorize]
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
        // [Authorize]
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

        [HttpPost("Register")]
        // [Authorize]
        public async Task<IActionResult> Register(RegisterRequest newUser)
        {
            try
            {
                return Ok(await _service.Register(newUser));
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

        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] AuthRequest request)
        {
            try
            {
                var response = await _service.Authenticate(request);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
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
        // [Authorize]
        public async Task<IActionResult> Create(UserRequest newUser)
        {
            try
            {
                return Ok(await _service.Create(newUser));
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
        // [Authorize]
        public async Task<IActionResult> Update(UserRequest User)
        {
            try
            {
                return Ok(await _service.Update(User));
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
        // [Authorize]
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
