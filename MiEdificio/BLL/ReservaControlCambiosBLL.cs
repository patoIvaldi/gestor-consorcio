using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaControlCambiosBLL
    {
        DAL.ReservaControlCambiosDAL controlDAL = new DAL.ReservaControlCambiosDAL();

        public ReservaControlCambiosBLL() { }

        private static ReservaControlCambiosBLL _instance;

        //singleton para la instancia del ReservaControlCambiosBLL
        public static ReservaControlCambiosBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReservaControlCambiosBLL();
                }
                return _instance;
            }
        }

        //busca los cambios registrados en sistema para las reservas
        //puede indicar por parametro la cantidad de registros que quiera retornar
        public List<BE.ReservaControlCambios> ListarCambiosReservas(int cantRegistros = 0)
        {
            return controlDAL.Listar(cantRegistros);
        }

        //metodo que busca los cambios en las reservas en base a los parametros enviados
        public List<BE.ReservaControlCambios> BuscarCambiosReservas(DateTime? fechaIni = null, TimeSpan? horaIni = null, DateTime? fechaFin = null,
            TimeSpan? horaFin = null, string usuario = null, string estado = null, Boolean? esActivo = null)
        {
            if(fechaIni != null && horaIni != null)
            {
                fechaIni = fechaIni + horaIni;
            }

            if (fechaFin != null && horaFin != null)
            {
                fechaFin = fechaFin + horaFin;
            }
            
            return controlDAL.BuscarCambiosReservas(fechaIni, fechaFin, usuario, estado, esActivo);
        }

        //metodo que agrega el versionado en base a una reserva
        public Boolean agregarCambio(BE.Reserva reserva,string detalle)
        {
            return controlDAL.AgregarCambio(reserva, detalle) > 0? true:false;
        }
    }
}
