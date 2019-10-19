using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Pratt
{
    public class Proveedor
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string direccion { get; set; }

        public static List<Proveedor> listaProveedores = new List<Proveedor>();

        public static void AgregarProveedores(Proveedor P)
        {
            listaProveedores.Add(P);
        }

        public static void EliminarProveedores(int posicion_item)
        {
            listaProveedores.RemoveAt(posicion_item);
        }

        public static List<Proveedor> ObtenerProveedor()
        {
            return listaProveedores;
        }

        public override string ToString()
        {
            return this.RazonSocial;
        }
    }
}
