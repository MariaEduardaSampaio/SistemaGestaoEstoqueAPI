using Domain.Commands.Inputs.Products;
using Domain.Commands.Results.Products;
using Domain.Commands.Results.Shared;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Products
{
    public class UpdateProductHandler
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
            try
            {
                command.Validate();
                
                var product = new Product(command.Name, command.Description, command.Price, command.WeightPerUnit, command.Quantity);
                _repository.UpdateProduct(product);

                var commandResult = new UpdateProductCommandResult(product.Id, product.IsAvailable, product.Name, product.Description, product.Price, product.WeightPerUnit, product.Quantity, product.AddedToStockDate);
                return new CommandResult(true, "Produto atualizado com sucesso!", commandResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar produto: {ex}");
                return new CommandResult(false, "Não foi possível atualizar produto.", null);
            }
        }
    }
}
