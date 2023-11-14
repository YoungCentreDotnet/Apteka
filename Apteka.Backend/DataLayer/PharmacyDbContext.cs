using Apteka.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Backend.DataLayer
{
    public class PharmacyDbContext : DbContext
    {

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> db) : base(db)
        { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employe> Employes { get; set; }
    }
}

 