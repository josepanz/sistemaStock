using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Repositorios
{
    public abstract class RepositorioMaestro:Repositorio
    {
        protected List<SqlParameter> parameters;

        protected int ExecuteNonQuery(string transactSql) {
            using (var connection = GetConnection()) {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;
                    foreach(SqlParameter Item in parameters)
                    {
                        command.Parameters.Add(Item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }

            }
        }
        protected DataTable ExcuteReader(string transactSql) {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    using(var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }

            }
        }
    }
}
