using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Metrica
    {

        public Metrica() { }

		private string campo;

		public string CAMPO
		{
			get { return campo; }
			set { campo = value; }
		}

		private string valor;

		public string VALOR
		{
			get { return valor; }
			set { valor = value; }
		}

        private string idv;

        public string IDV
        {
            get { return idv; }
            set { idv = value; }
        }

    }
}
