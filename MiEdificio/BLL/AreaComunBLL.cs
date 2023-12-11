using BE;
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
            ArmarHashAreaComun(area);
            int registro = areaComunDAL.AgregarArea(area);
            ArmarHashGlobalAreaComun();

            return registro > 0 ? true : false;
        }

        //metodo que realiza la generacion del hash para el area comun
        private string ArmarHashAreaComun(BE.AreaComun areaComun)
        {
            string cadena = areaComun.NOMBRE + areaComun.DESCRIPCION + areaComun.ES_AREA_HABILITADA.ToString();

            areaComun.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return areaComun.IDV;
        }

        private void ArmarHashGlobalAreaComun()
        {
            //buscamos la lista de todos los usuarios
            List<BE.AreaComun> areas = ListarAreas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.AreaComun u in areas)
            {
                cadenaIDVs += u.IDV != null ? u.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalAreaComun = new BE.HASH_GLOBAL();
            idvGlobalAreaComun.NOMBRE_TABLA = Enumerador.TablaIDV.AREA_COMUN.ToString();
            idvGlobalAreaComun.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalAreaComun);
        }

        public string RecalcularHashGlobalAreasComunes()
        {
            //buscamos la lista de todas las areas
            List<BE.AreaComun> areas = ListarAreas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.AreaComun a in areas)
            {
                string idvRecalculado = ArmarHashAreaComun(a);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            List<BE.AreaComun> areas = ListarAreas();
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.AreaComun a in areas)
            {
                //recalculamos el hash para cada area comun
                string nuevoHashAreaComun = ArmarHashAreaComun(a);

                //persistimos el nuevo hash en la tabla de area comun
                areaComunDAL.ActualizarIDVAreaComun(a, nuevoHashAreaComun);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashAreaComun != null ? nuevoHashAreaComun : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalAreaComun = new BE.HASH_GLOBAL();
            idvGlobalAreaComun.NOMBRE_TABLA = Enumerador.TablaIDV.AREA_COMUN.ToString();
            idvGlobalAreaComun.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalAreaComun);
        }
    }
}
