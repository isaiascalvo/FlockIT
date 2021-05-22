using ExamenTecnico.Models;
using ExamenTecnico.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly IMainService _mainService;

        public Tests()
        {
            _mainService = new MainService();
        }

        [Fact]
        public async Task LoginSuccessfullyTest()
        {
            var login = new Login { Username = "isaías", Password = "isaías" };
            var result = await _mainService.Login(login);

            Assert.NotNull(result);
            Assert.NotNull(result.Username);
            Assert.NotNull(result.FirstName);
            Assert.NotNull(result.LastName);
        }

        [Fact]
        public async Task LoginFailTest()
        {
            var login = new Login { Username = "asdasd", Password = "asdasd" };
            var result = await _mainService.Login(login);

            Assert.Null(result);
        }
    }
}
