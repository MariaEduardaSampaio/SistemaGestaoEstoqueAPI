using Domain.Commands.Results;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Users
{
    public class ReadUserByIDHandler
    {
        private readonly IUserRepository _repository;

        public ReadUserByIDHandler(IUserRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        // poderia fazer um handler direto ou preciso de um command para receber o id?

        public ICommandResult Handle(int id)
        {
            try
            {
                var user = _repository.ReadUserByID(id);
                return new CommandResult(true, "Usuário lido: ", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler usuário: {ex}");
                return new CommandResult(false, "Não foi possível ler usuário com este ID.", null);
            }
        }
    }
}
