using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DAL
{
    public class ReservaControlCambiosDAL
    {

        Acceso acceso = new Acceso();

        public ReservaControlCambiosDAL() { }

        //lista todos los cambios ordenados descendentemete por fecha y hora
        //se puede definir un maximo de registros mediante el parametro cantRegistros
        public List<BE.ReservaControlCambios> Listar(int cantRegistros = 0)
        {
            List<BE.ReservaControlCambios> cambios = new List<BE.ReservaControlCambios>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@cantRegistros", cantRegistros > 0 ? cantRegistros : 1000));

            DataTable tabla = acceso.leer("LISTAR_CAMBIOS_RESERVAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.ReservaControlCambios r = new BE.ReservaControlCambios();
                r.FECHA_CREACION_CAMBIO = DateTime.Parse(registro["Fecha_creacion_cambio"].ToString());
                r.ID = int.Parse(registro["id"].ToString());
                r.ID_RESERVA = int.Parse(registro["Id_Reserva"].ToString());
                r.FECHA_CREACION_RESERVA = DateTime.Parse(registro["Fecha_creacion_reserva"].ToString());
                r.ESTADO_RESERVA = registro["Estado_reserva"].ToString();
                r.FECHA_RESERVA_INICIO = DateTime.Parse(registro["Fecha_reserva_inicio"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_inicio"].ToString());
                r.FECHA_RESERVA_FIN = DateTime.Parse(registro["Fecha_reserva_fin"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_fin"].ToString());
                r.USUARIO_RESERVA = new UsuarioDAL().listar(registro["usuario_reserva"].ToString()).First();
                r.ES_ACTIVO = Boolean.Parse(registro["esActivo"].ToString());
                r.AREA = registro["Area"].ToString();
                r.FEEDBACK = registro["Feedback"].ToString();
                r.DETALLE = registro["Detalle"].ToString();

                cambios.Add(r);
            }
            return cambios;
        }

        //metodo encargado de realizar la busqueda de cambios mediante los filtros que se carguen
        //la logica para saber que parametros estan cargados esta del lado del stored procedure de la BD
        public List<BE.ReservaControlCambios> BuscarCambiosReservas(DateTime? fechaIni = null, DateTime? fechaFin = null,
            string usuario = null, string estado = null, Boolean? esActivo = null)
        {
            List<BE.ReservaControlCambios> cambios = new List<BE.ReservaControlCambios>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@fechaIni", fechaIni));
            parametros.Add(acceso.crearParametro("@fechaFin", fechaFin));
            parametros.Add(acceso.crearParametro("@usuario", usuario));
            parametros.Add(acceso.crearParametro("@estado", estado));
            parametros.Add(acceso.crearParametro("@esActivo", esActivo));

            DataTable tabla = acceso.leer("BUSCAR_CAMBIOS_RESERVAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.ReservaControlCambios r = new BE.ReservaControlCambios();
                r.ID = int.Parse(registro["id"].ToString());
                r.FECHA_CREACION_CAMBIO = DateTime.Parse(registro["Fecha_creacion_cambio"].ToString());
                r.ID_RESERVA = int.Parse(registro["Id_Reserva"].ToString());
                r.FECHA_CREACION_RESERVA = DateTime.Parse(registro["Fecha_creacion_reserva"].ToString());
                r.ESTADO_RESERVA = registro["Estado_reserva"].ToString();
                r.FECHA_RESERVA_INICIO = DateTime.Parse(registro["Fecha_reserva_inicio"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_inicio"].ToString());
                r.FECHA_RESERVA_FIN = DateTime.Parse(registro["Fecha_reserva_fin"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_fin"].ToString());
                r.USUARIO_RESERVA = new UsuarioDAL().listar(registro["usuario_reserva"].ToString()).First();
                r.ES_ACTIVO = Boolean.Parse(registro["esActivo"].ToString());
                r.AREA = registro["Area"].ToString();
                r.FEEDBACK = registro["Feedback"].ToString();
                r.DETALLE = registro["Detalle"].ToString();

                cambios.Add(r);
            }
            return cambios;
        }

        public int AgregarCambio(BE.Reserva reserva, string detalle)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@fechaCreacionCambio", DateTime.Now));
            parametros.Add(acceso.crearParametro("@idReserva", reserva.ID));
            parametros.Add(acceso.crearParametro("@estadoReserva", reserva.ESTADO));
            parametros.Add(acceso.crearParametro("@fechaCreacionReserva", reserva.FECHA_CREACION));
            parametros.Add(acceso.crearParametro("@fechaReservaInicio", reserva.FECHA_RESERVA_INICIO.Date));
            parametros.Add(acceso.crearParametro("@horaReservaInicio", reserva.FECHA_RESERVA_INICIO.TimeOfDay));
            parametros.Add(acceso.crearParametro("@fechaReservaFin", reserva.FECHA_RESERVA_FIN.Date));
            parametros.Add(acceso.crearParametro("@horaReservaFin", reserva.FECHA_RESERVA_FIN.TimeOfDay));
            parametros.Add(acceso.crearParametro("@usuarioReserva", reserva.USUARIO_AUTOR.USERNAME));
            parametros.Add(acceso.crearParametro("@area", reserva.AREA));
            parametros.Add(acceso.crearParametro("@feedback", reserva.FEEDBACK));
            parametros.Add(acceso.crearParametro("@detalle", detalle));

            modificados = acceso.escribir("INSERTAR_CAMBIO_RESERVA", parametros);

            return modificados;
        }

        public int MarcarRegistroActivo(BE.ReservaControlCambios versionElegida, BE.Reserva reserva)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idCambioReserva", versionElegida.ID));
            parametros.Add(acceso.crearParametro("@idReserva", reserva.ID));

            modificados = acceso.escribir("ACTIVAR_REG_CAMBIO_RESERVA", parametros);

            return modificados;
        }


    }
}
