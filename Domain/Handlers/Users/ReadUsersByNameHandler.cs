using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Users
{
    public class ReadUsersByNameHandler
    {
        private readonly IUserRepository _repository;

        public ReadUsersByNameHandler(IUserRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        // poderia fazer um handler direto ou preciso de um command para receber o nome?

        public ICommandResult Handle(string name)
        {
            try
            {
                var users = _repository.ReadUsersByName(name);
                return new CommandResult(true, "Usuários lidos: ", users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler usuários: {ex}");
                return new CommandResult(false, "Não foi possível ler usuários com este nome.", null);
            }
        }
    }
}
