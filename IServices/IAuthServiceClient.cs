using UserService.BOs;

namespace UserService.IServices
{
    public interface IAuthServiceClient
    {
        Task<bool> SaveCredentialAsync(SaveCredenetialRequestBO request);
    }
}
