using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PerfilBLL
    {
        DAL.PerfilDAL perfilDAL = new DAL.PerfilDAL();

        private PerfilBLL() { }

        private static PerfilBLL _instance;
        public static PerfilBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PerfilBLL();
                }
                return _instance;
            }
        }

        public BE.Perfil ObtenerPermisos(BE.Perfil perfil)
        {
            return perfilDAL.ObtenerPermisos(perfil);
        }


    }
}
