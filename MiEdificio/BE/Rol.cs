using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Rol
    {
		
		public Rol()
		{

		}

		public Rol(string desc)
		{ 
			descripcion = desc;
		}
		
		private int id_tipo;

		public int ID_TIPO
		{
			get { return id_tipo; }
			set { id_tipo = value; }
		}

		private string descripcion;

		public string DESCRIPCION
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		public abstract void agregarPermiso(Rol r);
		public abstract Boolean eliminarPermiso(Rol r);
		public abstract List<Rol> obtenerPermisos();


	}
}
