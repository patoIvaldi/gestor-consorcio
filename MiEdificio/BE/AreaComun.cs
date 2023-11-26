using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AreaComun
    {

        public AreaComun() { }

		private string nombre;

		public string NOMBRE
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string descripcion;

		public string DESCRIPCION
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		private Boolean esHabilitada;

		public Boolean ES_AREA_HABILITADA
		{
			get { return esHabilitada; }
			set { esHabilitada = value; }
		}

        public override string ToString()
        {
            return this.nombre;
        }
    }
}
