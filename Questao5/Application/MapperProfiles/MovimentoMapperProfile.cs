using AutoMapper;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.MapperProfiles
{
    public class MovimentoMapperProfile : Profile
    {
        public MovimentoMapperProfile()
        {

            CreateMap<CreateBankTransactionCommand, Movimento>()
                .ConstructUsing(command => new Movimento(
                command.IdContaCorrente,
                command.DataMovimento,
                command.TipoMovimento,
                command.Valor))
                .ForMember(dest => dest.IdMovimento, opt => opt.Ignore())
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

        }

    }
}
