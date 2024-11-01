using Questao5.Application.Commands.Requests.Movimento;
using Swashbuckle.AspNetCore.Filters;

namespace Questao5.Infrastructure.Services.ExemplesRequests
{
    public class CreateBankTransactionExampleRequest : IExamplesProvider<CreateBankTransactionCommand>
    {
        public CreateBankTransactionCommand GetExamples()
        {
            return new CreateBankTransactionCommand("5a3cc8a9-27db-4416-860c-1325bf345f7f", 'D', 50);
        }
    }
}
