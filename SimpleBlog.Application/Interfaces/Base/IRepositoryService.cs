namespace SimpleBlog.Application.Interfaces.Base;

public interface IRepositoryService<TRequest>
{
    Task<TRequest> Add(TRequest serviceRequest);
    Task<TRequest> Edit(TRequest serviceRequest);
    IEnumerable<TRequest> GetAll();
    TRequest? GetById(Guid id);
    Task<bool> Remove(Guid id);
}
