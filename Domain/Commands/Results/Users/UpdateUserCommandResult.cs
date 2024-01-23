namespace Domain.Commands.Results.Users
{
    public class UpdateUserCommandResult
    {
        // mesma coisa que input só que sem o método de validação. Está certo?
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UpdateUserCommandResult(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
