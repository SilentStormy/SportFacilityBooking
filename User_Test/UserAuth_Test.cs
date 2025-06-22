using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Services;
using Infrastructure.Data.Interface;
using Infrastructure.Data.Repositories;
using Moq;
using Core.Domain.Services.UserAuth;

namespace User_Test
{
    public class UserAuth_Test
    {

        [Fact]
        public void RegisterNewUser_ShouldreturnSuccess()
        {
            //Arrange
            var mockrepo= new Mock<IUserRepository>();
            var mockpass=new Mock<PasswordHasherservice>();
            var userauth=new UserService(mockrepo.Object,mockpass.Object);

            var newuser = new User (1,"Maria", "maria@outlook.com", "Mar", "06102528", "Guest");

            //Act
            var result = userauth.Register(newuser);

            //Assert
            Assert.True(result.Success);
            Assert.Equal("Jij bent succesvol geregistreerd!", result.Message);
        }
    }
}