using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    class AttendanseControlContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Presence> Presences { get; set; }
        public AttendanseControlContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
