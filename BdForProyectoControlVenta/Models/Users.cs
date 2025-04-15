using System;
using System.ComponentModel.DataAnnotations;

namespace BdForProyectoControlVenta.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string TipoDeDoc { get; set; }

        [Required]
        public int NumeroDeDocumento { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public bool EstadoVacacional { get; set; }
    }
}
