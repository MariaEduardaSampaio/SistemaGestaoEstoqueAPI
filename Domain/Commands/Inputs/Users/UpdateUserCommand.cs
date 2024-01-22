using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Inputs.Users
{
    public class UpdateUserCommand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UpdateUserCommand(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public void Validate()
        {
            if (Name.Length == 0 || Name == null)
                throw new ArgumentException("Nome de usuário não pode ser nulo.");

            if (Email.Length == 0 || Email.Length == 0)
                throw new ArgumentException("Email de usuário não pode ser nulo.");

            if (Password.Length < 8 || !Password.Any(char.IsNumber))
                throw new ArgumentException("Senha de usuário deve ter pelo menos 8 caracteres e conter ao menos 1 número.");
        }
    }
}
