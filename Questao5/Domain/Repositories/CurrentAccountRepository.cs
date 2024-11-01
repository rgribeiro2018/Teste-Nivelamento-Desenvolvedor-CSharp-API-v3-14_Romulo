using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
namespace Questao5.Domain.Repositories
{
   

    public class CurrentAccountRepository : ICurrentAccountRepository
    {
        private readonly DatabaseConfig databaseConfig;


        public CurrentAccountRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<ContaCorrente> GetCurrentAccountAsync(string id)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var query = "SELECT * FROM contacorrente WHERE idcontacorrente = @Id";

            return await connection.QuerySingleOrDefaultAsync<ContaCorrente>(query, new { Id = id });
        }

        public async Task<bool> IsCurrentAccountActiveAsync(string id)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            var query = "SELECT ativo FROM contacorrente WHERE idcontacorrente = @Id";
            var ativo = await connection.ExecuteScalarAsync<int>(query, new { Id = id });
            return ativo == 1;
        }
    }
}
