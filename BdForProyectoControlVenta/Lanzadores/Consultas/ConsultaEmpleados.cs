using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdForProyectoControlVenta.Data;

namespace BdForProyectoControlVenta.Lanzadores.Consultas
{
    public class ConsultaEmpleados
    {
        public static void Ejecutar()
        {
            //Lista los empleado de tener registros
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToArray();
                if (users.Length == 0)
                {
                    Console.WriteLine("No hay Empleados registrados.");
                    return;
                }
                // Por cada empleado da nombre cargo y si esta vacacionando
                foreach (var user in users)
                {
                    if (user.EstadoVacacional == false)
                    {
                        Console.WriteLine($"Empleado:{user.Nombre} con cargo: {user.Cargo} no se encuentra en vaciones");
                    }
                    Console.WriteLine($"Empleado:{user.Nombre} con cargo: {user.Cargo} se encuentra en vaciones");
                }

            }

        }
    }
}