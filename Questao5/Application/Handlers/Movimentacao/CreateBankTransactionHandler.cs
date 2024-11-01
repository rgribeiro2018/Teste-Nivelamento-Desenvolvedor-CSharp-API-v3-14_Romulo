using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Services.Interfaces;
using Questao5.InfraCrossCutting.Exceptions;
using Questao5.Application.Commands.Responses;
using System.Net;

namespace Questao5.Application.Handlers.Movimento
{
    public class CreateBankTransactionHandler : IRequestHandler<CreateBankTransactionCommand, CreateBankTransactionResponse>
    {
        private readonly IMapper _mapper;

        private readonly ICurrentAccountService _currentAccountService;

        private readonly IBankTransactionService _bankTransactionServiceService;
        public CreateBankTransactionHandler(IMapper mapper, IBankTransactionService bankTransactionService, ICurrentAccountService currentAccountService)
        {
            _mapper = mapper;
            _bankTransactionServiceService = bankTransactionService;
            _currentAccountService = currentAccountService;
        }

        public async Task<CreateBankTransactionResponse> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
        {
            
                request.Validate(_currentAccountService);
                var Movimento = _mapper.Map<Questao5.Domain.Entities.Movimento>(request);

                var result = await _bankTransactionServiceService.CreateBankTransactionAsync(Movimento, request.RequestId);

                var response = new CreateBankTransactionResponse(result);

                return response;
                
               

        }

    }
}
