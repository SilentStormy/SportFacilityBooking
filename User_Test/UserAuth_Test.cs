using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Core.Domain.Services;
using Infrastructure.Data.Interface;
using Infrastructure.Data.Repositories;
using Moq;

namespace User_Test
{
    public class UserAuth_Test
    {

        [Fact]
        public void RegisterNewUser_ShouldreturnSuccess()
        {
            //Arrange
            var mockrepo= new Mock<IUserRepository>();
            var userauth=new UserAuthentication(mockrepo.Object);

            var newuser = new User
            {
                Name = "Maria",
                Email = "maria@outlook.com",
                Password = "Mar",
                PhoneNumber = "06102528",
                Role = "Guest",
            };

            //Act
            var result = userauth.Register(newuser);

            //Assert
            Assert.True(result.Success);
            Assert.Equal("Jij bent succesvol geregistreerd!", result.Message);
        }
    }
}