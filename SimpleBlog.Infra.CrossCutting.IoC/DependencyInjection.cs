using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.CommandHandlers.PostCommandHandlers;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Services;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Domain.Interfaces.Base;
using SimpleBlog.Domain.Models;
using SimpleBlog.Infra.CrossCutting.Bus;
using SimpleBlog.Infra.Data.Repository;
using SimpleBlog.Infra.Data.UoW;

namespace SimpleBlog.Infra.CrossCutting.IoC;

public static class DependencyInjection
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IEventBus, EventBus>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ILoginService, LoginService>();

        services.AddScoped<IRequestHandler<CreatePostCommand, Post>, CreatePostCommandHandler>();
        services.AddScoped<IRequestHandler<UpdatePostCommand, Post>, UpdatePostCommandHandler>();
        services.AddScoped<IRequestHandler<DeletePostCommand, Post>, DeletePostCommandHandler>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<IWebSocketService, WebSocketService>();
    }
}
