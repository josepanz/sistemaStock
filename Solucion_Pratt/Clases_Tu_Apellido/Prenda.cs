using Clases_Pratt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Pratt
{
    
        public enum Color
        {
            Negro,
            Rojo,
            Gris,
            Beige
        }

        public enum TipoVestimenta
        {
            De_Vetir,
            Sport_Elegante,
            Deportivos,
        }

        public enum Cambiable { Si, No }

    public class Prenda
        {
            public string detalle { get; set; }
            public Color Color { get; set; }
            public TipoVestimenta TipoVestimenta { get; set; }
            public DateTime Fecha_Ingreso { get; set; }
            public String tamaño { get; set; }
            public Proveedor Proveedor { get; set; }
            public Double Precio_Costo { get; set; }
            public Double Precio_Venta { get; set; }
            public Double Utilidad_Bruta { get; set; }
            public Cambiable cambiable { get; set; }

        public static List<Prenda> listaPrendas = new List<Prenda>();

            public static void AgregarPrendas(Prenda P)
            {
                listaPrendas.Add(P);
            }

            public static void EliminarPrendas(Prenda P)
            {
                listaPrendas.Remove(P);
            }

            public static List<Prenda> obtenerPrendas()
            {
                return listaPrendas;
            }

            public override string ToString()
            {
                return this.detalle;
            }



        }
    }
