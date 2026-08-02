using Microsoft.EntityFrameworkCore;
using UserService.DbContexts;
using UserService.IFactory;

namespace UserService.Factory;

public class DbChatApplicationContextFactory : IDbChatApplicationContextFactory
{
    private readonly IDbContextFactory<ChatApplicationDbContext> _factory;

    public DbChatApplicationContextFactory(IDbContextFactory<ChatApplicationDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<ChatApplicationDbContext> CreateDbContextAsync()
    {
        return await _factory.CreateDbContextAsync();
    }
}