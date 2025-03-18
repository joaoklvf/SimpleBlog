using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Models;
using SimpleBlog.Infra.Data.Context;
using SimpleBlog.Infra.Data.Repository.Base;

namespace SimpleBlog.Infra.Data.Repository;

public class PostRepository(AppDatabaseContext context) : Repository<Post>(context), IPostRepository
{
    public IEnumerable<Post> GetPostsByAuthor(Guid authorId)
    {
        return _dbSet.Where(x => x.Author.Id == authorId);
    }
}