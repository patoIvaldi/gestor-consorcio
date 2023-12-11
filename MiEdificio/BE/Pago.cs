using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Pago
    {

        public Pago() {

			this.fechaEjecucion = DateTime.Now;
		}

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

        private int codSeguridad;

        public int COD_SEGURIDAD
        {
            get { return codSeguridad; }
            set { codSeguridad = value; }
        }

		private DateTime fechaEjecucion;

		public DateTime FECHA_EJECUCION
		{
			get { return fechaEjecucion; }
			set { fechaEjecucion = value; }
		}

        private DateTime? fechaVencTarjeta;

        public DateTime? FECHA_VENC_TARJETA
        {
            get { return fechaVencTarjeta; }
            set { fechaVencTarjeta = value; }
        }

		private string formaPago;

		public string FORMA_PAGO
		{
			get { return formaPago; }
			set { formaPago = value; }
		}

		private float monto;

		public float MONTO
		{
			get { return monto; }
			set { monto = value; }
		}

		private string nombreTarjeta;

		public string NOMBRE_TARJETA
		{
			get { return nombreTarjeta; }
			set { nombreTarjeta = value; }
		}

		private Int64 nroTarjeta;

		public Int64 NRO_TARJETA
		{
			get { return nroTarjeta; }
			set { nroTarjeta = value; }
		}

		private Int64 dni;

		public Int64 DNI
		{
			get { return dni; }
			set { dni = value; }
		}

        private string idv;

        public string IDV
        {
            get { return idv; }
            set { idv = value; }
        }

        public override string ToString()
        {
            return this.fechaEjecucion.Date + " - N° P" + this.id;
        }
    }
}
