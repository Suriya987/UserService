namespace UserService.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientHelper> _logger;

        public HttpClientHelper(HttpClient httpClient,ILogger<HttpClientHelper> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        public async Task<T?> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var data = await response.Content
                    .ReadFromJsonAsync<T>();

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "HTTP GET failed : {Url}", url);

                throw;
            }
        }


        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url,TRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, request);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"HTTP POST failed : {Url}", url);

                throw;
            }
        }
    }
}
