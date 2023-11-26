using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HashGlobalDAL
    {

        Acceso acceso = new Acceso();

        public HashGlobalDAL()
        {

        }

        public int InsertarHashGlobal(BE.HASH_GLOBAL hash)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@nombreTabla", hash.NOMBRE_TABLA));
            parametros.Add(acceso.crearParametro("@idvGlobal", hash.IDV_GLOBAL));

            modificados = acceso.escribir("INSERTAR_HASH_GLOBAL", parametros);

            return modificados;
        }

        public Boolean BuscarHashGlobal(string hashABuscar)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idvGlobal", hashABuscar));

            DataTable tabla = acceso.leer("BUSCAR_IDV_GLOBAL", parametros);
            int total = 0;
            foreach (DataRow registro in tabla.Rows)
            {
                total += int.Parse(registro["total"].ToString());
            }

            return total > 0 ? true : false;
        }

    }
}
