using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GananciaDAL
    {

        Acceso acceso = new Acceso();

        public GananciaDAL() { }

        public List<BE.Ganancia> Listar(int anio = 0)
        {
            List<BE.Ganancia> ganancias = new List<BE.Ganancia>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@anio", anio));

            DataTable tabla = acceso.leer("LISTAR_GANANCIAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Ganancia g = new BE.Ganancia();
                g.ANIO = int.Parse(registro["anio"].ToString());
                g.MES = int.Parse(registro["mes"].ToString());
                g.GANANCIA = double.Parse(registro["ganancia"].ToString());
                g.IDV = registro["idv"].ToString();

                ganancias.Add(g);
            }
            return ganancias;
        }

        //retorna la lista de anios con ganancias
        public List<string> ListarAnios()
        {
            List<string> anios = new List<string>();

            DataTable tabla = acceso.leer("LISTAR_ANIOS", null);
            foreach (DataRow registro in tabla.Rows)
            {
                string valor = registro["anio"].ToString();

                anios.Add(valor);
            }
            return anios;
        }

        public Boolean ActualizarIDVGanancia(BE.Ganancia ganancia, string idv)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idv", idv));
            parametros.Add(acceso.crearParametro("@anio", ganancia.ANIO));
            parametros.Add(acceso.crearParametro("@mes", ganancia.MES));
            int modificados = acceso.escribir("ACTUALIZAR_IDV_GANANCIA", parametros);

            return modificados != 0 ? true : false;
        }

    }
}
