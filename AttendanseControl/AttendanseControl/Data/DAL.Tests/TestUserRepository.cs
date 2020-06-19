using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    class TestUserRepository : BaseRepository<User>
    {
        public TestUserRepository(DbContext context)
            : base(context)
        {
        }

    }
}
