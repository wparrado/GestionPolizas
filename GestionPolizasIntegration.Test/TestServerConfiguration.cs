namespace GestionPolizasIntegration.Test
{
    using System;
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    public class TestServerConfiguration: IDisposable
    {
        private readonly TestServer _server;
        public HttpClient Client { get; }
        public TestServerConfiguration()
        {
            var builder = new WebHostBuilder()
                .UseStartup<GestionPolizas.Startup>();
            _server = new TestServer(builder);
            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("https://localhost:44326/api/");
        }
        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
