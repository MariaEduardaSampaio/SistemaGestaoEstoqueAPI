using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetService<DataContext>();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> ReadAllUsers()
        {
            return _context.Users.OrderBy(user => user.Name).ToList();
        }

        public User ReadUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == email);
            if (user == null)
                throw new ArgumentException("Não existe usuário com este nome.");

            return user;
        }

        public User ReadUserByID(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
                throw new ArgumentException("Não existe usuário com este ID.");

            return user;
        }

        public IEnumerable<User> ReadUsersByName(string name)
        {
            return _context.Users.Where(user => user.Name.Contains(name)).OrderBy(user => user.Name).ToList();
        }

        public void UpdateUser(int id, User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public User DeleteUser(int id)
        {
            var user = ReadUserByID(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}
