using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceTraduccion
    {

		private string nombreObjeto;

		public string NOMBRE_OBJETO
		{
			get { return nombreObjeto; }
			set { nombreObjeto = value; }
		}

		private ServiceIdioma idioma;

		public ServiceIdioma IDIOMA
		{
			get { return idioma; }
			set { idioma = value; }
		}

		private string traduccionTXT;

		public string TRADUCCION_TXT
		{
			get { return traduccionTXT; }
			set { traduccionTXT = value; }
		}

        public override string ToString()
        {
            return this.traduccionTXT;
        }

    }
}
