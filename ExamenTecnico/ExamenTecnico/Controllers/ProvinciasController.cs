using ExamenTecnico.Models;
using ExamenTecnico.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;
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
            Log.Instance.Info("Entering the Provincias Controller. GetProvByName method.");

            var response = new Response<ProvData>();
            try
            {
                response.Result = await _mainService.GetProvByName(provName);
                response.IsSuccessfully = response.Result != null;
                response.ErrorMessage = response.Result == null ? "No se ha encontrado una provincia llamada " + provName : null;

                Log.Instance.Info(response.IsSuccessfully ? "Exit Provincias Controller. Get Provincia By Name success." : "Exit Login Controller. Get Provincia By Name failed.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.IsSuccessfully = false;
                response.ErrorMessage = ex.Message;

                Log.Instance.Info("Exit Login Controller. Login failed with exception.");
                return BadRequest(response);
            }
        }
    }
}
