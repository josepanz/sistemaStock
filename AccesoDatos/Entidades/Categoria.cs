using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Categoria
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public static List<Categoria> listaCategoria = new List<Categoria>();

        public static void AgregarCategoria(Categoria C)
        {
            listaCategoria.Add(C);
        }

        public static void EliminarCategorias(int posicion_item)
        {
            listaCategoria.RemoveAt(posicion_item);
        }

        public static List<Categoria> ObtenerCategorias()
        {
            return listaCategoria;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
