using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Expensa
    {

		public Expensa() {

			this.fechaEmision = DateTime.Today;
			this.fecha1erVencimiento = this.fechaEmision.Value.AddDays(30);
			this.fecha2doVencimiento = this.fechaEmision.Value.AddDays(45);
		}

		public Expensa(DateTime? fechaEmision) { 
		
			this.fechaEmision = fechaEmision;
            this.fecha1erVencimiento = this.fechaEmision.Value.AddDays(30);
            this.fecha2doVencimiento = this.fechaEmision.Value.AddDays(45);
        }

		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private float monto = 0;

		public float MONTO
		{
			get { return monto; }
			//set { monto = value; }
		}

		private DateTime? fechaEmision;

		public DateTime? FECHA_EMISION
		{
			get { return fechaEmision; }
			//set { fechaEmision = value; }
		}

		private DateTime fecha1erVencimiento;

		public DateTime DTTM_1ER_VENCIMIENTO
		{
			get { return fecha1erVencimiento; }
			//set { fecha1erVencimiento = value; }
		}

		private DateTime fecha2doVencimiento;

		public DateTime DTTM_2DO_VENCIMIENTO
		{
			get { return fecha2doVencimiento; }
			//set { fecha2doVencimiento = value; }
		}

		public string PERIODO
		{
			get { return this.fechaEmision.Value.Month + "/" + this.fechaEmision.Value.Year; }
			//set { periodo = value; }
		}

		private Boolean estado;

		public Boolean ESTADO
		{
			get { return estado; }
			set { estado = value; }
		}

		private Int64 dni;

		public Int64 DNI
		{
			get { return dni; }
			set { dni = value; }
		}

		/*private BE.Pago pagoAsociado;

		public BE.Pago PAGO_ASOCIADO
		{
			get { return pagoAsociado; }
			set { pagoAsociado = value; }
		}*/


		private List<BE.Segmento> segmentos = new List<Segmento>();

		public List<BE.Segmento> SEGMENTOS
		{
			get { return segmentos; }
		}

		public void agregarSegmento(BE.Segmento seg)
		{
			this.segmentos.Add(seg);
			monto += seg.MONTO;
		}

        public void agregarSegmentos(List<BE.Segmento> segs)
        {
            this.segmentos.AddRange(segs);
			monto += segs.Sum(seg => seg.MONTO);
        }

        public override string ToString()
        {
            return this.PERIODO + " - " + this.monto + " " + this.estado;

        }
    }
}
