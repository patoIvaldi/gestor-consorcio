using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Idioma
    {

		public Idioma(Image img)
		{
			Image imagenOriginal = img;
            int nuevaAnchura = 20;
            int nuevaAltura = 15;
            Image imagenRedimensionada = new Bitmap(imagenOriginal, nuevaAnchura, nuevaAltura);

			this.icono = imagenRedimensionada;
        }

		private char id;

		public char ID
		{
			get { return id; }
			set { id = value; }
		}

		private string descripcion;

		public string DESCRIPCION
		{
			get { return descripcion.Trim(); }
			set { descripcion = value; }
		}

		private Image icono;

		public Image ICONO
		{
			get { return icono; }
			//set { icono = value; }
		}

        public override string ToString()
        {
			return this.icono + " - " + this.descripcion;
        }

    }
}
