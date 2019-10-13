using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;
using AccesoDatos.Entidades;
using AccesoDatos.Repositorios;
using Negocio.ObjetosValores;
using System.ComponentModel.DataAnnotations;

namespace Negocio.Modelos
{
    public class ModeloEmpleado :IDisposable
    {
        private int idPK;

        private string idNumero;

        private string nombre;

        private string email;

        private DateTime nacimiento;

        private int edad;

        private IRepositorioEmpleado repositorioEmpleado;
        public EstadoEntidad Estado { private get; set; }

        private List<ModeloEmpleado> listaEmpleados;


        public int IdPK { get => idPK; set => idPK = value; }
        [Required(ErrorMessage = "El campo de número de identificación es requerido")]
        [RegularExpression("([0-9]+)",ErrorMessage ="El número de identificación solo puede ser numérico")]
        public string IdNumero { get => idNumero; set => idNumero = value; }
        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El campo nombre solo puede recibir letras")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Required]
        [EmailAddress]
        public string Email { get => email; set => email = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public int Edad { get => edad; private set => edad = value; }

        public ModeloEmpleado()
        {
            repositorioEmpleado = new RepositorioEmpleado();
        }

        public string SaveChanges()
        {
            string message=null;
            try
            {
                var empleadoDataModel = new Empleado();
                empleadoDataModel.idPK = idPK;
                empleadoDataModel.idNumero = idNumero;
                empleadoDataModel.nombre = nombre;
                empleadoDataModel.email = email;
                empleadoDataModel.nacimiento = nacimiento;
                switch (Estado)
                {
                    case EstadoEntidad.Agregado:
                        repositorioEmpleado.Add(empleadoDataModel);
                        message = "Insertado correctamente";
                        break;
                    case EstadoEntidad.Modificado:
                        repositorioEmpleado.Edit(empleadoDataModel);
                        message = "Editado correctamente";
                        break;
                    case EstadoEntidad.Eliminado:
                        repositorioEmpleado.Remove(idPK);
                        message = "Eliminado correctamente";
                        break;                    
                }
            }
            catch(Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if(sqlEx != null && sqlEx.Number == 2627)
                {
                    message = "Registro duplicado";
                }
                else
                {
                    message = ex.ToString();
                }
            }
            return message;

        }
        public List<ModeloEmpleado> GetAll()
        {
            var empleadoDataModel = repositorioEmpleado.GetAll();
            listaEmpleados = new List<ModeloEmpleado>();
            foreach(Empleado item in empleadoDataModel)
            {
                var fechaNac = item.nacimiento;
                listaEmpleados.Add(new ModeloEmpleado
                {
                    idPK=item.idPK,
                    idNumero=item.idNumero,
                    nombre=item.nombre,
                    email = item.email,
                    nacimiento = item.nacimiento,
                    edad = calcularEdad(fechaNac)

                });;
            }
            return listaEmpleados;
        }

        public IEnumerable<ModeloEmpleado> findById(string filter)
        {
            return GetAll().FindAll( e => e.idNumero==filter || e.nombre.Contains(filter));
        }

        private int calcularEdad(DateTime date)
        {
            DateTime dateNow = DateTime.Now;
            return (dateNow.Year-date.Year);
        }

        public void Dispose()
        {
            
        }
    }
}
