﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Clases
{
    public class SalidaProducto
    {
        public int id { get; set; }
        public int nrodocumento { get; set; }
        public Motivo motivo { get; set; }
        public string destinatario { get; set; }
        public string direccion { get; set; }
        public DateTime fecharemision { get; set; }
        public List<DetalleSalidaProducto> detalle = new List<DetalleSalidaProducto>();

        public static List<SalidaProducto> listaEntrada = new List<SalidaProducto>();

        public static void Agregar(SalidaProducto p)
        {
            //listaPedidos.Add(p);
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                //cabecera
                string textoCMD = "INSERT INTO remision (fecharemision, nrodocumento, destinatario, direccion, motivoremision_id) output INSERTED.id VALUES (@fecharemision, @nrodocumento, @destinatario, @direccion, @motivoremision_id)";
                SqlCommand cmd = new SqlCommand(textoCMD, con);
                //parametros
                SqlParameter p1 = new SqlParameter("@fecharemision", p.fecharemision);
                SqlParameter p2 = new SqlParameter("@nrodocumento", p.nrodocumento);
                SqlParameter p3 = new SqlParameter("@destinatario", p.destinatario);
                SqlParameter p4 = new SqlParameter("@direccion", p.direccion);
                SqlParameter p5 = new SqlParameter("@motivoremision_id", p.motivo.id);

                p1.SqlDbType = System.Data.SqlDbType.DateTime;
                p2.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);

                int id_remision = (int)cmd.ExecuteScalar();


                //DETALLE
                foreach (DetalleSalidaProducto dp in p.detalle)
                {

                    //insert para el detalle
                    string textoCMD2 = "INSERT INTO DetalleRemision(producto_id, cantidadRemitida, remision_id) VALUES (@producto_id, @cantidadRemitida, @remision_id)";
                    SqlCommand cmd2 = new SqlCommand(textoCMD2, con);

                    //Pasamos los parametros

                    SqlParameter p6 = new SqlParameter("@producto_id", dp.producto.id);
                    SqlParameter p7 = new SqlParameter("@cantidadRemitida", dp.cantidad);
                    SqlParameter p8 = new SqlParameter("@remision_id", id_remision);
                    ActualizarStock(dp.producto.id, dp.cantidad);
                    cmd2.Parameters.Add(p6);
                    cmd2.Parameters.Add(p7);
                    cmd2.Parameters.Add(p8);

                    cmd2.ExecuteNonQuery();

                }
                con.Close();
            }
        }

        public static void ActualizarStock(int product_id, int cantidad)
        {
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
                    //parametros
                    if (pro.cantidad >= cantidad)
                    {
                        pro.cantidad = pro.cantidad - cantidad;

                        SqlParameter p1 = new SqlParameter("@cantidad", cantidad);
                        SqlParameter p2 = new SqlParameter("@id", product_id);

                        p1.SqlDbType = System.Data.SqlDbType.Int;
                        p2.SqlDbType = System.Data.SqlDbType.Int;
                        cmd.Parameters.Add(p1);
                        cmd.Parameters.Add(p2);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad a enviar excede a la cantidad actual");
                    }
                    con.Close();
                }

            }
        }

        public static void Eliminar(SalidaProducto p)
        {
            listaEntrada.Remove(p);
        }

        public static List<SalidaProducto> Obtener()
        {
            return listaEntrada;
        }

        public override string ToString()
        {
            return this.motivo.descripcion;
        }
    }
}
