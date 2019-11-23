using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Categoria
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public static List<Categoria> listaCategoria = new List<Categoria>();

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
                    categoria = new Categoria();
                    categoria.id = elLectorDeDatos.GetInt32(0);
                    categoria.descripcion = elLectorDeDatos.GetString(1);
                    listaCategoria.Add(categoria);
                }
                return listaCategoria;
            }
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
                if (c.id == id)
                {
                    categoria = c;
                    break;
                }
            }
            return categoria;
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

        public static void AgregarCategoria(Categoria C)
        {
            if (C != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCmd = "INSERT INTO Categoria (descripcion)VALUES (@descripcion)";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd = C.ObtenerParametros(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        public static void EliminarCategorias(Categoria C)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string SENTENCIA_SQL = "delete from Categoria where id = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", C.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarCategorias(int index, Categoria C)
        {
            if (C != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCMD = "UPDATE Categoria SET descripcion = @descripcion where id = @Id";
                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    cmd = C.ObtenerParametros(cmd, true);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
