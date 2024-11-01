using Questao5.Domain.Entities;

namespace Questao5.Application.Services.Interfaces
{
    public interface ICurrentAccountService
    {
        Task<ContaCorrente> GetCurrentAccountAsync(string idContaCorrente);
        Task<bool> IsCurrentAccountActiveAsync(string idContaCorrente);
    }
}
