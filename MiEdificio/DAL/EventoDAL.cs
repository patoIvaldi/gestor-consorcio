using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventoDAL
    {

        Acceso acceso = new Acceso();

        public EventoDAL() { }

        //lista todos los eventos ordenados descendentemete por fecha y hora
        //se puede definir un maximo de registros mediante el parametro cantRegistros
        public List<BE.Evento> Listar(int cantRegistros=0)
        {
            List<BE.Evento> eventos = new List<BE.Evento>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@cantRegistros", cantRegistros>0?cantRegistros:1000));

            DataTable tabla = acceso.leer("LISTAR_EVENTOS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Evento v = new BE.Evento();
                v.ID = int.Parse(registro["id"].ToString());
                v.FECHA_OCURRENCIA = DateTime.Parse(registro["fecha"].ToString().Substring(0,9)+" "+registro["hora"].ToString());
                v.MODULO = registro["modulo"].ToString();
                v.OPERACION = registro["operacion"].ToString();
               // v.USUARIO = registro["usuario"].ToString();
                v.CRITICIDAD = registro["criticidad"].ToString();
                v.DETALLE = registro["detalle"].ToString();

                eventos.Add(v);
            }
            return eventos;
        }

        //metodo encargado de realizar la busqueda de eventos mediante los filtros que se carguen
        //la logica para saber que parametros estan cargados esta del lado del stored procedure de la BD
        public List<BE.Evento> BuscarEventos(DateTime? fechaIni = null, TimeSpan? horaIni = null, DateTime? fechaFin = null,
            TimeSpan? horaFin = null, string usuario = null, string operacion = null, string criticidad = null, string modulo = null)
        {
            List<BE.Evento> eventos = new List<BE.Evento>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@fechaIni", fechaIni));
            parametros.Add(acceso.crearParametro("@fechaFin", fechaFin));
            parametros.Add(acceso.crearParametro("@horaIni", horaIni));
            parametros.Add(acceso.crearParametro("@horaFin", horaFin));
            parametros.Add(acceso.crearParametro("@usuario", usuario));
            parametros.Add(acceso.crearParametro("@modulo", modulo));
            parametros.Add(acceso.crearParametro("@operacion", operacion));
            parametros.Add(acceso.crearParametro("@criticidad", criticidad));

            DataTable tabla = acceso.leer("BUSCAR_EVENTOS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Evento v = new BE.Evento();
                v.ID = int.Parse(registro["id"].ToString());
                v.FECHA_OCURRENCIA = DateTime.Parse(registro["fecha"].ToString().Substring(0, 9) + " " + registro["hora"].ToString());
                v.MODULO = registro["modulo"].ToString();
                v.OPERACION = registro["operacion"].ToString();
                // v.USUARIO = registro["usuario"].ToString();
                v.CRITICIDAD = registro["criticidad"].ToString();
                v.DETALLE = registro["detalle"].ToString();

                eventos.Add(v);
            }
            return eventos;
        }

    }
}
