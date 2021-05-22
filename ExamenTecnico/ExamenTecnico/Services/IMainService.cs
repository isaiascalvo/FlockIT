using ExamenTecnico.Models;
using System.Threading.Tasks;

namespace ExamenTecnico.Services
{
    public interface IMainService
    {
        Task<User> Login(Login login);
        Task<ProvData> GetProvByName(string provName);
    }
}
