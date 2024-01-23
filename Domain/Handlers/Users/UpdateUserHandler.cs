using Domain.Commands.Inputs.Users;
using Domain.Commands.Results.Users;
using Domain.Commands.Results.Shared;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Users
{
    public class UpdateUserHandler
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            try
            {
                command.Validate();

                // acho que não deveria criar um novo usuário, mas não sei como isso pode ser feito
                // pra atualizar, pq acho q dá problema por causa do ID
                var userToUpdate = new User(command.Name, command.Email, command.Password);
                _repository.UpdateUser(command.Id, userToUpdate);

                var commandResult = new UpdateUserCommandResult(command.Id, command.Name, command.Email, command.Password);
                return new CommandResult(true, "Usuário atualizado com sucesso!", commandResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar usuário: {ex}");
                return new CommandResult(false, "Não foi possível atualizar usuário.", null);
            }
        }
    }
}
