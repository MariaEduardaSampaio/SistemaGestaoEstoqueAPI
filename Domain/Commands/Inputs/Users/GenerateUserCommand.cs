﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Inputs.Users
{
    public class GenerateUserCommand
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public GenerateUserCommand(string name, string email, string password)
        {
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
