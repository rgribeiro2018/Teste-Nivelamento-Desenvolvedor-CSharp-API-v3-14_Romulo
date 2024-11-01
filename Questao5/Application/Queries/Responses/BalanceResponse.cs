namespace Questao5.Application.Queries.Responses
{
    public class BalanceResponse
    {
        public BalanceResponse(int numeroConta, string nomeTitularConta, decimal saldo)
        {
            NumeroConta = numeroConta;
            NomeTitularConta = nomeTitularConta;
            Saldo = saldo;
            DataHoraConsulta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 
        }

        public int NumeroConta { get; set; }
        public string NomeTitularConta { get; set; }
        public string DataHoraConsulta { get; set; }
        public decimal Saldo { get; set; }

    }
}
