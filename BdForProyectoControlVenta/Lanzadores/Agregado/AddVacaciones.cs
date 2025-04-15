using System;
using System.Linq;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;

namespace BdForProyectoControlVenta.Lanzadores.Agregado
{
    public class AddVacaciones
    {
        public static void Ejecutar()
        {
            //Datos de Reconocimiento de empleado
            Console.WriteLine("Nombre de Empleado");
            string NombreEmpleado = Console.ReadLine();
            Console.WriteLine("Tipo de documento");
            string TD = Console.ReadLine();
            Console.WriteLine("Numero de documento");
            int DocEmp = int.Parse(Console.ReadLine());
            // Cambia estado vacacional a True
            using (var context = new ApplicationDbContext())
            {
                var usermod = context.Users
                    .Where(w => w.Nombre == NombreEmpleado && w.TipoDeDoc == TD && w.NumeroDeDocumento == DocEmp)
                    .FirstOrDefault();
                if (usermod == null)
                {
                    Console.WriteLine("Empleado no encontrado");
                }
                else
                {
                    usermod.EstadoVacacional = true;
                    context.SaveChanges();
                }
            }

        }
    }
}