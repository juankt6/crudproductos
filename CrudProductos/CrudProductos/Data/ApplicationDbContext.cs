using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrudProductos.Models;

namespace CrudProductos.Data
{
 
    public class ApplicationDbContext : IdentityDbContext <UsuarioAplicacion>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venta> Ventas { get; set; }
     
    }
}