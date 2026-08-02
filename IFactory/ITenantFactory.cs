using UserService.DbContexts;

namespace UserService.IFactory;
public interface IDbChatApplicationContextFactory
{
 Task<ChatApplicationDbContext> CreateDbContextAsync();
}

