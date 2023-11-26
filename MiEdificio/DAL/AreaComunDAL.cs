using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AreaComunDAL
    {
        Acceso acceso = new Acceso();

        public AreaComunDAL() { }

        public List<BE.AreaComun> Listar()
        {
            List<BE.AreaComun> areas = new List<BE.AreaComun>();

            List<SqlParameter> parametros = new List<SqlParameter>();

            DataTable tabla = acceso.leer("LISTAR_AREAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.AreaComun a = new BE.AreaComun();
                a.NOMBRE = registro["nombre"].ToString();
                a.DESCRIPCION = registro["descripcion"].ToString();
                a.ES_AREA_HABILITADA = Boolean.Parse(registro["estaHabilitada"].ToString());

                areas.Add(a);
            }
            return areas;
        }

        public int AgregarArea(BE.AreaComun area)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@nombre", area.NOMBRE));
            parametros.Add(acceso.crearParametro("@descripcion", area.DESCRIPCION));
            parametros.Add(acceso.crearParametro("@esHabilitada", area.ES_AREA_HABILITADA));

            modificados = acceso.escribir("INSERTAR_AREA", parametros);

            return modificados;
        }


    }
}
