using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class UnidadMedida
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }

        public static List<UnidadMedida> listaUnidad = new List<UnidadMedida>();

        public static void AgregarUnidad(UnidadMedida UM)
        {
            listaUnidad.Add(UM);
        }

        public static void EliminarUnidad(int posicion_item)
        {
            listaUnidad.RemoveAt(posicion_item);
        }

        public static List<UnidadMedida> ObtenerUnidad()
        {
            return listaUnidad;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
