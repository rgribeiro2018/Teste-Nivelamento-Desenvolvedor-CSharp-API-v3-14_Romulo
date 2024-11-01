using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories.Interfaces
{
    public interface ICurrentAccountRepository
    {
        Task<ContaCorrente> GetCurrentAccountAsync(string id);
        Task<bool> IsCurrentAccountActiveAsync(string id);
    }
}
