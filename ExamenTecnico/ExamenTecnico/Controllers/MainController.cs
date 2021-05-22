using ExamenTecnico.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService _mainService;

        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }

        //// GET: api/<MainController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MainController>/5
        [HttpGet("{provName}")]
        public async Task<IActionResult> GetProvByName(string provName)
        {
            var response = new Response<ProvData>();
            try
            {
                response.Result = await _mainService.GetProvByName(provName);
                response.IsSuccesfully = true;
                response.ErrorMessage = null;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.IsSuccesfully = false;
                response.ErrorMessage = ex.Message;

                return BadRequest(response);
            }
        }

        // POST api/<MainController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = new Response<bool?>();
            try
            {
                response.Result = await _mainService.Login(login);
                response.IsSuccesfully = true;
                response.ErrorMessage = null;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.IsSuccesfully = false;
                response.ErrorMessage = ex.Message;

                return BadRequest(response);
            }
        }

        //// PUT api/<MainController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MainController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ProvData
    {
        public int Long { get; set; }
        public int Lat { get; set; }
    }

    public class Response<T>
    {
        public bool IsSuccesfully { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }

}
