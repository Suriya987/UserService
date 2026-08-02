using UserService.BOs;
using UserService.Models;

namespace UserService.IServices;

public interface IUserService
{
    Task<UserBO> RegisterAsync(UserBO request);
    Task<UserBO?> GetUserByIdAsync(long userId);
}