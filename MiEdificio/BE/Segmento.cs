using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Segmento
    {

        public Segmento()
        {

        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private float monto;

        public float MONTO
        {
            get { return monto; }
            set { monto = value; }
        }

        public override string ToString()
        {
            return this.id + " - " + this.descripcion + " - " + this.monto;
        }
    }
}
