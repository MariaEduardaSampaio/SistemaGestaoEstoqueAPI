using Domain.Commands.Inputs.Products;
using Domain.Entities;
using Domain.Handlers.Products;
using Domain.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Commands;

namespace Api.Controllers
{
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
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public ICommandResult ReadByID(int id)
        {
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public ICommandResult ReadByName(int id)
        {
        }

        [HttpGet]
        [Route("getAll/{id}")]
        public ICommandResult ReadAll(int id)
        {
        }

        [HttpGet]
        [Route("getAllByDisponibility")]
        public ICommandResult ReadAllByDisponibility(int id)
        {
        }

        [HttpPut]
        [Route("update")]
        public ICommandResult Update([FromBody] GenerateProductCommand command)
        {
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ICommandResult Delete(int id)
        {
        }
    }
}
