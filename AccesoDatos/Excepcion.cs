using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clases
{
    public class Excepcion
    {
        private Bitmap MyImage;

        public Bitmap mostrarErr(string url)
        {
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            MyImage = new Bitmap(url);


            return MyImage;
        }
    }
}
