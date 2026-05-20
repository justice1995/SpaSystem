using Auth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public UserStatus Status { get; private set; }
        
        private User()
        {

        }

        public User(string name, string email, string password) { 
            Id = Guid.NewGuid();
            Name= name;
            Email= email;
            Password= password;
            Status = UserStatus.Active;
        }

    }
}
