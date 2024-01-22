using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers.Users
{
    public class DeleteUserHandler
    {
        private readonly IUserRepository _repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Repositório inválido.");
        }

        public ICommandResult Handle(int id)
        {
            try
            {
                var user = _repository.DeleteUser(id);

                return new CommandResult(true, "Usuário deletado com sucesso!", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao deletar usuário: {ex}");
                return new CommandResult(false, "Não foi possível deletar usuário.", null);
            }
        }
    }
}
