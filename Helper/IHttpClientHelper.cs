namespace UserService.Helper
{
    public interface IHttpClientHelper
    {
        Task<T?> GetAsync<T>(string url);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url,TRequest request);
    }
}
