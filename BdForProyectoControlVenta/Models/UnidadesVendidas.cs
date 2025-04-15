using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BdForProyectoControlVenta.Models
{
    public class UnidadesVendidas
    {
        [Key]
        public int Id { get; set; }

        public int IdVenta { get; set; }
        [ForeignKey("IdVenta")]
        public Ventas Venta { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Productos Producto { get; set; }
        public string nProducto { get; set; }

        [Required]
        public int CantidadVendida { get; set; }
        [Required]
        public int PrecioUnitario { get; set; }

    }
}
