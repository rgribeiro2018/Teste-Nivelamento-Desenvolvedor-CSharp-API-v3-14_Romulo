using FluentValidation.Results;
using Newtonsoft.Json;
namespace Questao5.InfraCrossCutting.Extensions
{
    /// <summary>
    /// Classe de extensão para converter um objeto ValidationResult em uma lista de erros de validação.
    /// </summary>
    public static class ValidationResultExtension
    {
        /// <summary>
        /// Retorna uma lista de erros de validação a partir do objeto ValidationResult.
        /// </summary>
        /// <param name="result">Objeto ValidationResult contendo os erros de validação.</param>
        /// <returns>Uma lista de strings contendo os erros de validação.</returns>
        public static string ReturnValidationErrors(this ValidationResult result)
        {
            var jsonResult = result.Errors.ConvertAll(error =>
            !string.IsNullOrEmpty(error.PropertyName) ? $"{error.PropertyName}: {error.ErrorMessage}": $"{error.ErrorMessage}");

            return JsonConvert.SerializeObject(jsonResult);
        }
    }
}
