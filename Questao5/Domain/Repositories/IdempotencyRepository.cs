using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Domain.Repositories
{
    public class IdempotencyRepository : IIdempotencyRepository
    {
        private readonly string _connectionString;

        public IdempotencyRepository(DatabaseConfig databaseConfig)
        {
            _connectionString = databaseConfig.Name;
        }

        public async Task<Idempotencia> GetIdempotencyAsync(string id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = "SELECT * FROM idempotencia WHERE chave_idempotencia = @Id";
            return await connection.QuerySingleOrDefaultAsync<Idempotencia>(query, new { Id = id });
          
        }

        public async Task SaveAsync(Idempotencia idempotencia)
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = @"INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) VALUES (@ChaveIdempotencia, @Requisicao, @Resultado)";

            await connection.ExecuteAsync(query, idempotencia);
        }
    }
}
