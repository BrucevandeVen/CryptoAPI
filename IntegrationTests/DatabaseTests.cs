using CryptoAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class DatabaseTests : IClassFixture<WebApplicationFactory<CryptoAPI.Startup>>
    {
        private readonly WebApplicationFactory<CryptoAPI.Startup> _factory;

        public DatabaseTests(WebApplicationFactory<CryptoAPI.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Crypto")]
        [InlineData("/Crypto/1")]
        [InlineData("/Crypto/2")]
        [InlineData("/Crypto/3")]
        [InlineData("/Crypto/4")]
        [InlineData("/Crypto/5")]
        [InlineData("/Crypto/6")]
        [InlineData("/Crypto/7")]
        [InlineData("/Crypto/8")]
        [InlineData("/Crypto/9")]
        [InlineData("/Crypto/10")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
