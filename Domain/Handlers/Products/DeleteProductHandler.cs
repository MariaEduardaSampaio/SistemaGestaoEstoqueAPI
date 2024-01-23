using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Products
{
    public class DeleteProductHandler
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(int id)
        {
            try
            {
                var product = _repository.DeleteProduct(id);
                return new CommandResult(true, "Produto deletado com sucesso!", product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao deletar produto: {ex}");
                return new CommandResult(false, "Não foi possível deletar produto.", null);
            }
        }
    }
}
