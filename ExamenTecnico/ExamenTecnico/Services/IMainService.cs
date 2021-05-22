using ExamenTecnico.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Services
{
    public interface IMainService
    {
        Task<bool> Login(Login login);
        Task<ProvData> GetProvByName(string provName);
    }
}
