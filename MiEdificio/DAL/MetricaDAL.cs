using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetricaDAL
    {

        Acceso acceso = new Acceso();

        public MetricaDAL() { }


        public List<BE.Metrica> Listar()
        {
            List<BE.Metrica> metricas = new List<BE.Metrica>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@ordenamiento", true));

            DataTable tabla = acceso.leer("LISTAR_METRICAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Metrica m = new BE.Metrica();
                m.CAMPO = registro["usuario"].ToString();
                m.VALOR = registro["cantidad_reservas"].ToString();
                m.IDV = registro["idv"].ToString();

                metricas.Add(m);
            }
            return metricas;
        }

        public Boolean ActualizarIDVMetrica(BE.Metrica metrica, string idv)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idv", idv));
            parametros.Add(acceso.crearParametro("@usuario", metrica.CAMPO));
            int modificados = acceso.escribir("ACTUALIZAR_IDV_METRICA", parametros);

            return modificados != 0 ? true : false;
        }
    }
}
