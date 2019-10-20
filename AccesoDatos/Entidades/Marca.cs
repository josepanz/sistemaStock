using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Marca
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public static List<Marca> listaMarca = new List<Marca>();

        public static void AgregarMarca(Marca M)
        {
            listaMarca.Add(M);
        }

        public static void EliminarMarcas(int posicion_item)
        {
            listaMarca.RemoveAt(posicion_item);
        }

        public static List<Marca> ObtenerMarcas()
        {
            return listaMarca;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    
}
