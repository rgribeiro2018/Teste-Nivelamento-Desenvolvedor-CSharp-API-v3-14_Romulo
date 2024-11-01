using Questao5.Application.Services.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Interfaces;

namespace Questao5.Application.Services
{
    public class CurrentAccountService : ICurrentAccountService
    {
        private readonly ICurrentAccountRepository _currentAccountRepository;

        public CurrentAccountService(ICurrentAccountRepository currentAccountRepository)
        {
            _currentAccountRepository = currentAccountRepository;
        }

        public async Task<ContaCorrente> GetCurrentAccountAsync(string idContaCorrente)
        {
            var contaCorrente = await _currentAccountRepository.GetCurrentAccountAsync(idContaCorrente);

            return contaCorrente;
        }

        public async Task<bool> IsCurrentAccountActiveAsync(string idContaCorrente)
        {
            return await _currentAccountRepository.IsCurrentAccountActiveAsync(idContaCorrente);
        }
    }
}
