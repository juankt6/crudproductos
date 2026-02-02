using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProductos.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La Cédula/RUC es obligatoria")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Debe tener entre 10 y 13 dígitos")]
        public string CedulaRuc { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10)]
        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Provincia { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public bool EstaActivo { get; set; }

        [Display(Name = "Producto de Interés")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto? Producto { get; set; }

        public string? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioAplicacion? Usuario { get; set; }

        [NotMapped] 
        public string NombreCompleto => $"{Nombres} {Apellidos}";
        [Display(Name = "Vendedor Asignado")]
        public int? VendedorId { get; set; } // Puede ser nulo si nadie lo atiende aún

        [ForeignKey("VendedorId")]
        public virtual Vendedor? Vendedor { get; set; }
    }

}