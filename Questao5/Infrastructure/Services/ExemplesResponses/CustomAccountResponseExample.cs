using Questao5.Domain.Enumerators;
using Swashbuckle.AspNetCore.Filters;

namespace Questao5.Infrastructure.Services.ExemplesResponses
{
    public class CustomAccountResponseExample : IExamplesProvider<string>
    {
        public string GetExamples()
        {
            string complementoMensagem = " ";
            var mensagem = "{ \"Messages\":[ " +
            Environment.NewLine +
            " \"" + string.Format(Validations.INVALID_ACCOUNT.GetDescription(), complementoMensagem) + "\"" +
            Environment.NewLine +
            ", " +
            "\"" + string.Format(Validations.INACTIVE_ACCOUNT.GetDescription(), complementoMensagem) + "\"" +
            Environment.NewLine +
            " ]}";
            return mensagem;

        }
    }
}
