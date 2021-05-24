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


        //Los comentarios colocados en los tests son para indicar que hubiera hecho si tuviese una capa de accesso a datos

        [Fact]
        public async Task LoginSuccessfullyTest()
        {
            //Arrange
            var login = new Login { Username = "isaías", Password = "isaías" };
            
            //_logginRepository.Setup(l => l.Login(It.Any<Login>())).ReturnAsync(new User
            //{
            //    Id = 1,
            //    Username = "isaías",
            //    FirstName = "Isaías",
            //    LastName = "Calvo"
            //});

            //Act
            var result = await _mainService.Login(login);

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Username);
            Assert.NotNull(result.FirstName);
            Assert.NotNull(result.LastName);

            //_logginRepository.Verify(x => x.Login(It.Any<Login>()), Times.Once);
        }

        [Fact]
        public async Task LoginFailTest()
        {
            //Arrange
            var login = new Login { Username = "asdasd", Password = "asdasd" };

            //_logginRepository.Setup(l => l.Login(It.Any<Login>())).ReturnAsync((User) null);

            //Act
            var result = await _mainService.Login(login);

            //Assert
            Assert.Null(result);

            //_logginRepository.Verify(x => x.Login(It.Any<Login>()), Times.Once);
        }
    }
}
