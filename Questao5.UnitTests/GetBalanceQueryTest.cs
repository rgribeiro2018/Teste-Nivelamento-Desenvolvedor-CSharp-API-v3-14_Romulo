using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Responses;
using Questao5.InfraCrossCutting.Middleware;
using System.Text;

namespace Questao5.UnitTests
{
    public class GetBalanceQueryTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public GetBalanceQueryTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:7140")
            });
        }


        [Fact]
        public async Task GetBalance_Success()
        {
            // Arrange
            string idConta = "B6BAFC09-6967-ED11-A567-055DFA4A16C9";
            var url = $"/api/contacorrente/saldo/{idConta}";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);

            var retorno = JsonConvert.DeserializeObject<BalanceResponse>(responseString);
            Assert.NotNull(retorno);
        }

        [Fact]
        public async Task GetBalance_InactiveAccount()
        {
            // Arrange
            string idConta = "D2E02051-7067-ED11-94C0-835DFA4A16C9";
            var url = $"/api/contacorrente/saldo/{idConta}";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);

            var retorno = JsonConvert.DeserializeObject<CustomResponse>(responseString);
            Assert.NotNull(retorno);
            Assert.NotNull(retorno.messages);
        }

    }

}