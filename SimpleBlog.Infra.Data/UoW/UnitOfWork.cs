using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Infra.Data.Context;

namespace SimpleBlog.Infra.Data.UoW;

public class UnitOfWork(AppDatabaseContext context, IPostRepository postRepository, IUserRepository userRepository) : IUnitOfWork, IDisposable
{
    private readonly AppDatabaseContext _context = context;

    public IUserRepository UserRepository { get; } = userRepository;
    public IPostRepository PostRepository { get; } = postRepository;

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
