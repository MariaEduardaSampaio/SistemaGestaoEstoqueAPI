using Domain.Commands.Results.Users;
using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Domain.Entities;
using Shared.Commands;
using Domain.Commands.Inputs.Users;

namespace Domain.Handlers.Users
{
    public class GenerateUserHandler
    {
        private readonly IUserRepository _repository;

        public GenerateUserHandler(IUserRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        public ICommandResult Handle(GenerateUserCommand command)
        {
            try
            {
                command.Validate();
                var user = new User(command.Name, command.Email, command.Password);
                _repository.CreateUser(user);
                var commandResult = new GenerateUserCommandResult(command.Name, command.Email, command.Password);
                return new CommandResult(true, "Usuário adicionado com sucesso!", commandResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao adicionar usuário: {ex}");
                return new CommandResult(false, "Não foi possível adicionar usuário.", null);
            }
        }
    }
}
