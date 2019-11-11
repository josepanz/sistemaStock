using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class TipoProducto
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public static List<TipoProducto> listaTipoProductos = new List<TipoProducto>();

        public static void AgregarProductos(TipoProducto TP)
        {
            listaTipoProductos.Add(TP);
        }

        public static void EliminarTipoProductos(int posicion_item)
        {
            listaTipoProductos.RemoveAt(posicion_item);
        }

        public static List<TipoProducto> ObtenerTipoProductos()
        {
            return listaTipoProductos;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
