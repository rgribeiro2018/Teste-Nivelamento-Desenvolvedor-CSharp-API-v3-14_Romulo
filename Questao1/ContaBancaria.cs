using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; private set; }

        private double saldo;

        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            saldo = depositoInicial;
        }


        public void Deposito(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
        }

        public void Saque(double valor)
        {
            if (valor > 0)
            {
                saldo -= valor + 3.50;
            }
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {saldo:F2}";
        }
    }
}
