using UserService.BOs;
using UserService.IRepository;
using UserService.IServices;
using UserService.Models;

namespace UserService.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthServiceClient _authClient;

    public UserServices(IUserRepository userRepository, IAuthServiceClient authClient)
    {
        _userRepository = userRepository;
        _authClient = authClient;
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
            UpdatedAt=DateTime.UtcNow
        };

        await _userRepository.RegisterAsync(user);

        //Make Auth Service call
        var AuthClientRequest = new SaveCredenetialRequestBO
        {
            UserId = user.UserId,
            Password = request.Password,
            Email = request.Email
        };


        var result = await _authClient.SaveCredentialAsync(AuthClientRequest);


        request.UserId = user.UserId;
        request.Password = null;

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