using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdForProyectoControlVenta.Data;
namespace BdForProyectoControlVenta.Lanzadores.Modificado
{
    public class ActualizadorEstadoEntregas
    {
        public static void Ejecutar()
        {
            using (var context = new ApplicationDbContext())
            {
                // Solicitar datos al usuario
                Console.Write("Ingrese el nombre del cliente: ");
                string nombreclient = Console.ReadLine();

                Console.Write("Ingrese la fecha de venta con formato dd/MM/yyyy HH:mm:ss: ");
                string fechav = Console.ReadLine();

                DateTime fechaventa;
                if (!DateTime.TryParseExact(fechav, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out fechaventa))
                {
                    Console.WriteLine("Formato de fecha incorrecto.");
                    return;
                }

                // Buscar ID de la venta
                var venta = context.Ventas
                    .Where(p => p.Cliente == nombreclient && p.Fechadeventa == fechaventa)
                    .FirstOrDefault();

                if (venta == null)
                {
                    Console.WriteLine("No se encontró una venta con los datos ingresados.");
                    return;
                }

                int IdvenReport = venta.Id;
                var ActuPedido = context.Pedidos
                   .Where(r => r.IdVenta == IdvenReport)
                   .FirstOrDefault();
                ActuPedido.Entregado = true;
                context.SaveChanges();
            }
        }
    }
}
