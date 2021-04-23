using System;
using System.Threading.Tasks;
using Xunit;

namespace CryptoAPI.IntegrationTests
{
    public class IntegrationTest1 : IntegrationTest
    {
        private readonly IDataAccess _dataAccess;
        private readonly ICryptoDataUpdater _cryptoUpdater;

        public IntegrationTest1(IDataAccess dataAccess, ICryptoDataUpdater cryptoUpdater)
        {
            _dataAccess = dataAccess;
            _cryptoUpdater = cryptoUpdater;
        }

        [Fact]
        public async Task GetAll_AskForAllData_ReturnsOK()
        {
            //Arrange
            _cryptoUpdater.Update();

            //Act
            var response = await TestClient.GetAsync(ApiRoutes.);

            //Assert

        }
    }
}
