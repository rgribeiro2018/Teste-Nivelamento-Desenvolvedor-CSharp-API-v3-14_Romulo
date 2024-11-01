using Questao5.Application.Commands.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Questao5.Infrastructure.Services.ExemplesResponses
{
    public class CreateBankTransactionExampleResponse : IExamplesProvider<CreateBankTransactionResponse>
    {
        public CreateBankTransactionResponse GetExamples()
        {
            return new CreateBankTransactionResponse("5a3cc8a9-27db-4416-860c-1325bf345f7f");
        }

    }
}
