using System;
using System.Collections.Generic;
using GeneradoBDFSharp;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;
using System.Linq;

namespace BdForProyectoControlVenta.BaseDePrueva
{
    public class VentasBDTest
    {
        public static void Ejecutar()
        {
            //listas para ventas y relacionados
            // registros de todas las ventas porproducto si no llevaron queda como 0
            var VentasSombrerosBdTest = Puente.VentasSombrerosBdTst;
            var PañuelosBdTest = Puente.VentasPañuelosBdTst;
            var VentasCamisasBdTest = Puente.VentasCamisasBdTst;
            var VentasPantalonesBdTest = Puente.VentasPantalonesBdTst;
            //fechas venta entreta
            var FechasVentasBdTest = Puente.FechasVentasBdTst;
            var FechaEntregaBdTest = Puente.FechaEntregaBdTst;
            //recaudos y totales
            var RecaudosBdTest = Puente.RecaudosBdTst;
            var TotalCompraBdTest = Puente.TotalCompraBdTst;
            var TotalSaldosComprasBdTest = Puente.TotalSaldosComprasBdTst;
            //nombres ,direcciones, codigo, tel y correos
            var CorreosBdTest = Puente.CorreosBdTst;
            var TelsBdTest = Puente.TelsBdTst;
            var CodigosTranBdTest = Puente.CodigosTranBdTst;
            var NombresClientesBdTest = Puente.NombresClientesBdTst;
            var DireccionesBdTest = Puente.DireccionesBdTst;
            //Listas a array
            // productos
            int[] VentasSombrerosBdTestArray = VentasSombrerosBdTest.ToArray();
            int[] PañuelosBdTestArray = PañuelosBdTest.ToArray();
            int[] VentasCamisasBdTestArray = VentasCamisasBdTest.ToArray();
            int[] VentasPantalonesBdTestArray = VentasPantalonesBdTest.ToArray();
            //fechas venta entreta
            DateTime[] FechasVentasBdTestArray = FechasVentasBdTest.ToArray();
            DateTime[] FechaEntregaBdTestArray = FechaEntregaBdTest.ToArray();
            //recaudos y totales
            int[] RecaudosBdTestArray = RecaudosBdTest.ToArray();
            int[] TotalCompraBdTestArray = TotalCompraBdTest.ToArray();
            int[] TotalSaldosComprasBdTestArray = TotalSaldosComprasBdTest.ToArray();
            //nombres ,direcciones, codigo, tel y correos
            String[] CorreosBdTestArray = CorreosBdTest.ToArray();
            int[] TelsBdTestArray = TelsBdTest.ToArray();
            int[] CodigosTranBdTestArray = CodigosTranBdTest.ToArray();
            String[] NombresClientesBdTestArray = NombresClientesBdTest.ToArray();
            String[] DireccionesBdTestArray = DireccionesBdTest.ToArray();
            using (var context = new ApplicationDbContext())
            {
                //cilo para agregar ventas,pedidos y unidades vendidas
                foreach (var x in NombresClientesBdTestArray)
                {
                    //Datos y add venta
                    int xIndex = Array.IndexOf(NombresClientesBdTestArray, x);
                    int RecaudoAddTest = RecaudosBdTestArray[xIndex];
                    int CodigoAddTest = CodigosTranBdTestArray[xIndex];
                    DateTime FechaAddTest = FechasVentasBdTestArray[xIndex];

                    var VentaNew = new Ventas
                    {
                        Cliente = x,
                        Recaudo = RecaudoAddTest,
                        CodTransaccion = CodigoAddTest,
                        Fechadeventa = FechaAddTest,
                    };

                    context.Ventas.Add(VentaNew);
                    context.SaveChanges();
                    int IdVentaAddTest = VentaNew.Id;
                    //Datos y add de pedido
                    string DireccionAddTest = DireccionesBdTestArray[xIndex];
                    int SaldoFaltanteAddTest = TotalSaldosComprasBdTestArray[xIndex];
                    int TelephonAddTestint = TelsBdTestArray[xIndex];
                    string TelephonAddTest = TelephonAddTestint.ToString();
                    string CorreoAddTest = CorreosBdTestArray[xIndex];
                    DateTime EntregaAddTest = FechaEntregaBdTestArray[xIndex];
                    bool EntregadoAddTest;
                    if (EntregaAddTest<FechaAddTest)
                    {
                        EntregadoAddTest = true;
                    }
                    else
                    {
                        EntregadoAddTest = false;
                    }
                    var PedidoNew = new Pedidos
                    {
                        IdVenta = IdVentaAddTest,
                        Direccion = DireccionAddTest,
                        Cliente = x,
                        SaldoFaltante = SaldoFaltanteAddTest,
                        Tel = TelephonAddTest,
                        Correo = CorreoAddTest,
                        FechaEntrega = EntregaAddTest,
                        Entregado = EntregadoAddTest

                    };

                    context.Pedidos.Add(PedidoNew);
                    context.SaveChanges();

                    //UnidadesVendidas
                    int SomberosAdd = VentasSombrerosBdTestArray[xIndex];
                    int CamisasAdd = VentasCamisasBdTestArray[xIndex];
                    int PañuelosAdd = PañuelosBdTestArray[xIndex];
                    int PantalonesAdd = VentasPantalonesBdTestArray[xIndex];
                    if (SomberosAdd<0)
                    {
                        var idSombreros = context.Productos
                        .Where(v => v.Nombre == "Sombreros")
                        .Select(v => v.Id)
                        .FirstOrDefault();

                        var sombrerosadd = new UnidadesVendidas
                        {
                            IdVenta = IdVentaAddTest,
                            IdProducto = idSombreros,
                            nProducto = "Sombreros",
                            CantidadVendida = SomberosAdd,
                            PrecioUnitario = 30000
                        };

                        context.UnidadesVendidas.Add(sombrerosadd);
                        context.SaveChanges();
                    }
                    if (CamisasAdd < 0)
                    {
                        var idCamisas = context.Productos
                        .Where(v => v.Nombre == "Camisas")
                        .Select(v => v.Id)
                        .FirstOrDefault();

                        var camisasAdd = new UnidadesVendidas
                        {
                            IdVenta = IdVentaAddTest,
                            IdProducto = idCamisas,
                            nProducto = "Camisas",
                            CantidadVendida = SomberosAdd,
                            PrecioUnitario = 20000
                        };

                        context.UnidadesVendidas.Add(camisasAdd);
                        context.SaveChanges();
                    }
                    if (PañuelosAdd < 0)
                    {
                        var idPañuelos = context.Productos
                        .Where(v => v.Nombre == "Pañuelos")
                        .Select(v => v.Id)
                        .FirstOrDefault();

                        var pañuelosadd = new UnidadesVendidas
                        {
                            IdVenta = IdVentaAddTest,
                            IdProducto = idPañuelos,
                            nProducto = "Pañuelos",
                            CantidadVendida = SomberosAdd,
                            PrecioUnitario = 12000
                        };
                        context.UnidadesVendidas.Add(pañuelosadd);
                        context.SaveChanges();
                    }
                    if (PantalonesAdd < 0)
                    {
                        var idPantalones = context.Productos
                        .Where(v => v.Nombre == "Pantalones")
                        .Select(v => v.Id)
                        .FirstOrDefault();

                        var pantalonesadd = new UnidadesVendidas
                        {
                            IdVenta = IdVentaAddTest,
                            IdProducto = idPantalones,
                            nProducto = "Pantalones",
                            CantidadVendida = PantalonesAdd,
                            PrecioUnitario = 27000
                        };
                        context.UnidadesVendidas.Add(pantalonesadd);
                        context.SaveChanges();
                    }
                   
                }
            }
        }
    }
}
