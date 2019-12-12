using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clases
{
    public class EntradaProducto
    {
        //id, fechaRecepcion, nroDocumento, receptor, direccion
        public int id { get; set; }
        public string nrodocumento { get; set; }
        public string receptor { get; set; }
        public string direccion { get; set; }
        public DateTime fecharecepcion { get; set; }
        public List<DetalleEntradaProducto> detalle = new List<DetalleEntradaProducto>();

        public static List<EntradaProducto> listaEntrada = new List<EntradaProducto>();
        

        public static void Agregar(EntradaProducto p)
        {
            //listaPedidos.Add(p);
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                //cabecera
                string textoCMD = "INSERT INTO recepcion (fecharecepcion, nrodocumento, receptor, direccion) output INSERTED.id VALUES (@fecharecepcion, @nrodocumento, @receptor, @direccion)";
                SqlCommand cmd = new SqlCommand(textoCMD, con);
                SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                cmd.Transaction = transaction;
                try
                {
                    //parametros
                    SqlParameter p1 = new SqlParameter("@fecharecepcion", p.fecharecepcion);
                    SqlParameter p2 = new SqlParameter("@nrodocumento", p.nrodocumento);
                    SqlParameter p3 = new SqlParameter("@receptor", p.receptor);
                    SqlParameter p4 = new SqlParameter("@direccion", p.direccion);

                    p1.SqlDbType = System.Data.SqlDbType.DateTime;
                    p2.SqlDbType = System.Data.SqlDbType.VarChar;
                    p3.SqlDbType = System.Data.SqlDbType.VarChar;
                    p4.SqlDbType = System.Data.SqlDbType.VarChar;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);

                    int id_recepcion = (int)cmd.ExecuteScalar();


                    //DETALLE
                    foreach (DetalleEntradaProducto dp in p.detalle)
                    {

                        //insert para el detalle
                        string textoCMD2 = "INSERT INTO DetalleRecepcion(producto_id, cantidadRecibida, recepcion_id) VALUES (@producto_id, @cantidadRecibida, @recepcion_id)";
                        SqlCommand cmd2 = new SqlCommand(textoCMD2, con);
                        //Pasamos los parametros

                        SqlParameter p5 = new SqlParameter("@producto_id", dp.producto.id);
                        SqlParameter p6 = new SqlParameter("@cantidadRecibida", dp.cantidad);
                        SqlParameter p7 = new SqlParameter("@recepcion_id", id_recepcion);
                        if (ActualizarStock(dp.producto.id, dp.cantidad) == 1)
                        {
                            p5.SqlDbType = System.Data.SqlDbType.Int;
                            p6.SqlDbType = System.Data.SqlDbType.Int;
                            p7.SqlDbType = System.Data.SqlDbType.Int;
                            cmd2.Parameters.Add(p5);
                            cmd2.Parameters.Add(p6);
                            cmd2.Parameters.Add(p7);
                            cmd2.Transaction = transaction;
                            cmd2.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            break;
                        }
                    }
                    con.Close();
                } catch (Exception ex) {
                    con.Close();

                    //MessageBox.Show("Lo Siento ocurrio un error inesperado", "Advetencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static int ActualizarStock(int product_id, int cantidad)
        {
            int ban = 0;
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                //cabecera
                Producto pro = new Producto();
                pro = Producto.ObtenerProducto(product_id);
                if (pro != null)
                {
                    string textoCMD = "update producto set cantidad = @cantidad  where id = @id";
                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    SqlTransaction transaction = con.BeginTransaction("SampleTransaction");
                    cmd.Transaction = transaction;

                    //parametros
                    if (pro.cantidad  > 0)
                    {
                        ban = 1;
                        int actual = pro.cantidad + cantidad;

                        SqlParameter p1 = new SqlParameter("@cantidad", actual);
                        SqlParameter p2 = new SqlParameter("@id", product_id);

                        p1.SqlDbType = System.Data.SqlDbType.Int;
                        p2.SqlDbType = System.Data.SqlDbType.Int;
                        cmd.Parameters.Add(p1);
                        cmd.Parameters.Add(p2);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Actualizado con exito!");

                    }
                    else
                    {
                        ban = 0;
                        transaction.Rollback();
                        MessageBox.Show("La cantidad a recibir debe ser mayor a 0 (cero)");
                    }
                    con.Close();
                }

            }
            return ban;
        }

        public static void Eliminar(EntradaProducto p)
        {
            listaEntrada.Remove(p);
        }

        public static List<EntradaProducto> Obtener()
        {
            return listaEntrada;
        }



    }
}
