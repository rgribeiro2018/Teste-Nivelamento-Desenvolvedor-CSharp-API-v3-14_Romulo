using Questao5.Domain.Enumerators;
using System.Drawing;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {

        public Movimento(string idContaCorrente, DateTime dataMovimento, char tipoMovimento, decimal valor)
        {
            IdMovimento =  Guid.NewGuid().ToString();
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
        public string IdMovimento { get; private set; }
        public string IdContaCorrente { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public char TipoMovimento { get; private set; }
        public decimal Valor { get; set; }

        public void AlteraId(string id)
        {
            IdMovimento = id;
        }
    }
}
