using API.BlogNews.Interfaces;

namespace API.BlogNews.Helpers
{
    public class ProviderResult<T> : IProviderResult<T>
    {
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }

        public ProviderResult(T? result, string? errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
