using BL.Users.Entity;

namespace BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(UserFilterModel filter = null);
    UserModel GetUserInfo(int id);
}