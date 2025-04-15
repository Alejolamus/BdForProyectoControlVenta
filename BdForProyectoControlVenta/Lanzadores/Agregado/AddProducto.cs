using System;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;

namespace BdForProyectoControlVenta.Lanzadores.Agregado
{
    public class AddProducto
    {
        public static void Ejecutar()
        {
            //Recoje los datos basicos
            Console.Write("Nombre de producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Número en Bodega: ");
            int nuBodega = int.Parse(Console.ReadLine());

            Console.Write("Precio: ");
            int Valor = int.Parse(Console.ReadLine());
            
            // Registra producto nuevo con Cantidad min en 0

            using (var context = new ApplicationDbContext())
            {
                var producto = new Productos
                {
                    Nombre = nombreProducto,
                    CantidadEnB = nuBodega,
                    CantidadMin = 0,
                    Precio = Valor
                };

                context.Productos.Add(producto);
                context.SaveChanges();

                Console.WriteLine("Se agregó el producto correctamente.");
            }
        }
    }
}
