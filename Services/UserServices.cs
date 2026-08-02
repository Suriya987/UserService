using UserService.BOs;
using UserService.IRepository;
using UserService.IServices;
using UserService.Models;

namespace UserService.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserBO> RegisterAsync(UserBO request)
    {
        var user = new User
        {
            DisplayName = request.DisplayName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            ProfileImageUrl = request.ProfileImageUrl,
            CreatedAt = DateTime.UtcNow,
        };

        await _userRepository.RegisterAsync(user);

        request.UserId = user.UserId;

        return request;
    }

    public async Task<UserBO?> GetUserByIdAsync(long userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
            return null;

        return new UserBO
        {
            UserId = user.UserId,
            DisplayName = user.DisplayName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImageUrl = user.ProfileImageUrl
        };
    }
}