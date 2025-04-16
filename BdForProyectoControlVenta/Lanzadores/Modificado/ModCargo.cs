using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdForProyectoControlVenta.Data;

namespace BdForProyectoControlVenta.Lanzadores.Modificado
{
    public class ModCargo
    {
        public static void Ejecutar()
        {
            //DAtos empleado
            Console.WriteLine("Nombre de Empleado");
            string NombreEmpleado = Console.ReadLine();
            Console.WriteLine("Tipo de documento");
            string TD = Console.ReadLine();
            Console.WriteLine("Numero de documento");
            int DocEmp = int.Parse(Console.ReadLine());
            using (var context = new ApplicationDbContext())
            {
                //Cambia cargo
                var usermod = context.Users
                    .Where(w => w.Nombre == NombreEmpleado && w.TipoDeDoc == TD && w.NumeroDeDocumento == DocEmp)
                    .FirstOrDefault();
                if (usermod == null)
                {
                    Console.WriteLine("Empleado no encontrado");
                }
                else
                {
                    Console.WriteLine("Nuevo Cargo");
                    string NuevoCargos = Console.ReadLine();
                    usermod.Cargo = NuevoCargos;
                    context.SaveChanges();
                }
            }

        }
    }
}