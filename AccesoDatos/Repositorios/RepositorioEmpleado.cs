using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Contratos;
using AccesoDatos.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Repositorios
{
    public class RepositorioEmpleado : RepositorioMaestro, IRepositorioEmpleado
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEmpleado()
        {
            selectAll = "Select * from Empleado";
            insert = "Insert into Empleado values(@idNumero, @nombre, @email, @fechaNacimiento)";
            update = "Update Empleado set idNumero=@idNumero, nombre=@nombre, email=@email, fechaNacimiento=@fechaNacimiento where idPK=@idPK";
            delete = "Delete from Empleado where idPK=@idPK";
        }
        public int Add(Empleado entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idNumero", entity.idNumero));
            parameters.Add(new SqlParameter("@nombre", entity.nombre));
            parameters.Add(new SqlParameter("@email", entity.email));
            parameters.Add(new SqlParameter("@fechaNacimiento", entity.nacimiento));
            return ExecuteNonQuery(insert);
        }

        public int Edit(Empleado entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idPK", entity.idPK));
            parameters.Add(new SqlParameter("@idNumero", entity.idNumero));
            parameters.Add(new SqlParameter("@nombre", entity.nombre));
            parameters.Add(new SqlParameter("@email", entity.email));
            parameters.Add(new SqlParameter("@fechaNacimiento", entity.nacimiento));
            return ExecuteNonQuery(update);
        }

        public IEnumerable<Empleado> GetAll()
        {
            var tableResult = ExcuteReader(selectAll);
            var listaEmpleado = new List<Empleado>();
            foreach(DataRow item in tableResult.Rows)
            {
                listaEmpleado.Add(new Empleado
                {
                    idPK = Convert.ToInt32(item[0]),
                    idNumero = item[1].ToString(),
                    nombre = item[2].ToString(),
                    email  = item[3].ToString(),
                    nacimiento = Convert.ToDateTime(item[4])
                });
            }
            return listaEmpleado;
        }

        public int Remove(int idPK)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idPK", idPK));
            return ExecuteNonQuery(delete);
        }
    }
}
