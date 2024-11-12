using AutoMapper;
using BL.Users.Entity;
using NotepadWebApp.Service.Controllers.Entities.UserEntities;
using NotepadWebApp.Service.Controllers.Users.Entities;

namespace NotepadWebApp.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UserFilter, UserFilterModel>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}