using System.ComponentModel;

namespace Questao5.Domain.Enumerators
{
    public enum Validations
    {
        [Description("Conta corrente Inválida {0}")]
        INVALID_ACCOUNT = 1,
        [Description("Conta corrente Inativa {0}")]
        INACTIVE_ACCOUNT = 2,
        [Description("Valor deve ser maior que zero")]
        INVALID_VALUE = 3,
        [Description("Somente os tipos  “crédito” ou “débito” são aceitos")]
        INVALID_TYPE = 4,
    }
}
