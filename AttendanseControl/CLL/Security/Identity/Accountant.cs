using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Identity
{
    public class Accountant : User
    {
        public Accountant(int userId, string name, string email)
            : base(userId, name, email, 2)
        {
        }
    }
}

