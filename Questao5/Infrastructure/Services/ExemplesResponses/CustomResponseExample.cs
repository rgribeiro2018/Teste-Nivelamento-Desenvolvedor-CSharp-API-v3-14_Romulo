using Swashbuckle.AspNetCore.Filters;
using Questao5.Domain.Enumerators;
using Questao5.InfraCrossCutting.Middleware;
namespace Questao5.Infrastructure.Services.ExemplesResponses
{
    public class CustomResponseExample : IExamplesProvider<CustomResponse>
    {
        public CustomResponse GetExamples()
        {
            List<string> mensagens = new List<string> { string.Format(Validations.INVALID_ACCOUNT.GetDescription(), ""), string.Format(Validations.INACTIVE_ACCOUNT.GetDescription(), "") };

            return new CustomResponse(mensagens, false);

        }
    }
}
