using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Motivo
    {
        public int id { get; set; }

        public string descripcion { get; set; }


        public static List<Motivo> listaMotivos = new List<Motivo>();

        public static Motivo ObtenerMotivo(int id)
        {
            Motivo motivo = null;

            if (listaMotivos.Count == 0)
            {
                Motivo.ObtenerMotivos();
            }

            foreach (Motivo c in listaMotivos)
            {
                if (c.id == id)
                {
                    motivo = c;
                    break;
                }
            }

            return motivo;
        }



        public static List<Motivo> ObtenerMotivos()
        {


            Motivo motivo;
            listaMotivos.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Motivo";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    motivo = new Motivo();
                    motivo.id = elLectorDeDatos.GetInt32(0);
                    motivo.descripcion = elLectorDeDatos.GetString(1);

                    listaMotivos.Add(motivo);
                }

                return listaMotivos;

            }

        }

        public static void EditarMotivo(int index, Motivo C)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE motivo SET descripcion = @descripcion where id = @id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = C.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarMotivo(Motivo C)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Motivo (descripcion)VALUES (@descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = C.ObtenerParametros(cmd);
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

        public static void EliminarMotivo(Motivo C)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from motivo where id = @id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@id", C.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public override string ToString()
        {
            //return "R. Social: " + RazonSocial +"; " + "Direcc: " + Direccion + ";" + "Contacto: " + Contacto;
            return descripcion;
        }
    }
}
