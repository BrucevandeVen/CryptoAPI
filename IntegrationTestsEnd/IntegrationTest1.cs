using System;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class IntegrationTest1 : IntegrationtestExtensions
    {
        [Fact]
        public async Task Test_GetAllCryptosAsync()
        {
            //Arrange
            var request = "crypto";

            //Act
            var response = await TestClient.GetAsync(request);

            //Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Get", content);
        }

        [Fact]
        public async Task Test_GetCryptoById_Name()
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

        [Fact]
        public async Task Test_GetCryptoById()
        {
            //Arrange
            var request = "crypto/1";

            //Act
            var response = await TestClient.GetAsync(request);

            //Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Get", content);
        }

        [Fact]
        public async Task someting()
        {
            //Arrange
            var request = "crypto/1";

            //Act
            var response = await TestClient.GetAsync(request);

            //Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Get", content);
        }
    }
}
