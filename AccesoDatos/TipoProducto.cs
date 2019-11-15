using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class TipoProducto
    {
        public int codigo { get; set; }
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
     
        public static TipoProducto ObtenerTipoProducto(int id)
        {
            TipoProducto tipoProducto = null;

            if (listaTipoProductos.Count == 0)
            {
               TipoProducto.ObtenerTipoProductos();
            }

            foreach (TipoProducto tp in listaTipoProductos)
            {
                if (tp.codigo == id)
                {
                    tipoProducto = tp;
                    break;
                }
            }

            return tipoProducto;
        }



        public static List<TipoProducto> ObtenerTipoProductos()
        {
            TipoProducto tipo;
            listaTipoProductos.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from TipoProducto";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    tipo = new TipoProducto();
                    tipo.codigo = elLectorDeDatos.GetInt32(0);
                    tipo.descripcion = elLectorDeDatos.GetString(1);

                    listaTipoProductos.Add(tipo);
                }

                return listaTipoProductos;

            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
