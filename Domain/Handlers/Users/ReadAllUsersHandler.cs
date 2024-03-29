﻿using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Users
{
    public class ReadAllUsersHandler
    {
        private readonly IUserRepository _repository;

        public ReadAllUsersHandler(IUserRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle()
        {
            try
            {
                var users = _repository.ReadAllUsers();
                return new CommandResult(true, "Usuários lidos: ", users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler usuários: {ex}");
                return new CommandResult(false, "Não foi possível ler usuários.", null);
            }
        }
    }
}
