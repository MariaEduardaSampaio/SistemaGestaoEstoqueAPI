using Domain.Commands.Inputs.Users;
using Domain.Handlers.Users;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Commands;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/users")]
    public class UserController
    {
        private readonly IUserRepository _repository;

        public UserController(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetService<IUserRepository>();
        }

        [HttpPost]
        [Route("create")]
        public ICommandResult Post([FromBody] GenerateUserCommand command)
        {
            var handler = new GenerateUserHandler(_repository);
            return handler.Handle(command);
        }

        [HttpGet]
        [Route("getByEmail/{email}")]
        public ICommandResult ReadByEmail(string email)
        {
            var handler = new ReadUserByEmailHandler(_repository);
            return handler.Handle(email);
        }

        [HttpGet]
        [Route("getByID/{id}")]
        public ICommandResult ReadByID(int id)
        {
            var handler = new ReadUserByIDHandler(_repository);
            return handler.Handle(id);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public ICommandResult ReadByName(string name)
        {
            var handler = new ReadUsersByNameHandler(_repository);
            return handler.Handle(name);
        }

        [HttpGet]
        [Route("getAll/{id}")]
        public ICommandResult ReadAll(int id)
        {
            var handler = new ReadAllUsersHandler(_repository);
            return handler.Handle();
        }

        [HttpPut]
        [Route("update")]
        public ICommandResult Update([FromBody] UpdateUserCommand command)
        {
            var handler = new UpdateUserHandler(_repository);
            return handler.Handle(command);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ICommandResult Delete(int id)
        {
            var handler = new DeleteUserHandler(_repository);
            return handler.Handle(id);
        }
    }
}
