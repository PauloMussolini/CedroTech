using CedroTechApi.Controllers;
using CedroTechApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CedroTechApi_Test
{
    public class DocumentTest
    {
        User user = new User();
        DocumentController DocumentController = new DocumentController();


        [Fact]
        public void Document_Without_Name()
        {
            //Arrange
            user.FullName = "";
            //Act
            var result = DocumentController.Create(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Full Name should be informed!", contentResult.Value);

        }

        [Fact]
        public void Document_Without_Email()
        {
            //Arrange
            user.FullName = "Paulo";
            user.Email = "";
            //Act
            var result = DocumentController.Create(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Email should be informed!", contentResult.Value);

        }

        [Fact]
        public void Document_Without_CPF()
        {
            //Arrange
            user.FullName = "Paulo";
            user.Email = "paulo_mussolini@yahoo.com.br";
            user.CPF = "";
            //Act
            var result = DocumentController.Create(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("CPF should be informed!", contentResult.Value);

        }

        [Fact]
        public void Document_Without_RG()
        {
            //Arrange
            user.FullName = "Paulo";
            user.Email = "paulo_mussolini@yahoo.com.br";
            user.CPF = "12345";
            user.RG = "";
            //Act
            var result = DocumentController.Create(user);

            //Assert
            var contentResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("RG should be informed!", contentResult.Value);

        }



    }
}
