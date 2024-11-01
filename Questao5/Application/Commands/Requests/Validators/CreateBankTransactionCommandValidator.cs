using FluentValidation;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Services;
using Questao5.Application.Services.Interfaces;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using System.Drawing;

namespace Questao5.Application.Commands.Requests.Validators
{
    public class CreateBankTransactionCommandValidator : AbstractValidator<CreateBankTransactionCommand>
    {
        public CreateBankTransactionCommandValidator(ICurrentAccountService _currentAccountService)
        {

            RuleFor(filter => filter.IdContaCorrente)
                .NotNull().WithMessage(string.Format(Validations.INVALID_ACCOUNT.GetDescription(),""))
                .Must(idContaCorrente =>
                 {
                    return _currentAccountService.IsCurrentAccountActiveAsync(idContaCorrente).Result;
                })
                .WithMessage(string.Format(Validations.INACTIVE_ACCOUNT.GetDescription(), "")); 

            RuleFor(filter => filter.Valor)
                .GreaterThan(0).WithMessage(string.Format(Validations.INVALID_VALUE.GetDescription())); 

            RuleFor(filter => filter.TipoMovimento)
                .Must(tipo => tipo == 'C' || tipo == 'D')
                .WithMessage(string.Format(Validations.INVALID_TYPE.GetDescription())); 

        }
    }
}
