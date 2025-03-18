using AutoMapper;
using SimpleBlog.Application.ViewModels;
using SimpleBlog.Domain.Models;

namespace SimpleBlog.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        EntityToViewModel();
        ViewModelToEntity();
    }

    private void EntityToViewModel()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<Post, PostViewModel>();
    }

    private void ViewModelToEntity()
    {
        CreateMap<UserViewModel, User>();
        CreateMap<PostViewModel, Post>();
    }
}
