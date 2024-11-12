using AutoMapper;
using BL.Users.Entity;
using BL.Users.Exceptions;
using NotepadWebApp.DataAccess.Entities;
using Repository.Repository;

namespace BL.Users.Provider;

public class UsersProvider : IUsersProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers(UserFilterModel filter = null)
    {
        string? nicknamePart = filter?.NicknamePart;
        string? emailPart = filter?.EmailPart;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? role = filter?.Role;

        var users = _userRepository.GetAll(u =>
            (string.IsNullOrEmpty(nicknamePart) || u.User_nickname.Contains(nicknamePart)) &&
            (string.IsNullOrEmpty(emailPart) || u.Email.Contains(emailPart)) &&
            (creationTime == null || u.CreationTime.Date == creationTime.Value.Date) &&
            (modificationTime == null || u.ModificationTime.Date == modificationTime.Value.Date) &&
            (role == null || u.Role.Equals(role))
        );

        return _mapper.Map<IEnumerable<UserModel>>(users);
    }
    

    public UserModel GetUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new UserNotFoundException("User not found");
        }

        return _mapper.Map<UserModel>(entity);
    }
}