using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Propietario : Persona
    {
        private long nroTelefono;

        public long NRO_TELEFONO
        {
            get { return nroTelefono; }
            set { nroTelefono = value;}
        }

        private string nroDepartamento;

        public string NRO_DEPARTAMENTO
        {
            get { return nroDepartamento; }
            set { nroDepartamento = value; }
        }


        public Propietario()
        {

        }

        public Propietario(long nroTel)
        {
            this.nroTelefono= nroTel;
        }

        public override string ToString()
        {
            return this.DNI + " - " + this.APELLIDO + ", " + this.NOMBRE;
        }


    }
}
