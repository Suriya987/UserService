using Microsoft.EntityFrameworkCore;
using UserService.BOs;
using UserService.DbContexts;
using UserService.IFactory;
using UserService.IRepository;
using UserService.Models;

namespace UserService.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbChatApplicationContextFactory _tenantDbContextFactory;

    public UserRepository(IDbChatApplicationContextFactory tenantDbContextFactory)
    {
        _tenantDbContextFactory = tenantDbContextFactory;
    }

    public async Task RegisterAsync(User user)
    {
        try
        {
            await using var context = await _tenantDbContextFactory.CreateDbContextAsync();

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<User?> GetUserByIdAsync(long userId)
    {
        await using var context = await _tenantDbContextFactory.CreateDbContextAsync();

        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}