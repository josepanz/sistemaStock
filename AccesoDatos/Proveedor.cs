using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Proveedor
    {
        public int idPK { get; set; }

        public int Ruc { get; set; }

        public string RazonSocial { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public static List<Proveedor> listaProveedores = new List<Proveedor>();

        public static void AgregarProveedores(Proveedor P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Proveedor (Ruc, RazonSocial, Email, Telefono, Direccion)VALUES (@Ruc, @RazonSocial, @Email, @Telefono, @Direccion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = P.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarProveedores(Proveedor P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Proveedor where idPK = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", P.idPK);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarProveedores(int index, Proveedor P)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Proveedor SET Ruc = @Ruc, RazonSocial = @RazonSocial, Email = @Email, Telefono = @Telefono, Direccion = @Direccion where idPK = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = P.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, bool id = false)
        {
            SqlParameter p1 = new SqlParameter("@Ruc", this.Ruc);
            SqlParameter p2 = new SqlParameter("@RazonSocial", this.RazonSocial);
            SqlParameter p3 = new SqlParameter("@Email", this.Email);
            SqlParameter p4 = new SqlParameter("@Telefono", this.Telefono);
            SqlParameter p5 = new SqlParameter("@Direccion", this.Direccion);


            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.Int;
            p5.SqlDbType = SqlDbType.VarChar;


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);


            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p6 = new SqlParameter("@id", this.idPK);
            p6.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p6);
            return cmd;
        }

        public static Proveedor ObtenerProveedor(int ruc)
        {
            Proveedor proveedor = null;

            if (listaProveedores.Count == 0)
            {
                Proveedor.ObtenerProveedores();
            }

            foreach (Proveedor P in listaProveedores)
            {
                if (P.Ruc == ruc)
                {
                    proveedor = P;
                    break;
                }
            }

            return proveedor;
        }

        public static List<Proveedor> ObtenerProveedores()
        {
            Proveedor pro;

            listaProveedores.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string tectoCMD = "select * from Proveedor";
                SqlCommand cmd = new SqlCommand(tectoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    pro = new Proveedor();
                    pro.idPK = elLectorDeDatos.GetInt32(0);
                    pro.Ruc = elLectorDeDatos.GetInt32(1);
                    pro.RazonSocial = elLectorDeDatos.GetString(2);
                    pro.Email = elLectorDeDatos.GetString(3);
                    pro.Telefono = elLectorDeDatos.GetInt32(4);
                    pro.Direccion = elLectorDeDatos.GetString(5);


                    listaProveedores.Add(pro);

                }
            }

            return listaProveedores;
        }

        public override string ToString()
        {
            return this.RazonSocial;
        }
    }

}