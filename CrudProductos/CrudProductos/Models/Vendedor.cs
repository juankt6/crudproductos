using System.ComponentModel.DataAnnotations;

namespace CrudProductos.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } // En un sistema real, esto iría encriptado

        public string Telefono { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        // Relación: Un vendedor atiende muchos clientes
        public virtual ICollection<Cliente>? Clientes { get; set; }
    }
}