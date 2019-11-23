namespace GestionPolizasIntegration.Test
{
    using System.Net.Http;
    using Xunit;

    public class PolizaIntegrationTest : IClassFixture<TestServerConfiguration>
    {
        private readonly HttpClient _client;
        public PolizaIntegrationTest(TestServerConfiguration fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
