using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Marca
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public static List<Marca> listaMarca = new List<Marca>();

        public static void AgregarMarca(Marca M)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Marca (descripcion)VALUES (@descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = M.ObtenerParametros(cmd);
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

        public static void EliminarMarcas(Marca M)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Marca where id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", M.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarMarca(int index, Marca C)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Marca SET descripcion = @descripcion where id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = C.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
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
                if (m.id == id)
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
                    marca.id = elLectorDeDatos.GetInt32(0);
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
