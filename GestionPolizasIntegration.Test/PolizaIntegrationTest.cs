namespace GestionPolizasIntegration.Test
{
    using GestionPolizas.Entities.DTO;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Xunit;

    public class PolizaIntegrationTest : IClassFixture<TestServerConfiguration>
    {
        private readonly HttpClient _client;
        public PolizaIntegrationTest(TestServerConfiguration fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public void GetPoliza()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "Poliza");
            // Act: request the /todo route
            var response = _client.SendAsync(request);
            // Assert: the user is sent to the login page
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Fact]
        public void PostPoliza()
        {
            PolicyDto policy = new PolicyDto
            {
                Active = true,
                Coverage = 0.3,
                Description = "Poliza uno",
                Name = "Poliza 1",
                PolicyTypeId = 1,
                Price = 2500,
                RiskTypeId = 1
            };

            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "Poliza");
            request.Content = new StringContent(JsonConvert.SerializeObject(policy), Encoding.UTF8, "application/json");
            // Act: request the /todo route
            var response = _client.SendAsync(request);
            // Assert: the user is sent to the login page
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Fact]
        public void PatchPoliza()
        {
            PolicyDto policy = new PolicyDto
            {
                Id = 1,
                Active = true,
                Coverage = 0.3,
                Description = "Poliza uno actualizada",
                Name = "Poliza 1 update",
                PolicyTypeId = 1,
                Price = 2500,
                RiskTypeId = 1
            };

            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Patch, "Poliza");
            request.Content = new StringContent(JsonConvert.SerializeObject(policy), Encoding.UTF8, "application/json");
            // Act: request the /todo route
            var response = _client.SendAsync(request);
            // Assert: the user is sent to the login page
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Fact]
        public void DeletePoliza()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete, "Poliza/1");
            // Act: request the /todo route
            var response = _client.SendAsync(request);
            // Assert: the user is sent to the login page
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }
    }
}
