using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace AccesoDatos.Repositorios
{
    public abstract class Repositorio
    {
        private string connectString;
        public  Repositorio()
        {
            connectString = ConfigurationManager.ConnectionStrings["connStock"].ToString();

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectString);
        }
    }
}
