using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

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
        public static List<Empleado> listaCredenciales = new List<Empleado>();

        public bool obtenerCredenciales(string user, string pass)
        {
            Empleado empleado;
            listaCredenciales.Clear();
            bool ingresa = false;
            try
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    //string tectoCMD = "select *, coalesce(pass,'-') from Empleado";
                    string tectoCMD = "select idNumero, coalesce(password, '-') as password from Empleado "+
                        " where idNumero ='"+user+"' and password = '"+pass+"'";
                    SqlCommand cmd = new SqlCommand(tectoCMD, con);
                    SqlDataReader elLectorDeDatos = cmd.ExecuteReader();
                    if (elLectorDeDatos.HasRows)
                    {

                        while (elLectorDeDatos.Read())
                        {
                            ingresa = true;
                            //MessageBox.Show("Valor a devolver: " + ingresa);
                        }
                        con.Close();
                        return ingresa;
                    }
                    else { 
                        con.Close();
                        return ingresa;
                    }

                    
                }
            }
            catch (Exception ex){
                MessageBox.Show("Se ha detectado un error de: "+ex);
            }
            return ingresa;
        }

        public static List<Empleado> ObtenerEmpleados() {

            Empleado empleado;
            listaEmpleados.Clear();
            try
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    //string tectoCMD = "select *, coalesce(pass,'-') from Empleado";
                    string tectoCMD = "select idPK, idNumero, nombre, email, fechaNacimiento, codCargo, coalesce(password, '-') as password from Empleado";
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
                        empleado.pass = elLectorDeDatos.GetString(6);

                        listaEmpleados.Add(empleado);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha detectado un error de: " + ex);
            }
            return listaEmpleados;


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

        public static void AgregarEmpleado(Empleado empl)
        {
            if (empl != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCmd = "INSERT INTO Empleado (idNumero, nombre, email, fechaNacimiento, codCargo, password)VALUES (@idNumero, @nombre, @email, @fc, @cargo, @pass)";
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
                    string textoCMD = "UPDATE Empleado SET idNumero = @idNumero, nombre = @nombre, email = @email, fechaNacimiento = @fc, codCargo = @cargo, password = @pass where idPK = @id";
                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    cmd = empl.ObtenerParametros(cmd, true);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }            
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p1 = new SqlParameter("@idNumero", this.idNumero);
            SqlParameter p2 = new SqlParameter("@nombre", this.nombre);
            SqlParameter p3 = new SqlParameter("@email", this.email);
            SqlParameter p4 = new SqlParameter("@fc", this.nacimiento);
            SqlParameter p5 = new SqlParameter("@cargo", this.cargo.id);
            SqlParameter p6 = new SqlParameter("@pass", this.pass);
            p1.SqlDbType = SqlDbType.Int;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.DateTime;
            p5.SqlDbType = SqlDbType.Int;
            p6.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
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

        public override string ToString()
        {
            return this.nombre;
        }        
    }
}

