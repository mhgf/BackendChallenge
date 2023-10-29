using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Enum
{
    public class UserType : Enumeration
    {
        public UserType(int id, string name)
        : base(id, name)
        {
        }

        public string Value { get; private set; }

        public static UserType COMMON = new(0, "COMMON");
        public static UserType MERCHANT = new(1, "MERCHANT");

    }
}
