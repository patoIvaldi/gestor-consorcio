using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HASH_GLOBAL
    {

        public HASH_GLOBAL() { }

		private string nombreTabla;

		public string NOMBRE_TABLA
		{
			get { return nombreTabla; }
			set { nombreTabla = value; }
		}

		private string idvGlobal;

		public string IDV_GLOBAL
		{
			get { return idvGlobal; }
			set { idvGlobal = value; }
		}

        public override string ToString()
        {
            return this.nombreTabla + " --> " + this.idvGlobal;
        }

    }
}
