using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.Services.Interfaces
{
    public interface IBankTransactionService
    {
        Task<string> CreateBankTransactionAsync(Movimento command, string requestId);
        Task<BalanceResponse> GetBalanceAsync(string idCurrentAccount);
    }
}
