using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Infra.Data.Context;

namespace SimpleBlog.Infra.Data.Repository.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDatabaseContext _db;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(AppDatabaseContext appDatabaseContext)
    {
        _db = appDatabaseContext;
        _dbSet = _db.Set<TEntity>();
    }

    public void Create(TEntity entity) =>
        _dbSet.Add(entity);

    public void Delete(TEntity entity) =>
        _dbSet.Remove(entity);

    public void Dispose() =>
        GC.SuppressFinalize(this);

    public IQueryable<TEntity> GetAll() =>
        _dbSet;

    public TEntity? GetById(Guid id) =>
        _dbSet.Find(id);

    public int SaveChanges() =>
        _db.SaveChanges();

    public void Update(TEntity entity) =>
        _dbSet.Update(entity);

}

