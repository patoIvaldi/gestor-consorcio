using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Persona
    {

        private Int64 dni;

        public Int64 DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;

        public string APELLIDO
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private DateTime fechaDeNacimiento;

        public DateTime FECHA_NACIMIENTO
        {
            get { return fechaDeNacimiento; }
            set { fechaDeNacimiento = value; }
        }

        private int edad;

        //calculo de la edad
        public int EDAD
        {
            get { return DateTime.Today.Year - fechaDeNacimiento.Year; }
        }

    }
}
