using System;
using Xunit;
using System.Threading.Tasks;
using FakeItEasy;
using CryptoAPI;
using CryptoAPI.Models;
using System.Linq;
using CryptoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CryptoAPI.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Tests
{
    public class ControllerTests : IntegrationTests
    {
        [Fact]
        public async Task WhenCalling_Get_WithData_ReturnsOk()
        {
            const int fakeCryptoCount = 2;

            var fakeCryptos = A.CollectionOfDummy<Crypto>(fakeCryptoCount).ToList();

            var fakeDataAccess = A.Fake<IDataAccess>();
            var controller = new CryptoController(fakeDataAccess);

            var apiCall = fakeDataAccess.GetAllCryptoAsync();

            A.CallTo(() => apiCall)
                .Returns(Task.FromResult(fakeCryptos)); 

            var actionResult = (await controller.Get()).Result as OkObjectResult;
            var returnedData = actionResult.Value as List<CryptoDTO>;

            Assert.NotNull(actionResult);
            Assert.NotNull(returnedData);
            Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(fakeCryptoCount, returnedData.Count);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task WhenCalling_Get_WithoutData_ReturnsNotFound()
        {
            var fakeDataAccess = A.Fake<IDataAccess>();
            var controller = new CryptoController(fakeDataAccess);

            var actionResult = (await controller.Get()).Result as NotFoundResult;

            Assert.NotNull(actionResult);
            Assert.IsType<NotFoundResult>(actionResult);
            Assert.Equal(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [Fact]
        public async Task Test_GetCryptoById_Name() // geen integration test!
        {
            for (int i = 1; i < 11; i++)
            {
                //Arrange
                var request = $"crypto/{i}";

                //Act
                var response = await TestClient.GetAsync(request);

                //Assert
                var content = await response.Content.ReadAsStringAsync();
                Assert.Contains("name", content);
            }
        }
    }
}
