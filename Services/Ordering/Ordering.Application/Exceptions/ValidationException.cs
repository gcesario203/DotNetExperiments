using FluentValidation.Results;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string , string[]> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
        : base($"One or more validation failed.")
        {
                    
            Errors = failures
            // Agrupa as mensagens de erros num List<IGrouping<string, string>>
                               .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            // transforma o List<IGrouping<string, string>> num Dict<string, string[]>
                               .ToDictionary(x => x.Key, x => x.ToArray());
        }
    }
}