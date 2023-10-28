using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceBackup
    {

		public ServiceBackup() { }

		private string directorio;

		public string DIRECTORIO
		{
			get { return directorio; }
			set { directorio = value; }
		}

		private string nombreArchivo;

		public string NOMBRE_ARCHIVO
		{
			get { return nombreArchivo; }
			set { nombreArchivo = value; }
		}

		private Usuario autor;

		public Usuario AUTOR
		{
			get { return autor; }
			set { autor = value; }
		}


	}
}
