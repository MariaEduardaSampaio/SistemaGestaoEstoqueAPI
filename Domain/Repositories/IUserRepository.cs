using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User ReadUserByID(int id);
        User ReadUserByEmail(string email);
        IEnumerable<User> ReadUsersByName(string name);
        IEnumerable<User> ReadAllUsers();
        void UpdateUser(int id, User user);
        User DeleteUser(int id);

    }
}
