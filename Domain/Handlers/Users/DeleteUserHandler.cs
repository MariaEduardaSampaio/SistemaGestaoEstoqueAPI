using Domain.Repositories;
using Shared.Commands;
using Domain.Commands.Results.Shared;

namespace Domain.Handlers.Users
{
    public class DeleteUserHandler
    {
        private readonly IUserRepository _repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(int id)
        {
            try
            {
                var user = _repository.DeleteUser(id);

                return new CommandResult(true, "Usuário deletado com sucesso!", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao deletar usuário: {ex}");
                return new CommandResult(false, "Não foi possível deletar usuário.", null);
            }
        }
    }
}
