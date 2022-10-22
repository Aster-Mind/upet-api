using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UpetApi.Entidades;

namespace UpetApi
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<OngUsers> OngUsers { get; set; }
        public DbSet <Sede> Sedes { get; set; }

    }
}
