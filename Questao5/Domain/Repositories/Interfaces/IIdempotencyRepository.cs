using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories.Interfaces
{
    public interface IIdempotencyRepository
    {
        Task<Idempotencia> GetIdempotencyAsync(string id);
        Task SaveAsync(Idempotencia idempotencia);
    }
}
