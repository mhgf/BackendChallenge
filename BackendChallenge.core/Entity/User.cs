using BackendChallenge.core.Entity.Validations;
using BackendChallenge.core.Enum;

namespace BackendChallenge.core.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public UserType Type { get; private set; } = UserType.COMMON;
        public decimal Balance { get; private set; } = 100;

        private List<Transaction> _sent = new();
        public IReadOnlyCollection<Transaction> Sent => _sent.AsReadOnly();

        private List<Transaction> _received = new();
        public IReadOnlyCollection<Transaction> Received => _received.AsReadOnly();

        private User() { }
        private User(string name, string email, string document, string password, UserType type)
        {
            Name = name;
            Email = email;
            Document = new String(document.Where(x => char.IsDigit(x)).ToArray());
            Password = password;
            Type = type;
            Validate(this, new UserValidator());
        }
        
        public bool HaveBalance(decimal compare)
        {
            return Balance - compare > 0;
        }

        public bool CanTransfer() => this.Type != UserType.MERCHANT;

        public void AddBalance(decimal value) => Balance += value;
        public void RemoveBalance(decimal value) => Balance -= value;

        public static User Create(string name, string email, string document, string password, string type) => new(name, email, document, password, Enumeration.Parce<UserType>(type));
    }
}
