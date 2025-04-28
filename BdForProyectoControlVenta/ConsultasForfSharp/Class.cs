using System;
using System.Collections.Generic;
using System.Linq;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;
using BdForProyectoControlVenta.Lanzadores.LanzadoresCargosProb;
using BdForProyectoControlVenta.BaseDePrueva;
using System.Text.Json;

namespace BdForProyectoControlVenta.ConsultasForfSharp
{
    public class Class
    {
        public static List<List<RegistroVenta>> ListaGlobalVentasProductos { get; private set; }
        public static void Ejecutar()
        {
            using (var context = new ApplicationDbContext())
            {
                //Crea Array con productos Extistentes
                var ProductosExistentes = context.Productos
                    .Select(v => v.Nombre)
                    .ToArray();
                    //Listas de Registos (Cantidades,IDS, Fechas) de los productos
                List<List<RegistroVenta>> listaDeListasVentasProductos = new List<List<RegistroVenta>>();
                    //.
                foreach (var nombreProducto in ProductosExistentes)
                {
                        //Lista de idventa cantidad y fecha por producto
                    List<RegistroVenta> listaDeVentas = new List<RegistroVenta>();
                        //.
                    // Obtener las unidades vendidas de este producto y su id
                    var ventasProducto = context.UnidadesVendidas
                        .Where(f => f.nProducto == nombreProducto)
                        .Select(f=> new {f.CantidadVendida, f.IdVenta})
                        .ToList();
                    foreach (var unidad in ventasProducto)
                    {
                        // Buscar la fecha de la venta desde la tabla Ventas
                        var fechaVenta = context.Ventas
                            .Where(v => v.Id == unidad.IdVenta)
                            .Select(v => v.Fechadeventa)
                            .FirstOrDefault(); // Para obtener una sola fecha DateTime

                        listaDeVentas.Add(new RegistroVenta
                        {
                            Fecha = fechaVenta,
                            Cantidad = unidad.CantidadVendida,
                            Nombre = nombreProducto
                        });
                    }
                    listaDeListasVentasProductos.Add(listaDeVentas);
                }
                ListaGlobalVentasProductos = listaDeListasVentasProductos;
            }
            string ruta = "datos_ventas.json";

            var opcionesJson = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(ListaGlobalVentasProductos, opcionesJson);
            System.IO.File.WriteAllText(ruta, json);

        }
    }
}