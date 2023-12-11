using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MetricaBLL
    {

        DAL.MetricaDAL metricaDAL = new DAL.MetricaDAL();

        public MetricaBLL() { }


        private static MetricaBLL _instance;

        //singleton para la instancia de la metrica
        public static MetricaBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MetricaBLL();
                }
                return _instance;
            }
        }

        public List<BE.Metrica> ListarMetricas()
        {
            return metricaDAL.Listar();
        }


        //metodo que realiza la generacion del hash para metricas
        private string ArmarHashMetricas(BE.Metrica metrica)
        {
            string cadena = metrica.CAMPO + metrica.VALOR;

            metrica.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return metrica.IDV;
        }

        private void ArmarHashGlobalMetricas()
        {
            //buscamos la lista de todos los usuarios
            List<BE.Metrica> metricas = ListarMetricas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Metrica m in metricas)
            {
                cadenaIDVs += m.IDV != null ? m.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalMetrica = new BE.HASH_GLOBAL();
            idvGlobalMetrica.NOMBRE_TABLA = Enumerador.TablaIDV.METRICA.ToString();
            idvGlobalMetrica.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalMetrica);
        }

        public string RecalcularHashGlobalMetricas()
        {
            //buscamos la lista de todas las metricas
            List<BE.Metrica> metricas = ListarMetricas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Metrica m in metricas)
            {
                string idvRecalculado = ArmarHashMetricas(m);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            List<BE.Metrica> metricas = ListarMetricas();
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Metrica m in metricas)
            {
                //recalculamos el hash para cada metrica
                string nuevoHashMetrica = ArmarHashMetricas(m);

                //persistimos el nuevo hash en la tabla de metricas
                metricaDAL.ActualizarIDVMetrica(m, nuevoHashMetrica);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashMetrica != null ? nuevoHashMetrica : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalMetrica = new BE.HASH_GLOBAL();
            idvGlobalMetrica.NOMBRE_TABLA = Enumerador.TablaIDV.METRICA.ToString();
            idvGlobalMetrica.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalMetrica);
        }

    }
}
