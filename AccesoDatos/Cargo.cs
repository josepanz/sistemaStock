using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cargo
    {
        public int codCargo { get; set; }

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
                if (c.codCargo == id)
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
                    cargo.codCargo = elLectorDeDatos.GetInt32(0);
                    cargo.descripcion = elLectorDeDatos.GetString(1);                    

                    listaCargos.Add(cargo);
                }

                return listaCargos;

            }

        }

        public override string ToString()
        {
            //return "R. Social: " + RazonSocial +"; " + "Direcc: " + Direccion + ";" + "Contacto: " + Contacto;
            return descripcion;
        }
    }
}
