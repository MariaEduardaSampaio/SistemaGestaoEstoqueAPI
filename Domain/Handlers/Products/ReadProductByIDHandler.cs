using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Products
{
    public class ReadProductByIDHandler
    {
        private readonly IProductRepository _repository;

        public ReadProductByIDHandler(IProductRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        // poderia fazer um handler direto ou preciso de um command para receber o id?

        public ICommandResult Handle(int id)
        {
            try
            {
                var user = _repository.ReadProductByID(id);
                return new CommandResult(true, "Produto lido: ", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler produto: {ex}");
                return new CommandResult(false, "Não foi possível ler produto com este ID.", null);
            }
        }
    }
}
