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

        public int idNumero { get; set; }

        public string RazonSocial { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }

        public static List<Proveedor> listaProveedores = new List<Proveedor>();

        public static void AgregarProveedores(Proveedor P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Proveedor (idNumero, razonsocial, email, direccion)VALUES (@idNumero, @razonSocial, @email, @direccion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = P.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarProveedores(int P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from Proveedor where idPK = @Id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@Id", P);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarProveedor(int index, Proveedor P)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Proveedor SET idNumero = @idNumero, razonSocial = @razonSocial, telefono = @telefono, direccion = @direccion where ruc = @ruc";

                SqlCommand cmd = new SqlCommand(textoCMD, con);
                cmd = P.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p1 = new SqlParameter("@idNumero", this.idNumero);
            SqlParameter p2 = new SqlParameter("@nombre", this.RazonSocial);
            SqlParameter p3 = new SqlParameter("@email", this.Email);
            SqlParameter p4 = new SqlParameter("@fc", this.Direccion);
            


            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.DateTime;
        


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            


            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;

        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p5 = new SqlParameter("@id", this.idPK);
            p5.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p5);
            return cmd;
        }

        public static Proveedor ObtenerProveedor(int idNumero)
        {
            Proveedor proveedor = null;

            if (listaProveedores.Count == 0)
            {
                Empleado.ObtenerEmpleados();
            }

            foreach (Proveedor p  in listaProveedores)
            {
                if (p.idNumero == idNumero)
                {
                    proveedor = p;
                    break;
                }
            }

            return proveedor;
        }

        public static List<Proveedor> ObtenerProveedores()
        {
            Proveedor proveedor;

            listaProveedores.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string tectoCMD = "select * from Proveedor";
                SqlCommand cmd = new SqlCommand(tectoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.idPK = elLectorDeDatos.GetInt32(0);
                    proveedor.idNumero = elLectorDeDatos.GetInt32(1);
                    proveedor.RazonSocial = elLectorDeDatos.GetString(2);
                    proveedor.Email = elLectorDeDatos.GetString(3);
                    proveedor.Direccion = elLectorDeDatos.GetString(4); ;
                    


                    listaProveedores.Add(proveedor);

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
