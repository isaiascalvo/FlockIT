using ExamenTecnico.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamenTecnico.Services
{
    public class MainService : IMainService
    {
        public async Task<ProvData> GetProvByName(string provName)
        {
            var client = new HttpClient();
            var provData = new ProvData()
            {
                Long = 1,
                Lat = 1
            };

            return provData;
        }

        public async Task<bool> Login(Login login)
        {
            return login.Username == "isaías" && login.Password == "isaías";
        }
    }
}
