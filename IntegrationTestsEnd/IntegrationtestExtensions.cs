using CryptoAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IntegrationTests
{
    public class IntegrationtestExtensions
    {
        protected readonly HttpClient TestClient;

        protected IntegrationtestExtensions()
        {
            var factory = new WebApplicationFactory<Startup>();
            TestClient = factory.CreateClient();
        }
    }
}
