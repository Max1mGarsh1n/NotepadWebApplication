using BL.Users.Entity;

namespace NotepadWebApp.Service.Controllers.Users.Entities;

public class UsersListResponse
{
    public List<UserModel> Users { get; set; }
}