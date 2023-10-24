using Apteka.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Backend.DataLayer
{
    public class PharmacyDbContext:DbContext
    {
        
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> db) :
            base(db)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

