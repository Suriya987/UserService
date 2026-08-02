using UserService.IServices;
using UserService.BOs;

namespace UserService.Services
{
        public class AuthServiceClient : IAuthServiceClient
        {
            private readonly HttpClient _httpClient;

            public AuthServiceClient(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }


            public async Task<bool> SaveCredentialAsync(SaveCredenetialRequestBO request)
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "api/auth/save-credential",
                    request);


                return response.IsSuccessStatusCode;
            }
        
    }
}
