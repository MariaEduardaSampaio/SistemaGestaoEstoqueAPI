namespace Domain.Commands.Results.Users
{
    public class GenerateUserCommandResult
    {
        private static int idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public GenerateUserCommandResult(string name, string email, string password)
        {
            Id = idCounter++;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
