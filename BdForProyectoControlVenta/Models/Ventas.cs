using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BdForProyectoControlVenta.Models
{
    public class Ventas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cliente { get; set; }

        public int Recaudo { get; set; }

        public int CodTransaccion { get; set; }

        [Required]
        public DateTime Fechadeventa { get; set; } = DateTime.Now;
        public List<UnidadesVendidas> UnidadesVendidas { get; set; } = new List<UnidadesVendidas>();
        public List<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
