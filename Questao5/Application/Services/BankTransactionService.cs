using Microsoft.Data.Sqlite;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Queries.Responses;
using Questao5.Application.Services.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Repositories;
using Questao5.Domain.Repositories.Interfaces;
using Questao5.InfraCrossCutting.Middleware;

namespace Questao5.Application.Services
{
    public class BankTransactionService : IBankTransactionService
    {
        private readonly ICurrentAccountRepository _currentAccountRepository;
        private readonly IBankTransactionRepository _bankTransactionRepository;
        private readonly IIdempotencyRepository _idempotencyRepository;


        public BankTransactionService(ICurrentAccountRepository currentAccountRepository, IBankTransactionRepository bankTransactionRepository, IIdempotencyRepository idempotencyRepository)
        {
            _currentAccountRepository = currentAccountRepository;
            _bankTransactionRepository = bankTransactionRepository;
            _idempotencyRepository = idempotencyRepository;
        }

        public async Task<string> CreateBankTransactionAsync(Movimento command,string requestId)
        {
            var idempotencia = await _idempotencyRepository.GetIdempotencyAsync(requestId);

            if (idempotencia != null)
            {
                return idempotencia.Resultado;
            }

            var Movimento = new Movimento(command.IdContaCorrente, DateTime.Now, command.TipoMovimento, command.Valor);

            await _bankTransactionRepository.InsertBankTransactionAsync(Movimento);
            
            var newIdempotency = new Idempotencia
            {
                ChaveIdempotencia = requestId,
                Requisicao = command.ToString(), 
                Resultado = Movimento.IdMovimento 
            };

            await _idempotencyRepository.SaveAsync(newIdempotency);

            return Movimento.IdMovimento;
        }

        public async Task<BalanceResponse> GetBalanceAsync(string idCurrentAccount)
        {
            {

                var currentAccount = await _currentAccountRepository.GetCurrentAccountAsync(idCurrentAccount);

                ValidateAccount(currentAccount);

                var balance = await _bankTransactionRepository.GetBalanceAsync(idCurrentAccount);

                var response = new BalanceResponse(currentAccount.Numero, currentAccount.Nome, balance);

                return response;
            }
        }

        private static void ValidateAccount(ContaCorrente currentAccount)
        {
            if (currentAccount == null)
            {
                throw new CustomErrorException(string.Format(Validations.INVALID_ACCOUNT.GetDescription(), ""));
            }

            if (currentAccount.Ativo == false)
            {
                throw new CustomErrorException(string.Format(Validations.INACTIVE_ACCOUNT.GetDescription(), ""));

            }
        }
    }
}
