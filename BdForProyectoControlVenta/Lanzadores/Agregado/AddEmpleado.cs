using System;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data; 
namespace BdForProyectoControlVenta.Lanzadores.Agregado
{
    public class AddEmpleado
    {
        public static void Ejecutar()
        {
            //Recoje datos bascicos
            Console.Write("Nombre de empleado: ");
            string nombreEmpleado = Console.ReadLine();

            Console.Write("Tipo de documento:");
            string TipoDeDocumento = Console.ReadLine();

            Console.Write("Numero de documento");
            int NumeroDocumentoEmp = int.Parse(Console.ReadLine());

            Console.Write("Cargo: ");
            string CargoEmpleado = Console.ReadLine();

            Console.Write("Contraseña: ");
            string Pass = Console.ReadLine();

            // Agrega registo de Users con los datos recolectrados
            using (var context = new ApplicationDbContext())
            {
                var User = new Users
                {
                    Nombre = nombreEmpleado,
                    Cargo = CargoEmpleado,
                    TipoDeDoc = TipoDeDocumento,
                    NumeroDeDocumento = NumeroDocumentoEmp,
                    Contraseña = Pass,
                    EstadoVacacional = false
                };

                context.Users.Add(User);
                context.SaveChanges();

                Console.WriteLine("Se agregó nuevo empleado.");
            }
        }
    }
}
