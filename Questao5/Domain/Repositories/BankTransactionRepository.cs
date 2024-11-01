using Questao5.Domain.Entities;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using Questao5.Domain.Repositories.Interfaces;
using Questao5.Infrastructure.Sqlite;
using Microsoft.Data.Sqlite;

namespace Questao5.Domain.Repositories
{
    public class BankTransactionRepository : IBankTransactionRepository
    {
        private readonly string _connectionString;

        public BankTransactionRepository(DatabaseConfig databaseConfig)
        {
            _connectionString = databaseConfig.Name; 
        }

        public async Task InsertBankTransactionAsync(Movimento movimento)
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";
            await connection.ExecuteAsync(query, movimento);
        }

        public async Task<decimal> GetBalanceAsync(string idContaCorrente)
        {
            using var connection = new SqliteConnection(_connectionString);
            var queryCreditos = "SELECT SUM(valor) FROM movimento WHERE idcontacorrente = @IdContaCorrente AND tipomovimento = 'C'";
            var queryDebitos = "SELECT SUM(valor) FROM movimento WHERE idcontacorrente = @IdContaCorrente AND tipomovimento = 'D'";

            var totalCreditos = await connection.ExecuteScalarAsync<decimal?>(queryCreditos, new { IdContaCorrente = idContaCorrente }) ?? 0;
            var totalDebitos = await connection.ExecuteScalarAsync<decimal?>(queryDebitos, new { IdContaCorrente = idContaCorrente }) ?? 0;

            return totalCreditos - totalDebitos;
        }
    }
}
