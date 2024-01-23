using Domain.Commands.Results.Shared;
using Domain.Repositories;
using Shared.Commands;

namespace Domain.Handlers.Products
{
    public class ReadProductsByDisponibilityHandler
    {
        private readonly IProductRepository _repository;

        public ReadProductsByDisponibilityHandler(IProductRepository _repository)
        {
            this._repository = _repository ?? throw new ArgumentNullException("Repositório inválido.");
        }
        // poderia fazer um handler direto ou preciso de um command para receber o bool?

        public ICommandResult Handle(bool disponibility)
        {
            try
            {
                var users = _repository.ReadAllProductsByDisponibility(disponibility);
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
