using AutoMapper;
using BL.Users.Manager;
using BL.Users.Provider;
using Microsoft.EntityFrameworkCore;
using NotepadWebApp.DataAccess;
using NotepadWebApp.DataAccess.Entities;
using NotepadWebApp.Repository.Repository;
using NotepadWebApp.Service.Settings;
using Repository.Repository;

namespace NotepadWebApp.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, NotepadSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<UserEntity>>(x => 
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<NotepadDbContext>>()));
        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}