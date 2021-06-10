using CryptoAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class IntegrationTests
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            TestClient = factory.CreateClient();
        }
    }
}
