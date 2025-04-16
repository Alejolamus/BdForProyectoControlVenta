using System;
using System.Collections.Generic;
using GeneradoBDFSharp;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;
using System.Linq;

namespace BdForProyectoControlVenta.BaseDePrueva
{
    public class ProductosBSTest
    {
        public static void Ejecutar()
        {
            //llamo laslistas desde f#
            var productosTestBdProv = Puente.ProductosAddTestBase;
            var cantidadesTestBdProv = Puente.CantidadesEnBodegaTestBase;
            var preciosTestBdProv = Puente.PreciosTestBase;
            //Las paso a array
            string[] productosTestBdProvArray = productosTestBdProv.ToArray();
            int[] cantidadesTestBdProvvArray = cantidadesTestBdProv.ToArray();
            int[] preciosTestBdProvArray = preciosTestBdProv.ToArray();
            //cilo para agregar usuarios
            using (var context = new ApplicationDbContext())
            {
                foreach (var x in productosTestBdProvArray)
                {
                    int xIndex = Array.IndexOf(productosTestBdProvArray, x);
                    int CantidadAddTest = cantidadesTestBdProvvArray[xIndex];
                    int precioAddTest = preciosTestBdProvArray[xIndex];
                    var NewProducto = new Productos
                    {
                        Nombre = x,
                        CantidadEnB = CantidadAddTest,
                        CantidadMin = 0,
                        Precio = precioAddTest
                    };

                    context.Productos.Add(NewProducto);
                    context.SaveChanges();
                }
                Console.WriteLine("Se agrego los primeros productos");

            }
        }
    }
}
