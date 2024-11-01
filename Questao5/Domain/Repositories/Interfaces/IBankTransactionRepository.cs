using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories.Interfaces
{
    public interface IBankTransactionRepository
    {
        Task InsertBankTransactionAsync(Movimento movimento);
        Task<decimal> GetBalanceAsync(string idContaCorrente);
    }
}
