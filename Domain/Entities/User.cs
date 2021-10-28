namespace Domain.Entities
{
    public class User
    {
        public string Name { get; }
        public string Email { get; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}