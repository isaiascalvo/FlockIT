using ExamenTecnico.Models;
using ExamenTecnico.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamenTecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly IMainService _mainService;

        public ProvinciasController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpGet("{provName}")]
        public async Task<IActionResult> GetProvByName(string provName)
        {
            var response = new Response<ProvData>();
            try
            {
                response.Result = await _mainService.GetProvByName(provName);
                response.IsSuccessfully = response.Result != null;
                response.ErrorMessage = response.Result == null ? "No se ha encontrado una provincia llamada " + provName : null;

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
