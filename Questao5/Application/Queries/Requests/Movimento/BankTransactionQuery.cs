using Newtonsoft.Json;
using Questao5.Application.Queries.Requests.Interfaces;
using Questao5.Application.Queries.Responses;
using Questao5.Application.Services.Interfaces;
using Xunit.Sdk;

namespace Questao5.Application.Queries.Requests.Movimento
{
    public class BankTransactionQuery : IBankTransactionQuery
    {

        private readonly IBankTransactionService _movimentoService;

        public BankTransactionQuery(IBankTransactionService movimentoService)
        {
            _movimentoService = movimentoService;
        }
        public async Task<BalanceResponse> ListBalanceAsync(string idAccount)
        {
            var result = await _movimentoService.GetBalanceAsync(idAccount);

            return result;
        }
    }
}
