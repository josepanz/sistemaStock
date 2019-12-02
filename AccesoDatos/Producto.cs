﻿using System;
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
        public UnidadMedida unidad { get; set; }
        public Categoria categoria { get; set; }
      
        public static List<Producto> listaProductos = new List<Producto>();

        public static void AgregarProductos(Producto P)
        {
            if (P != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

                {
                    con.Open();
                    string textoCmd = "INSERT INTO Producto ( descripcion, codBarra, precio, cantidad, marca_id, tipoProducto_id, proveedor_id, unidadMedida_id, categoria_id)VALUES ( @descripcion, @codBarra, @precio, @cantidad, @marca, @tipoProducto, @proveedor, @unidad, @categoria)";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd = P.ObtenerParametros(cmd);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
            SqlParameter p2 = new SqlParameter("@descripcion", this.descripcion);
            SqlParameter p3 = new SqlParameter("@codBarra", this.codBarra);
            SqlParameter p4 = new SqlParameter("@precio", this.precio);
            SqlParameter p5 = new SqlParameter("@cantidad", this.cantidad);
            SqlParameter p6 = new SqlParameter("@marca", this.marca.id);
            SqlParameter p7 = new SqlParameter("@tipoProducto", this.tipoProducto.id);
            SqlParameter p8 = new SqlParameter("@proveedor", this.proveedor.idPK);
            SqlParameter p9 = new SqlParameter("@unidad", this.unidad.id);
            SqlParameter p10 = new SqlParameter("@categoria", this.categoria.id);


            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.Int;
            p5.SqlDbType = SqlDbType.Int;
            p6.SqlDbType = SqlDbType.Int;
            p7.SqlDbType = SqlDbType.Int;
            p8.SqlDbType = SqlDbType.Int;
            p9.SqlDbType = SqlDbType.Int;
            p10.SqlDbType = SqlDbType.Int;


            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);


            if (id == true)
            {
                cmd = ObtenerParametrosId(cmd);
            }
            return cmd;
        }

        private SqlCommand ObtenerParametrosId(SqlCommand cmd)
        {
            SqlParameter p11 = new SqlParameter("@id", this.id);
            p11.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p11);
            return cmd;
        }

        public static void EliminarProductos(Producto P)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open();
                string SENTENCIA_SQL = "delete from producto where id = @id";

                SqlCommand cmd = new SqlCommand(SENTENCIA_SQL, con);
                SqlParameter p1 = new SqlParameter("@id", P.id);
                p1.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void EditarProducto(int index, Producto P)
        {
            if (P != null)
            {
                using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
                {
                    con.Open();
                    string textoCMD = "UPDATE Producto SET descripcion = @descripcion, codBarra = @codBarra, precio = @precio, cantidad = @cantidad, marca_id = @marca, tipoProducto_id = @tipoProducto, proveedor_id = @proveedor, unidadMedida_id = @unidad, categoria_id = @categoria where id = @id";

                    SqlCommand cmd = new SqlCommand(textoCMD, con);
                    cmd = P.ObtenerParametros(cmd, true);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Producto> ObtenerProductos()
        {
            Producto pro;

            listaProductos.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string tectoCMD = "select * from Producto";
                SqlCommand cmd = new SqlCommand(tectoCMD, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    pro = new Producto();
                    pro.id = elLectorDeDatos.GetInt32(0);
                    pro.descripcion = elLectorDeDatos.GetString(1);
                    pro.codBarra = elLectorDeDatos.GetString(2);
                    pro.precio = elLectorDeDatos.GetInt32(3);
                    pro.cantidad = elLectorDeDatos.GetInt32(4);
                    pro.marca = Marca.ObtenerMarca(elLectorDeDatos.GetInt32(5));
                    pro.tipoProducto = TipoProducto.ObtenerTipoProducto(elLectorDeDatos.GetInt32(6));
                    pro.proveedor = Proveedor.ObtenerProveedor(elLectorDeDatos.GetInt32(7));
                    pro.unidad = UnidadMedida.ObtenerUnidad(elLectorDeDatos.GetInt32(8));
                    pro.categoria = Categoria.ObtenerCategoria(elLectorDeDatos.GetInt32(9));

                    listaProductos.Add(pro);

                }
                con.Close();
            }

            return listaProductos;
        }

        public static Producto ObtenerProducto(int id)
        {
            Producto producto = null;

            if (listaProductos.Count == 0)
            {
                Producto.ObtenerProductos();
            }

            foreach (Producto p in listaProductos)
            {
                if (p.id == id)
                {
                    producto = p;
                    break;
                }
            }

            return producto;
        }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
}
