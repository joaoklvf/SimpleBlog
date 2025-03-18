namespace SimpleBlog.Domain.Interfaces.Base;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IPostRepository PostRepository { get; }
    public Task CommitAsync();
    public void Dispose();
}
