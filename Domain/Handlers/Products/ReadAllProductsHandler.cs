using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Products
{
    public class ReadAllProductsHandler
    {
        private readonly IProductRepository _repository;

        public ReadAllProductsHandler(IProductRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle()
        {
            try
            {
                var users = _repository.ReadAllProducts();
                return new CommandResult(true, "Produtos lidos: ", users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler produtos: {ex}");
                return new CommandResult(false, "Não foi possível ler produtos.", null);
            }
        }
    }
}
