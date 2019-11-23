using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clases
{
    public class UnidadMedida
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public static List<UnidadMedida> listaUnidad = new List<UnidadMedida>();

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
                    unidad.id = elLectorDeDatos.GetInt32(0);
                    unidad.descripcion = elLectorDeDatos.GetString(1);
                    listaUnidad.Add(unidad);
                }
                return listaUnidad;
            }
        }

        public static UnidadMedida ObtenerUnidad(int id)
        {
            UnidadMedida unidad = null;
            if (listaUnidad.Count == 0)
            {
                UnidadMedida.ObtenerUnidades();
            }
            foreach (UnidadMedida  u in listaUnidad)
            {
                if (u.id == id)
                {
                    unidad = u;
                    break;
                }
            }
            return unidad;
        }
        
        public static void AgregarUnidad(UnidadMedida U)
        {
            if (U != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCmd = "INSERT INTO UnidadMedida (descripcion)VALUES (@descripcion)";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd = U.ObtenerParametros(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarUnidadMedidas(UnidadMedida M)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string SENTENCIA_SQL = "delete from UnidadMedida where id = @id";
                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@id", M.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarUnidadMedida(int index, UnidadMedida C)
        {
            if (C != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCMD = "UPDATE UnidadMedida SET descripcion = @descripcion where id = @id";
                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    cmd = C.ObtenerParametros(cmd, true);
                    cmd.ExecuteNonQuery();
                }
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

        

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
