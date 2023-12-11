using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ganancia
    {

        public Ganancia() { }

		private int anio;

		public int ANIO
		{
			get { return anio; }
			set { anio = value; }
		}

		private int mes;

		public int MES
		{
			get { return mes; }
			set { mes = value; }
		}

		private double ganancia;

		public double GANANCIA
		{
			get { return ganancia; }
			set { ganancia = value; }
		}

        private string idv;

        public string IDV
        {
            get { return idv; }
            set { idv = value; }
        }

        public override string ToString()
        {
            return this.mes+"/"+this.anio+" --> $"+this.ganancia;
        }

    }
}
