using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Users
{
    public class ReadUserByEmailHandler
    {
        private readonly IUserRepository _repository;

        public ReadUserByEmailHandler(IUserRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        // poderia fazer um handler direto ou preciso de um command para receber a string email?

        public ICommandResult Handle(string email)
        {
            try
            {
                var user = _repository.ReadUserByEmail(email);
                return new CommandResult(true, "Usuário lido: ", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler usuário: {ex}");
                return new CommandResult(false, "Não foi possível ler usuário com este email.", null);
            }
        }
    }
}
