using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class UnidadMedida
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }

        public static List<UnidadMedida> listaUnidad = new List<UnidadMedida>();

        public static UnidadMedida ObtenerUnidad(int id)
        {
            UnidadMedida unidad = null;

            if (listaUnidad.Count == 0)
            {
                UnidadMedida.ObtenerUnidades();
            }

            foreach (UnidadMedida  u in listaUnidad)
            {
                if (u.codigo == id)
                {
                    unidad = u;
                    break;
                }
            }

            return unidad;
        }



        public static List<UnidadMedida> ObtenerUnidades()
        {
            UnidadMedida unidad;
            listaUnidad.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from UnidadMedida";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    unidad = new UnidadMedida();
                    unidad.codigo = elLectorDeDatos.GetInt32(0);
                    unidad.descripcion = elLectorDeDatos.GetString(1);

                    listaUnidad.Add(unidad);
                }

                return listaUnidad;

            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
