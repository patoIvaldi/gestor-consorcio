using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Perfil : Rol
    {

        private List<Rol> _permisos;

        public Perfil()
        {
            _permisos = new List<Rol>();
        }

        public Perfil(string desc) : base(desc)
        {
            _permisos = new List<Rol>();
        }

        public override string ToString()
        {
            return this.ID_TIPO + " - " + DESCRIPCION;
        }

        public override void agregarPermiso(Rol r)
        {
            _permisos.Add(r);
        }

        public override Boolean eliminarPermiso(Rol r)
        {
            return _permisos.Remove(r);
        }

        public override List<Rol> obtenerPermisos()
        {
            return _permisos;
        }
    }
}
