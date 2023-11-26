using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reserva
    {

        public Reserva() {

			this.fechaCreacion = DateTime.Now;
		
		}

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}


		private string estado;

		public string ESTADO
		{
			get { return estado; }
			set { estado = value; }
		}

		private string area;

		public string AREA
		{
			get { return area; }
			set { area = value; }
		}


		private DateTime fechaCreacion;

		public DateTime FECHA_CREACION
		{
			get { return fechaCreacion; }
			set { fechaCreacion = value; }
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

		private BE.Usuario usuarioAutor;

		public BE.Usuario USUARIO_AUTOR
		{
			get { return usuarioAutor; }
			set { usuarioAutor = value; }
		}

		private string feedback;

		public string FEEDBACK
		{
			get { return feedback; }
			set { feedback = value; }
		}


	}
}
