using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsByAuthor(Guid authorId);
    }
}
