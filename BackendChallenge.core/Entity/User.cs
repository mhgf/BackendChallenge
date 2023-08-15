using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BackendChallenge.core.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }

        public decimal Balance { get; private set; } = 0;

        private User() { }
        private User(string name, string email, string document, string password)
        {
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }

        public static User Create(string name, string email, string document, string password) => new User(name, email, document, password);
    }
}
