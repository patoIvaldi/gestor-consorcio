using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SegmentoBLL
    {

        DAL.SegmentoDAL segmentoDAL = new DAL.SegmentoDAL();

        public SegmentoBLL() { }

        private static SegmentoBLL _instance;

        //singleton para la instancia del segmento
        public static SegmentoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SegmentoBLL();
                }
                return _instance;
            }
        }

        public List<BE.Segmento> obtenerSegmentosExpensa(int idExpensa)
        {
            return segmentoDAL.ObtenerSegmentosExpensa(idExpensa);
        }

        public List<BE.Segmento> obtenerSegmentos()
        {
            return segmentoDAL.ObtenerSegmentos();
        }

        //metodo que realiza la generacion del hash para el segmento
        public string ArmarHashSegmento(BE.Segmento segmento)
        {
            string cadena = segmento.DESCRIPCION + segmento.MONTO.ToString();

            segmento.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return segmento.IDV;
        }

        public void ArmarHashGlobalSegmento()
        {
            //buscamos la lista de todos los segmentos
            List<BE.Segmento> segmentos = obtenerSegmentos();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Segmento s in segmentos)
            {
                cadenaIDVs += s.IDV != null ? s.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalSegmento = new BE.HASH_GLOBAL();
            idvGlobalSegmento.NOMBRE_TABLA = Enumerador.TablaIDV.SEGMENTO.ToString();
            idvGlobalSegmento.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalSegmento);
        }

        public string RecalcularHashGlobalSegmentos()
        {
            //buscamos la lista de todos los segmentos
            List<BE.Segmento> segmentos = obtenerSegmentos();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Segmento s in segmentos)
            {
                string idvRecalculado = ArmarHashSegmento(s);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            //buscamos la lista de todos los segmentos
            List<BE.Segmento> segmentos = obtenerSegmentos();
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Segmento s in segmentos)
            {
                //recalculamos el hash para cada segmento
                string nuevoHashSegmento = ArmarHashSegmento(s);

                //persistimos el nuevo hash en la tabla de segmentos
                segmentoDAL.ActualizarIDVSegmento(s, nuevoHashSegmento);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashSegmento != null ? nuevoHashSegmento : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalSegmento = new BE.HASH_GLOBAL();
            idvGlobalSegmento.NOMBRE_TABLA = Enumerador.TablaIDV.SEGMENTO.ToString();
            idvGlobalSegmento.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalSegmento);
        }
    }
}
