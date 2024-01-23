using Domain.Commands.Inputs.Products;
using Domain.Handlers.Products;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/products")]
    internal class ProductController
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpPost]
        [Route("")]
        public ICommandResult Post([FromBody] GenerateProductCommand command)
        {
            var handler = new GenerateProductHandler(_repository);
            return handler.Handle(command);
        }

        [HttpGet]
        [Route("getAll")]
        public ICommandResult ReadAll()
        {
            var handler = new ReadAllProductsHandler(_repository);
            return handler.Handle();
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public ICommandResult ReadByID(int id)
        {
            var handler = new ReadProductByIDHandler(_repository);
            return handler.Handle(id);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public ICommandResult ReadByName(string name)
        {
            var handler = new ReadProductByNameHandler(_repository);
            return handler.Handle(name);
        }

        [HttpGet]
        [Route("getAllByDisponibility")]
        public ICommandResult ReadAllByDisponibility(bool disponibility)
        {
            var handler = new ReadProductsByDisponibilityHandler(_repository);
            return handler.Handle(disponibility);
        }

        [HttpPut]
        [Route("update")]
        public ICommandResult Update([FromBody] UpdateProductCommand command)
        {
            var handler = new UpdateProductHandler(_repository);
            return handler.Handle(command);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ICommandResult Delete(int id)
        {
            var handler = new DeleteProductHandler(_repository);
            return handler.Handle(id);
        }
    }
}
