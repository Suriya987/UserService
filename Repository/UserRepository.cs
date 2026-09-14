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

    public async Task<List<User>> SearchUsersAsync(string displayName)
    {
        try
        {
            await using var context = await _tenantDbContextFactory.CreateDbContextAsync();

            displayName = displayName.Trim();

            return await context.Users
                .AsNoTracking()
                .Where(x =>
                    x.DisplayName.Contains(displayName))
                .OrderBy(x =>
                    x.DisplayName == displayName ? 0 :
                    x.DisplayName.StartsWith(displayName) ? 1 :
                    2)
                .ThenBy(x => x.DisplayName)
                .Take(15)
                .ToListAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<User>();
        }
    }
}