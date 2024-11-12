﻿using AutoMapper;
using BL.Users.Entity;
using BL.Users.Exceptions;
using NotepadWebApp.DataAccess.Entities;
using NotepadWebApp.Repository;
using Repository.Repository;

namespace BL.Users.Manager;

public class UsersManager : IUsersManager
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel createModel)
    {
        //validation

        var entity = _mapper.Map<UserEntity>(createModel);
        entity = _usersRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }

    public void DeleteUser(int id)
    {
        var entity = _usersRepository.GetById(id);
        try
        {
            _usersRepository.Delete(entity);
        }
        catch (Exception e)
        {
            throw new UserNotFoundException(e.Message);
        }
    }

    public UserModel UpdateUser(UpdateUserModel updateModel)
    {
        //validation

        var entity = _mapper.Map<UserEntity>(updateModel);
        entity = _usersRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
}