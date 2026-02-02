using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CrudProductos.Models
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Cédula de Identidad")]
        [StringLength(10, ErrorMessage = "La cédula debe tener 10 dígitos")]
        public string Cedula { get; set; }

        [Display(Name = "Código de Vendedor")]
        public string CodigoVendedor { get; set; }

        [Display(Name = "Direccion de Domicilio")]
        public string Direccion { get; set; }
    }
}