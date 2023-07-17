using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisoBLL
    {
        DAL.PermisoDAL permisoDAL = new DAL.PermisoDAL();

        private PermisoBLL() { }

        private static PermisoBLL _instance;
        public static PermisoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PermisoBLL();
                }
                return _instance;
            }
        }

        //obtiene todos los permisos configurados en la BD
        public List<BE.PermisoSimple> ObtenerPermisosConfigurados()
        {
            return permisoDAL.ObtenerPermisosConfigurados();
        }

        public List<BE.PermisoSimple> ObtenerPermisosHijos(BE.PermisoSimple perMaestro)
        {
            return permisoDAL.ObtenerPermisosHijos(perMaestro);
        }

        public List<BE.PermisoSimple> ObtenerPermisosAsociadosAlPerfil(BE.Perfil perfil)
        {
            return permisoDAL.ObtenerListaPermisos(perfil);
        }

        public Boolean InsertarOModificar(BE.PermisoSimple newPermiso)
        {
            return permisoDAL.InsertarOModificar(newPermiso) > 0;
        }

        public Boolean Borrar(BE.PermisoSimple permiso)
        {
            return permisoDAL.Borrar(permiso) > 0;
        }

        public Boolean ExistePermisoEnPerfil(int idPerfil, int idPermiso)
        {
            return permisoDAL.existePermisoPerfil(idPerfil,idPermiso);
        }

        public Boolean AsociarPermisoPefil(int idPerfil, int idPermiso)
        {
            return permisoDAL.AsociarPermisoPerfil(idPerfil,idPermiso) > 0;
        }

        public Boolean DesasociarPermisoPefil(int idPerfil, int idPermiso)
        {
            return permisoDAL.DesasociarPermisoPerfil(idPerfil, idPermiso) > 0;
        }

        public Boolean ExistePermisoEnPermiso(int idPermisoPadre, int idPermisoHijo)
        {
            return permisoDAL.existePermisoPermiso(idPermisoPadre, idPermisoHijo);
        }

        public Boolean AsociarPermisoPermiso(int idPermisoPadre, int idPermisoHijo)
        {
            return permisoDAL.AsociarPermisoPermiso(idPermisoPadre, idPermisoHijo) > 0;
        }

    }
}
