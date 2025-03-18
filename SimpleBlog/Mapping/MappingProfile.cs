using AutoMapper;
using SimpleBlog.Application.Commands.PostCommand;
using SimpleBlog.Application.Commands.UserCommand;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        EntityToViewModel();
        ViewModelToCommand();
    }

    private void EntityToViewModel()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<Post, PostViewModel>();
    }

    private void ViewModelToCommand()
    {
        CreateMap<UserViewModel, CreateUserCommand>();
        CreateMap<UserViewModel, UpdateUserCommand>();
        CreateMap<PostViewModel, CreatePostCommand>();
        CreateMap<PostViewModel, UpdatePostCommand>();
    }
}
