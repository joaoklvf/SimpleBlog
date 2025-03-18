using MediatR;
using SimpleBlog.Domain.Interfaces;

namespace SimpleBlog.Infra.CrossCutting.Bus;

public class EventBus(IMediator mediator) : IEventBus
{
    private readonly IMediator _mediator = mediator;

    public Task Publish<T>(T command) where T : INotification =>
        _mediator.Publish(command);

    public Task<K> Send<T, K>(T command) where T : IRequest<K> =>
        _mediator.Send(command);
}
