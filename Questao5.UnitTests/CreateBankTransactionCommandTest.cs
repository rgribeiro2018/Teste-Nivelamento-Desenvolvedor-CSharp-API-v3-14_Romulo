using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao5.UnitTests
{
    public class CreateBankTransactionCommandTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CreateBankTransactionCommandTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:7140")
            });
        }

        [Fact]
        public async Task CreateBankTransaction_Success()
        {
            // Arrange
            var url = "/api/ContaCorrente/movimentacao";

            var model = new CreateBankTransactionCommand("FA99D033-7067-ED11-96C6-7C5DFA4A16C9", 'D', 100);
            var idempotencyKey = Guid.NewGuid().ToString();
            model.RequestId = idempotencyKey;
            model.IdMovimento = "teste";
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Add("idempotencyKey", idempotencyKey);

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);

            var retorno = JsonConvert.DeserializeObject<CreateBankTransactionResponse>(responseString);
            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.IdBankTransaction);
        }

        [Fact]
        public async Task CreateBankTransaction_Idempotency()
        {
            // Arrange
            var url = "/api/ContaCorrente/movimentacao";

            var model = new CreateBankTransactionCommand("FA99D033-7067-ED11-96C6-7C5DFA4A16C9", 'D', 100);
            var idempotencyKey = Guid.NewGuid().ToString();
            model.IdMovimento = idempotencyKey;
            model.RequestId = idempotencyKey;
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Add("idempotencyKey", idempotencyKey);

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);

            var retorno = JsonConvert.DeserializeObject<CreateBankTransactionResponse>(responseString);
            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.IdBankTransaction);


            var idBankTransaction = retorno.IdBankTransaction;

            // Act 2
            response = await _client.PostAsync(url, content);

            // Assert 2
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);
            responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);

            retorno = JsonConvert.DeserializeObject<CreateBankTransactionResponse>(responseString);
            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.IdBankTransaction);

            Assert.Equal(retorno.IdBankTransaction, idBankTransaction);
        }
    }
}
