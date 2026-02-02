using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProductos.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public int Cantidad { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        public string MetodoPago { get; set; } 
    }
}