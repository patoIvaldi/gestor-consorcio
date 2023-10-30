using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReservaControlCambios
    {

        public ReservaControlCambios() { }

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

        private DateTime fechaCreacionCambio;

        public DateTime FECHA_CREACION_CAMBIO
        {
            get { return fechaCreacionCambio; }
            set { fechaCreacionCambio = value; }
        }

        private Boolean esActivo;

        public Boolean ES_ACTIVO
        {
            get { return esActivo; }
            set { esActivo = value; }
        }

        private int idReserva;

        public int ID_RESERVA
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        private string estadoReserva;

        public string ESTADO_RESERVA
        {
            get { return estadoReserva; }
            set { estadoReserva = value; }
        }

        private DateTime fechaCreacionReserva;

        public DateTime FECHA_CREACION_RESERVA
        {
            get { return fechaCreacionReserva.Date; }
            set { fechaCreacionReserva = value; }
        }

        public TimeSpan HORA_CREACION_RESERVA
        {
            get { return fechaCreacionReserva.TimeOfDay; }
            //set { horaOcurrencia = value; }
        }

        private DateTime fechaReservaInicio;

        public DateTime FECHA_RESERVA_INICIO
        {
            get { return fechaReservaInicio; }
            set { fechaReservaInicio = value; }
        }

        private DateTime fechaReservaFin;

        public DateTime FECHA_RESERVA_FIN
        {
            get { return fechaReservaFin; }
            set { fechaReservaFin = value; }
        }

        private BE.Usuario usuarioReserva;

        public BE.Usuario USUARIO_RESERVA
        {
            get { return usuarioReserva; }
            set { usuarioReserva = value; }
        }

        private string detalle;

        public string DETALLE
        {
            get { return detalle; }
            set { detalle = value; }
        }

    }
}
