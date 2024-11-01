using Questao5.Application.Queries.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Questao5.Infrastructure.Services.ExemplesResponses
{
    public class BalanceResponseExample : IExamplesProvider<BalanceResponse>
    {
        public BalanceResponse GetExamples()
        {
            return new BalanceResponse(123, "Katherine Sanchez", 100);
        }
    }
}
