using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAL
    {
        Acceso acceso = new Acceso();

        public ReservaDAL() { }

        //lista todas las reservas ordenados descendentemete por fecha y hora
        //se puede definir un maximo de registros mediante el parametro cantRegistros
        public List<BE.Reserva> Listar(int cantRegistros = 0)
        {
            List<BE.Reserva> reservas = new List<BE.Reserva>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@cantRegistros", cantRegistros > 0 ? cantRegistros : 1000));

            DataTable tabla = acceso.leer("LISTAR_RESERVAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Reserva r = new BE.Reserva();
                r.ID = int.Parse(registro["id_reserva"].ToString());
                r.ESTADO = registro["estado"].ToString();
                r.FECHA_CREACION = DateTime.Parse(registro["Fecha_creacion"].ToString());
                r.AREA = registro["area"].ToString();
                r.FECHA_RESERVA_INICIO = DateTime.Parse(registro["Fecha_reserva_inicio"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_inicio"].ToString());
                r.FECHA_RESERVA_FIN = DateTime.Parse(registro["Fecha_reserva_fin"].ToString().Substring(0, 10) + " " + registro["Hora_reserva_fin"].ToString());
                r.USUARIO_AUTOR = new UsuarioDAL().listar(registro["usuario"].ToString()).First();
                r.FEEDBACK = registro["feedback"].ToString();

                reservas.Add(r);
            }
            return reservas;
        }

        //metodo que persiste la reserva en la bd
        public int AgregarReserva(BE.Reserva reserva)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@estado", reserva.ESTADO));
            parametros.Add(acceso.crearParametro("@fechaCreacion", reserva.FECHA_CREACION));
            parametros.Add(acceso.crearParametro("@area", reserva.AREA));
            parametros.Add(acceso.crearParametro("@fechaReservaInicio", reserva.FECHA_RESERVA_INICIO.Date));
            parametros.Add(acceso.crearParametro("@horaReservaInicio", reserva.FECHA_RESERVA_INICIO.TimeOfDay));
            parametros.Add(acceso.crearParametro("@fechaReservaFin", reserva.FECHA_RESERVA_FIN.Date));
            parametros.Add(acceso.crearParametro("@horaReservaFin", reserva.FECHA_RESERVA_FIN.TimeOfDay));
            parametros.Add(acceso.crearParametro("@usuario", reserva.USUARIO_AUTOR.USERNAME));
            parametros.Add(acceso.crearParametro("@feedback", reserva.FEEDBACK));

            modificados = acceso.escribir("INSERTAR_RESERVA", parametros);

            BE.Reserva? generadaReciente = Listar(1).FirstOrDefault();

            reserva.ID = generadaReciente != null? generadaReciente.ID : 0;

            new ReservaControlCambiosDAL().AgregarCambio(reserva,"");

            return modificados;
        }

        //generamos el feedback de la reserva
        public int GenerarFeedback(int idReserva, string feedback)
        {
            int modificados = 0;

            //new ReservaControlCambiosDAL().AgregarCambio(reserva, ""); ACA HAY QUE BUSCAR POR ID LA RESERVA

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idReserva", idReserva));
            parametros.Add(acceso.crearParametro("@feedback", feedback));

            modificados = acceso.escribir("GENERAR_FEEDBACK", parametros);

            return modificados;
        }

        public int ModificarReserva(BE.Reserva reserva)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idReserva", reserva.ID));
            parametros.Add(acceso.crearParametro("@estado", reserva.ESTADO));
            parametros.Add(acceso.crearParametro("@area", reserva.AREA));
            parametros.Add(acceso.crearParametro("@fechaIni", reserva.FECHA_RESERVA_INICIO.Date));
            parametros.Add(acceso.crearParametro("@horaIni", reserva.FECHA_RESERVA_INICIO.TimeOfDay));
            parametros.Add(acceso.crearParametro("@fechaFin", reserva.FECHA_RESERVA_FIN.Date));
            parametros.Add(acceso.crearParametro("@horaFin", reserva.FECHA_RESERVA_FIN.TimeOfDay));
            parametros.Add(acceso.crearParametro("@usuario", reserva.USUARIO_AUTOR.USERNAME));
            parametros.Add(acceso.crearParametro("@feedback", reserva.FEEDBACK));

            modificados = acceso.escribir("MODIFICAR_RESERVA", parametros);

            //registramos el cambio de version
            new ReservaControlCambiosDAL().AgregarCambio(reserva, "");

            return modificados;
        }

        public Boolean ValidarDisponibilidad(BE.Reserva reserva)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@area", reserva.AREA));
            parametros.Add(acceso.crearParametro("@fechaIni", reserva.FECHA_RESERVA_INICIO.Date));
            parametros.Add(acceso.crearParametro("@horaIni", reserva.FECHA_RESERVA_INICIO.TimeOfDay));
            parametros.Add(acceso.crearParametro("@fechaFin", reserva.FECHA_RESERVA_FIN.Date));
            parametros.Add(acceso.crearParametro("@horaFin", reserva.FECHA_RESERVA_FIN.TimeOfDay));
            parametros.Add(acceso.crearParametro("@usuario", reserva.USUARIO_AUTOR.USERNAME));

            DataTable tabla = acceso.leer("VALIDAR_DISPONIBILIDAD", parametros);
            int total = 0;
            foreach (DataRow registro in tabla.Rows)
            {
                total += int.Parse(registro["Id_Reserva"].ToString());
            }

            return total>0?true:false;
        }

        public DataTable CantidadReservas(Boolean ordenDescendente)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@ordenamiento", ordenDescendente));

            return acceso.leer("LISTAR_METRICAS", parametros);
        }

    }
}
