using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SegmentoDAL
    {

        Acceso acceso = new Acceso();

        public SegmentoDAL() { }

        public List<BE.Segmento> ObtenerSegmentosExpensa(int idExpensa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idExpensa", idExpensa));
            DataTable tabla = acceso.leer("OBTENER_SEGMENTOS_EXPENSA", parametros);

            List<BE.Segmento> segmentos = new List<BE.Segmento>();

            foreach (DataRow registro in tabla.Rows)
            {
                BE.Segmento s = new BE.Segmento();
                s.ID = int.Parse(registro["id"].ToString());
                s.DESCRIPCION = registro["Descripcion"].ToString();
                s.MONTO = int.Parse(registro["monto"].ToString());

                segmentos.Add(s);
            }

            return segmentos;
        }

        public int Generar(BE.Expensa expensa)
        {
            int modificados = 0;

            foreach (BE.Segmento s in expensa.SEGMENTOS)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@idExpensa", expensa.ID));
                parametros.Add(acceso.crearParametro("@descripcion", s.DESCRIPCION));
                parametros.Add(acceso.crearParametro("@monto", s.MONTO));

                modificados += acceso.escribir("INSERTAR_SEGMENTO", parametros);   
            }

            return modificados;
        }
    }
}
