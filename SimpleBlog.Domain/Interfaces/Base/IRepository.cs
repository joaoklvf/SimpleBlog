namespace SimpleBlog.Domain.Interfaces.Base;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    TEntity? GetById(Guid id);
    IQueryable<TEntity> GetAll();
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    int SaveChanges();
}
