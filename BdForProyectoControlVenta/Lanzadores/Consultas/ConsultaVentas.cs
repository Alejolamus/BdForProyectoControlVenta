using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdForProyectoControlVenta.Data;
namespace BdForProyectoControlVenta.Lanzadores.Consultas
{
    public class ConsultaVentas
    {
        public static void Ejecutar()
        {//Lista las ventas con sus atributos
            using (var context = new ApplicationDbContext())
            {
                var ventas = context.Ventas.ToArray();
                if (ventas.Length == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("Lista de ventas realizadas:");
                foreach (var venta in ventas)
                {
                    Console.WriteLine($"- Venta al cliente {venta.Cliente} realizada el dia: {venta.Fechadeventa}, con un recaudo de {venta.Recaudo} registrado en la trasaccion {venta.CodTransaccion}");
                }
            }

        }
    }
}