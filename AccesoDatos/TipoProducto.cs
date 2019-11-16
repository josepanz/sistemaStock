using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class TipoProducto
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public static List<TipoProducto> listaTipoProductos = new List<TipoProducto>();

        public static void AgregarProductos(TipoProducto TP)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO TipoProducto (descripcion)VALUES (@descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = TP.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, bool id = false)
        {
            SqlParameter p1 = new SqlParameter("@descripcion", this.descripcion);
            p1.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(p1);
            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p2 = new SqlParameter("@id", this.id);
            p2.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p2);
            return cmd;
        }

        public static void EliminarTipoProductos(TipoProducto TP)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from TipoProducto where id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", TP.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarTipoProducto(int index, TipoProducto TP)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE TipoProducto SET descripcion = @descripcion where id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = TP.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
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
                if (tp.id == id)
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
                    tipo.id = elLectorDeDatos.GetInt32(0);
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
