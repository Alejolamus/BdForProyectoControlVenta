using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BdForProyectoControlVenta.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }
        public int IdVenta { get; set; }
        [ForeignKey("IdVenta")]
        public Ventas Venta { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Cliente { get; set; }
        [Required]
        public int SaldoFaltante { get; set; }
        [Required]
        public string Tel { get; set; }
        public string Correo { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }

        public bool Entregado { get; set; }
    }
}
