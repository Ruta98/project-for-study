using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, string email)
            : base(userId, name, email, 1)
        {
        }
    }
}
