using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Marca
    {
        public int codigo { get; set; }
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

        public static Marca ObtenerMarca(int id)
        {
            Marca marca = null;

            if (listaMarca.Count == 0)
            {
                Marca.ObtenerMarcas();
            }

            foreach (Marca m in listaMarca)
            {
                if (m.codigo == id)
                {
                    marca = m;
                    break;
                }
            }

            return marca;
        }

        

            public static List<Marca> ObtenerMarcas(){
            Marca marca;
            listaMarca.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Marca";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    marca = new Marca();
                    marca.codigo = elLectorDeDatos.GetInt32(0);
                    marca.descripcion = elLectorDeDatos.GetString(1);

                    listaMarca.Add(marca);
                }

                return listaMarca;

            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }

    
}
