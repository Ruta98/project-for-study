using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Identity
{
    public abstract class User
    {
        public User(int userId, string name, string email, int userType)
        {
            UserID = userId;
            Name = name;
            UserType = userType;
            Email = email;

        }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int UserType { get; set; }
        public string Email { get; set; }
    }
}
