using System;
using System.Collections.Generic;
using GeneradoBDFSharp;
using BdForProyectoControlVenta.Models;
using BdForProyectoControlVenta.Data;
using System.Linq;

namespace BdForProyectoControlVenta.BaseDePrueva
{
    public class UsersBDTest
    {
        public void MostrarDatos()
        {
            //llamo laslistas desde f#
            var usersTestBdProv = Puente.EmpleadosCuatroCargos;
            var tipoDocTestBdProv = Puente.TipoDeDocEmpleadosOrdenados;
            var documentsTestBdProv = Puente.DocEmpleadosOrdenados;
            var cargosTestBdProv = Puente.CargosEmpleadosOrdenados;
            var contraseñasTestBdProv = Puente.ContraseñasEmpleadoOrdenados;
            //Las paso a array
            string[] usersTestBdProvArray = usersTestBdProv.ToArray();
            string[] tipoDocTestBdProvArray = tipoDocTestBdProv.ToArray();
            int[] documentsTestBdProvArray = documentsTestBdProv.ToArray();
            string[] cargosTestBdProvArray = cargosTestBdProv.ToArray();
            string[] contraseñasTestBdProvArray = contraseñasTestBdProv.ToArray();
            //cilo para agregar usuarios
            using (var context = new ApplicationDbContext())
            {
                foreach (var x in usersTestBdProvArray)
                {
                    int xIndex = Array.IndexOf(usersTestBdProvArray, x);
                    string CargoAddTest = cargosTestBdProvArray[xIndex];
                    int DocuAddTest = documentsTestBdProvArray[xIndex];
                    string TiDocAddTest = tipoDocTestBdProvArray[xIndex];
                    string PaddAddTest = contraseñasTestBdProvArray[xIndex];
                    var User = new Users
                    {
                        Nombre = x,
                        Cargo = CargoAddTest,
                        TipoDeDoc = TiDocAddTest,
                        NumeroDeDocumento = DocuAddTest,
                        Contraseña = PaddAddTest,
                        EstadoVacacional = false
                    }
                   
                }
                Console.WriteLine("Se agrego los primeros usuarios recuerde:");
                Console.WriteLine("Admin: Jonh Russell Pass: as578dwasd52 ");
            }
        }
    }
}
