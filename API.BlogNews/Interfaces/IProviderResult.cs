namespace API.BlogNews.Interfaces
{
    public interface IProviderResult<T>
    {
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
