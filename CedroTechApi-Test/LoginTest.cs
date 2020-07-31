using CedroTechApi.Controllers;
using CedroTechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CedroTechApi_Test
{
    public class LoginTest
    {
        User user = new User();
        LoginController loginController = new LoginController();

        [Fact]
        public void Login_Without_Email()
        {
            //Arrange
            user.Password = "Secret";
            //Act
            var result = loginController.Login(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Email Invalid!", contentResult.Value);

        }

        [Fact]
        public void Login_Without_Password()
        {
            //Arrange
            user.Email = "paulo_mussolini@yahoo.com.br";
            //Act
            var result = loginController.Login(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Password Invalid!", contentResult.Value);

        }
        [Fact]
        public void Login_With_Email_or_Password_Incorrect()
        {
            //Arrange
            user.Email = "paulo@yahoo.com.br";
            user.Password = "Secre";
            //Act
            var result = loginController.Login(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Email or Password Invalid!", contentResult.Value);
        }
        
    }
}
