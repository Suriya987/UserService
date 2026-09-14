using UserService.BOs;
using UserService.Models;

namespace UserService.IRepository;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    Task<User?> GetUserByIdAsync(long userId);
    Task<List<User>> SearchUsersAsync(string displayName);
}