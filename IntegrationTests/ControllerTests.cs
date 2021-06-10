using CryptoAPI;
using CryptoAPI.Controllers;
using CryptoAPI.DTOs;
using CryptoAPI.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class ControllerTests
    {
        //[Fact]
        //public async Task WhenCalling_GetAllCryptoData_WithData_ReturnsOk()
        //{
        //    const int fakeCryptoCount = 10;
        //    const int fakeDataCount = 10;

        //    var fakeCryptos = A.CollectionOfDummy<Crypto>(fakeCryptoCount).ToList();

        //    var fakeRepository = A.Fake<IDataAccess>();
        //    var controller = new CryptoController(fakeRepository);

        //    A.CallTo(() => fakeRepository.GetAll())
        //        .Returns(Task.FromResult(fakeCryptos));

        //    var actionResult = (await controller.GetAllSensorData()).Result as OkObjectResult;
        //    var returnedData = (actionResult.Value as List<CryptoDTO>);

        //    Assert.NotNull(actionResult);
        //    Assert.NotNull(returnedData);
        //    Assert.IsType<OkObjectResult>(actionResult);
        //    Assert.Equal(fakeDataCount, returnedData.First().sensorData.Count);
        //    Assert.Equal(fakeCryptoCount, returnedData.Count);
        //    Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        //}
    }
}
