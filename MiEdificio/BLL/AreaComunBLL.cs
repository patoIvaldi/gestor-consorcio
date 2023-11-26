using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AreaComunBLL
    {
        DAL.AreaComunDAL areaComunDAL = new DAL.AreaComunDAL();

        public AreaComunBLL() { }

        private static AreaComunBLL _instance;

        //singleton para la instancia del evento
        public static AreaComunBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AreaComunBLL();
                }
                return _instance;
            }
        }

        public List<BE.AreaComun> ListarAreas()
        {
            return areaComunDAL.Listar();
        }

        public Boolean AgregarArea(BE.AreaComun area)
        {
            return areaComunDAL.AgregarArea(area) > 0 ? true : false;
        }
    }
}
