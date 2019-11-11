using AccesoDatos.Contratos;
using AccesoDatos.Entidades;
using AccesoDatos.Repositorios;
using Negocio.ObjetosValores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelos
{
    public class ModeloCargo : IDisposable
    {
        private int codCargo;

        private string descripcion;

        private IRepositorioCargo repositorioCargo;

        public EstadoEntidad Estado { private get; set; }

        private List<ModeloCargo> listaCargos;

        public int CodCargo { get => codCargo; set => codCargo = value; }

        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El campo nombre solo puede recibir letras")]
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public ModeloCargo()
        {
            repositorioCargo = new RepositorioCargo();
        }

        public string SaveChanges()
        {
            string message = null;
            try
            {
                var CargoDataModel = new Cargo();
                CargoDataModel.codCargo = codCargo;
                CargoDataModel.descripcion = descripcion;
                
                switch (Estado)
                {
                    case EstadoEntidad.Agregado:
                        repositorioCargo.Add(CargoDataModel);
                        message = "Insertado correctamente";
                        break;
                    case EstadoEntidad.Modificado:
                        repositorioCargo.Edit(CargoDataModel);
                        message = "Editado correctamente";
                        break;
                    case EstadoEntidad.Eliminado:
                        repositorioCargo.Remove(codCargo);
                        message = "Eliminado correctamente";
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2627)
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
        public List<ModeloCargo> GetAll()
        {
            var CargoDataModel = repositorioCargo.GetAll();
            listaCargos = new List<ModeloCargo>();
            foreach (Cargo item in CargoDataModel)
            {
                
                listaCargos.Add(new ModeloCargo
                {
                    codCargo = item.codCargo,
                    descripcion = item.descripcion,
                   

                }); ;
            }
            return listaCargos;
        }

        public IEnumerable<ModeloCargo> findById(string filter)
        {
            return GetAll().FindAll(e => e.descripcion.Contains(filter));
        }

        public override string ToString()
        {
            //return "R. Social: " + RazonSocial +"; " + "Direcc: " + Direccion + ";" + "Contacto: " + Contacto;
            return descripcion;
        }


        public void Dispose()
        {
            
        }
    }
}
