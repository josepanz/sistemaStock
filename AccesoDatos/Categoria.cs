using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Categoria
    {
        public int codigo { get; set; }
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

        public static Categoria ObtenerCategoria(int id)
        {
            Categoria categoria = null;

            if (listaCategoria.Count == 0)
            {
                Categoria.ObtenerCategorias();
            }

            foreach (Categoria c in listaCategoria)
            {
                if (c.codigo == id)
                {
                    categoria = c;
                    break;
                }
            }

            return categoria;
        }



        public static List<Categoria> ObtenerCategorias()
        {
            Categoria categoria;
            listaCategoria.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Categoria";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    categoria = new Categoria ();
                    categoria.codigo = elLectorDeDatos.GetInt32(0);
                    categoria.descripcion = elLectorDeDatos.GetString(1);

                    listaCategoria.Add(categoria);
                }

                return listaCategoria;

            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
