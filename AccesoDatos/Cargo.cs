using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cargo
    {
        public int id { get; set; }

        public string descripcion { get; set; }


        public static List<Cargo> listaCargos = new List<Cargo>();

        public static Cargo ObtenerCargo(int id)
        {
            Cargo cargo = null;

            if (listaCargos.Count == 0)
            {
                Cargo.ObtenerCargos();
            }

            foreach (Cargo c in listaCargos)
            {
                if (c.id == id)
                {
                    cargo = c;
                    break;
                }
            }

            return cargo;
        }



        public static List<Cargo> ObtenerCargos()
        {


            Cargo cargo;
            listaCargos.Clear();
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCMD = "Select * from Cargo";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    cargo = new Cargo();
                    cargo.id = elLectorDeDatos.GetInt32(0);
                    cargo.descripcion = elLectorDeDatos.GetString(1);                    

                    listaCargos.Add(cargo);
                }

                return listaCargos;

            }

        }

        public static void EditarCargo(int index, Cargo C)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE cargo SET descripcion = @descripcion where id = @id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = C.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }

        public static void AgregarCargo(Cargo C)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Cargo (descripcion)VALUES (@descripcion)";
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

        public static void EliminarCargo(Cargo C)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from cargo where id = @id";

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
