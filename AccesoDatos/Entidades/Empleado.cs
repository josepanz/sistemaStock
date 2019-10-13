using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Entidades
{
    public class Empleado
    {
        public int idPK { get; set; }

        public string idNumero { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        public DateTime nacimiento { get; set; }
    }
}
