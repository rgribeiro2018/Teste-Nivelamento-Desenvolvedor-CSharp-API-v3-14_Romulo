using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests.Interfaces
{
    public interface IBankTransactionQuery
    {
        Task<BalanceResponse> ListBalanceAsync(string idAccount);
    }
}
