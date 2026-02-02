using System.ComponentModel.DataAnnotations;

namespace CrudProductos.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string? CodigoInterno { get; set; }
    }
}