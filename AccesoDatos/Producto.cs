using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Producto
    {
        public string descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public TipoProducto tipoProducto { get; set; }
        public Proveedor proveedor { get; set; }
        public Double precio { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public static List<Producto> listaProductos = new List<Producto>();

        public static void AgregarProductos(Producto P)
        {
            listaProductos.Add(P);
        }

        public static void EliminarProductos(int posicion_item)
        {
            listaProductos.RemoveAt(posicion_item);
        }

        public static List<Producto> ObtenerProductos()
        {
            return listaProductos;
        }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
}
