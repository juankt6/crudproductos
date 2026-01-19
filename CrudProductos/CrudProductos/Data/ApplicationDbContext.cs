using Microsoft.EntityFrameworkCore;
using CrudProductos.Models;

namespace CrudProductos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}