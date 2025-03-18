using MediatR;

namespace SimpleBlog.Domain.Interfaces;

public interface IEventBus
{
    public Task<K> Send<T, K>(T command) where T : IRequest<K>;

    public Task Publish<T>(T command) where T : INotification;
}
