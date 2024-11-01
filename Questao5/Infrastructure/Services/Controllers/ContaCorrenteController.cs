using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests.Movimento;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests.Interfaces;
using Questao5.Application.Queries.Requests.Movimento;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.InfraCrossCutting.Middleware;
using Questao5.Infrastructure.Services.ExemplesRequests;
using Questao5.Infrastructure.Services.ExemplesResponses;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using System.Net.Mime;


namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IBankTransactionQuery _bankTransactionQuery;
        private readonly IMediator _mediator;
        public ContaCorrenteController(IBankTransactionQuery bankTransactionQuery, IMediator mediator)
        {
            _bankTransactionQuery = bankTransactionQuery;
            _mediator = mediator;

        }

        [HttpPost("movimentacao")]
        [SwaggerOperation(Summary = "Realiza a movmentação da conta corrente", Description = "Realiza a movmentação da conta corrente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateBankTransactionResponse))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CreateBankTransactionExampleResponse))]
        [SwaggerRequestExample(typeof(CreateBankTransactionCommand), typeof(CreateBankTransactionExampleRequest))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(CustomResponseExample))]
        public async Task<IActionResult> Movimentacao([FromHeader(Name = "idempotencyKey")] string idempotencyKey, [FromBody] CreateBankTransactionCommand command)
        {
            if (!Guid.TryParse(idempotencyKey, out Guid parsedRequestId))
            {
                return BadRequest("Invalid Idempotency Key.");
            }
            command.RequestId = parsedRequestId.ToString();
            var result = await _mediator.Send(command);

            if (!String.IsNullOrEmpty(result.IdBankTransaction))
            {
                return Created("", result);
            }

            return BadRequest(result);
        }

        [HttpGet("saldo/{idContaCorrente}")]
        [SwaggerOperation(Summary = "Retorna  o saldo da conta corrente", Description = "Retorna  o saldo da conta corrente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BalanceResponse))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(BalanceResponseExample))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(CustomResponse))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(CustomAccountResponseExample))]
        public async Task<IActionResult> Saldo(string idContaCorrente)
        {

            var result = await _bankTransactionQuery.ListBalanceAsync(idContaCorrente);

            return Ok(new
            {
                Numero = result.NumeroConta,
                Nome = result.NomeTitularConta,
                DataHora = result.DataHoraConsulta,
                Saldo = result.Saldo
            });

        }
    }
}
