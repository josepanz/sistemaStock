using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Soportes
{
    public class ValidacionDatos
    {
        private ValidationContext context;
        private List<ValidationResult> results;
        private bool valido;

        private string message;

        public ValidacionDatos(object instance)
        {
            context = new ValidationContext(instance);
            results = new List<ValidationResult>();
            valido = Validator.TryValidateObject(instance, context, results, true);

        }

        public bool Validate()
        {
            if (valido == false)
            {
                foreach(ValidationResult item in results)
                {
                    message = item.ErrorMessage + "\n";
                }
                System.Windows.Forms.MessageBox.Show(message);
            }
            return valido;
        }

    }
}
