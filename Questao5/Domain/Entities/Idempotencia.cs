using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        [Key]
        [Column("chave_idempotencia", TypeName = "TEXT")]
        [StringLength(37)]
        public string ChaveIdempotencia { get; set; }

        [Column("requisicao", TypeName = "TEXT")]
        [StringLength(1000)]
        public string Requisicao { get; set; }

        [Column("resultado", TypeName = "TEXT")]
        [StringLength(1000)]
        public string Resultado { get; set; }
    }
}
