using ExamenTecnico.Models;
using ExamenTecnico.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamenTecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMainService _mainService;

        public LoginController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = new Response<User>();
            try
            {
                response.Result = await _mainService.Login(login);
                response.IsSuccessfully = response.Result != null;
                response.ErrorMessage = response.Result == null ? "Usuario o contraseña incorrectos" : null;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.IsSuccessfully = false;
                response.ErrorMessage = ex.Message;

                return BadRequest(response);
            }
        }
    }
}
