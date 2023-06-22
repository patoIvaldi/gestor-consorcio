using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceIdioma : ServiceSubject
    {

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                Notify(this);
            }
        }

        public override string ToString()
        {
            return descripcion;
        }

    }
}
