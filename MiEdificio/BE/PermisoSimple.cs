using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoSimple : Rol
    {


        public PermisoSimple(string nom, string desc) : base(desc)
        {
            this.nombre = nom;
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
        }

        public override void agregarPermiso(Rol r)
        {
            //deprecado
        }

        public override bool eliminarPermiso(Rol r)
        {
            //deprecado
            return false;
        }

        public override List<Rol> obtenerPermisos()
        {
            return null;
        }

        public override string ToString()
        {
            return NOMBRE + " - " + DESCRIPCION;
        }
    }
}
