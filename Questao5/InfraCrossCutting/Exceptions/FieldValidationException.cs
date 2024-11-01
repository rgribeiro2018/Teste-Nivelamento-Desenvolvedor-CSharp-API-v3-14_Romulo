using System.Net;
using System.Runtime.Serialization;

namespace Questao5.InfraCrossCutting.Exceptions
{
    public class FieldValidationException : Exception, ISerializable
    {
        /// <summary>
        /// Cria uma nova instância de ApiException.
        /// </summary>
        public FieldValidationException() : base()
        {
        }
        /// <summary>
        /// Obtém ou define o código de status de exceção da resposta da API.
        /// </summary>
        public HttpStatusCode? StatusExceptionCode { get; }
        /// <summary>
        /// Cria uma nova instância de ApiException com uma mensagem de erro personalizada.
        /// </summary>
        /// <param name="message">A mensagem de erro personalizada.</param>
        public FieldValidationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Cria uma nova instância de ApiException com uma mensagem de erro personalizada e uma exceção interna.
        /// </summary>
        /// <param name="message">A mensagem de erro personalizada.</param>
        /// <param name="innerException">A exceção interna.</param>
        public FieldValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Cria uma nova instância de ApiException com informações adicionais da API.
        /// </summary>
        /// <param name="statusExceptionCode">O código de status de exceção da resposta da API.</param>
        /// <param name="message">A mensagem de erro retornada pela API.</param>
        public FieldValidationException(HttpStatusCode? statusExceptionCode, string message) : base(message)
        {
            StatusExceptionCode = statusExceptionCode;
        }
    }
}
