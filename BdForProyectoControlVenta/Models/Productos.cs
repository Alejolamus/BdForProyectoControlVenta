using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BdForProyectoControlVenta.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int CantidadEnB { get; set; }

        [Required]
        public int CantidadMin { get; set; }
        [Required]
        public int Precio { get; set; }
        public List<UnidadesVendidas> UnidadesVendidas { get; set; } = new List<UnidadesVendidas>();
    }
}
