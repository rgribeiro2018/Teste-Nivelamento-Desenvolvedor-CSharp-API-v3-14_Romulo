using Newtonsoft.Json;

namespace Questao5.Application.Commands.Responses
{
    public class CreateBankTransactionResponse
    {
        public CreateBankTransactionResponse(string IdBankTransaction)
        {
            this.IdBankTransaction = IdBankTransaction;
        }
        public string? IdBankTransaction { get; set; }
    }
}
