using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Evento
	{

		public Evento() {
		
			fechaOcurrencia = DateTime.Now;
		}


		private int id;

		public int ID
		{
			get { return id; }
            set { id = value; }
        }

		private DateTime fechaOcurrencia;

		public DateTime FECHA_OCURRENCIA
		{
			get { return fechaOcurrencia.Date; }
			set { fechaOcurrencia = value; }
		}

		public TimeSpan HORA_OCURRENCIA
		{
			get { return fechaOcurrencia.TimeOfDay; }
			//set { horaOcurrencia = value; }
		}

		private BE.Usuario usuario;

		public BE.Usuario USUARIO
		{
			get { return usuario; }
			set { usuario = value; }
		}

		private string modulo;

		public string MODULO
		{
			get { return modulo; }
			set { modulo = value; }
		}

        private string operacion;

        public string OPERACION
        {
            get { return operacion; }
            set { operacion = value; }
        }

		private string criticidad;

		public string CRITICIDAD
		{
			get { return criticidad; }
			set { criticidad = value; }
		}

		private string detalle;

		public string DETALLE
		{
			get { return detalle; }
			set { detalle = value; }
		}


	}
}
