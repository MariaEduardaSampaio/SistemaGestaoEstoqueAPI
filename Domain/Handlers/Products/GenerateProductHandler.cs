using Domain.Repositories;
using Domain.Entities;
using Shared.Commands;
using Domain.Commands.Inputs.Products;
using Domain.Commands.Results.Products;
using Domain.Commands.Results.Shared;

namespace Domain.Handlers.Products
{
    public class GenerateProductHandler
    {
        private readonly IProductRepository _repository;

        public GenerateProductHandler(IProductRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(GenerateProductCommand command)
        {
            try
            {
                command.Validate();
                var user = new Product(command.Name, command.Description!, command.Price, command.WeightPerUnit, command.Quantity);
                _repository.CreateProduct(user);
                var commandResult = new GenerateProductCommandResult(command.Name, command.Description!, command.Price, command.WeightPerUnit, command.Quantity);
                return new CommandResult(true, "Produto adicionado com sucesso!", commandResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao adicionar produto: {ex}");
                return new CommandResult(false, "Não foi possível adicionar produto.", null);
            }
        }
    }
}
