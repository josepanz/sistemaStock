using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Clases
{
    public class Producto
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string codBarra { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
        public Marca marca { get; set; }
        public TipoProducto tipoProducto { get; set; }
        public Proveedor proveedor { get; set; }
        public 
        public Categoria categoria { get; set; }
        
        
        public DateTime fechaVencimiento { get; set; }
        public static List<Producto> listaProductos = new List<Producto>();

        public static void AgregarProductos(Producto P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string textoCmd = "INSERT INTO Producto (idNumero, nombre, email, fechaNacimiento, codCargo)VALUES (@idNumero, @nombre, @email, @fc, @cargo)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = empl.ObtenerParametros(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarProductos(int posicion_item)
        {
            listaProductos.RemoveAt(posicion_item);
        }

        public static List<Producto> ObtenerProductos()
        {
            return listaProductos;
        }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
}
