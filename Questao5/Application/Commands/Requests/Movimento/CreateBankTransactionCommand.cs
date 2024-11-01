using MediatR;
using Questao5.Application.Commands.Requests.Validators;
using System.Net;
using FluentValidation.Results;
using Questao5.InfraCrossCutting.Exceptions;
using Questao5.InfraCrossCutting.Extensions;
using Questao5.Application.Services.Interfaces;
using Questao5.Application.Commands.Responses;
using Questao5.InfraCrossCutting.Middleware;

namespace Questao5.Application.Commands.Requests.Movimento
{
    public record class CreateBankTransactionCommand : IRequest<CreateBankTransactionResponse>
    {
        public CreateBankTransactionCommand(string idContaCorrente, char tipoMovimento, decimal valor)
        {
            IdContaCorrente = idContaCorrente;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
        public string RequestId { get; set; }
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public void Validate(ICurrentAccountService currentAccountService)
        {
            CreateBankTransactionCommandValidator validator = new(currentAccountService);
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid)
            {
                throw new CustomErrorException(result.ReturnValidationErrors());
            }
        }

    }
}

