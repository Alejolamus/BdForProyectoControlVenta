﻿using System;
using BdForProyectoControlVenta.Lanzadores.Consultas;
using BdForProyectoControlVenta.Lanzadores.Modificado;
namespace BdForProyectoControlVenta.Lanzadores.LanzadoresCargosProb
{
    public class LanzadorRepartidor
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Consulta de pedidos");
            Console.WriteLine("2. Consulta de pedido particular");
            Console.WriteLine("3. Actualizar entrega");

            string opcion = Console.ReadLine();
            //if para las 3 posibles opciones
            if (opcion == "1")
            {
                ConsultaPedidos.Ejecutar();
            }
            else if (opcion == "2")
            {
                ConsultaPedParticular.Ejecutar();
            }
            else if (opcion == "3")
            {
                ActualizadorEstadoEntregas.Ejecutar();
            }


        }
    }
}