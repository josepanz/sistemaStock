using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Clases
{
    public class Empleado
    {
        
        public int idPK { get; set; }

        public int idNumero { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        public DateTime nacimiento { get; set; }

        public string pass { get; set; }

        public Cargo cargo { get; set; }

        public static List<Empleado> listaEmpleados = new List<Empleado>();
        

        public static void AgregarEmpleado(Empleado empl)
        {
            if (empl != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

                {
                    con.Open();
                    string textoCmd = "INSERT INTO Empleado (idNumero, nombre, email, fechaNacimiento, codCargo)VALUES (@idNumero, @nombre, @email, @fc, @cargo)";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd = empl.ObtenerParametros(cmd);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            
        }
        public static void EliminarEmpleado(int empl)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                
                    con.Open();
                    string SENTENCIA_SQL = "delete from Empleado where idPK = @id";

                    SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                    SqlParameter p1 = new SqlParameter("@id", empl);
                    p1.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                
                
                
                
            }
        }


        public static void EditarEmpleado(int index, Empleado empl)
        {
            if (empl != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCMD = "UPDATE Empleado SET idNumero = @idNumero, nombre = @nombre, email = @email, fechaNacimiento = @fc, codCargo = @cargo where idPK = @id";

                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    cmd = empl.ObtenerParametros(cmd, true);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            
        }


        public static List<Empleado> ObtenerEmpleados()
        {
            Empleado empleado;

            listaEmpleados.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string tectoCMD = "select * from Empleado";
                SqlCommand cmd = new SqlCommand(tectoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    empleado = new Empleado();
                    empleado.idPK = elLectorDeDatos.GetInt32(0);
                    empleado.idNumero = elLectorDeDatos.GetInt32(1);
                    empleado.nombre = elLectorDeDatos.GetString(2);
                    empleado.email = elLectorDeDatos.GetString(3);
                    empleado.nacimiento = elLectorDeDatos.GetDateTime(4);
                    empleado.cargo = Cargo.ObtenerCargo(elLectorDeDatos.GetInt32(5));
                    

                    listaEmpleados.Add(empleado);

                }
                con.Close();
            }

            return listaEmpleados;
        }

       

        public override string ToString()
        {
            return this.nombre;
        }



        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)

        {
            SqlParameter p1 = new SqlParameter("@idNumero", this.idNumero);
            SqlParameter p2 = new SqlParameter("@nombre", this.nombre);
            SqlParameter p3 = new SqlParameter("@email", this.email);
            SqlParameter p4 = new SqlParameter("@fc", this.nacimiento);
            SqlParameter p5 = new SqlParameter("@cargo", this.cargo.id);
            

            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.DateTime;
            p5.SqlDbType = SqlDbType.Int;
            

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

        public static Empleado ObtenerEmpleado(int idNumero)
        {
            Empleado empleado = null;

            if (listaEmpleados.Count == 0)
            {
                Empleado.ObtenerEmpleados();
            }

            foreach (Empleado empl in listaEmpleados)
            {
                if (empl.idNumero == idNumero)
                {
                    empleado = empl;
                    break;
                }
            }

            return empleado;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {

            SqlParameter p6 = new SqlParameter("@id", this.idPK);
            p6.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p6);
            return cmd;
        }
    }
}

