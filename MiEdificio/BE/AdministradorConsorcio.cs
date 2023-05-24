using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AdministradorConsorcio : Persona
    {

        public AdministradorConsorcio()
        {

        }

        public AdministradorConsorcio(string cuit,DateTime fechaFin,
            DateTime fechaInicio,string nombreEmpre, string razonSocial)
        {
            this.cuit = cuit;
            this.razonSocial = razonSocial;
            this.nombreEmpresa = nombreEmpre;
            this.fechaFinConcesion = fechaFin;
            this.fechaInicioConcesion = fechaInicio;
        }


        private string cuit;

        public string CUIT
        {
            get { return cuit; }
            set { cuit = value; }
        }

        private DateTime fechaFinConcesion;

        public DateTime FECHA_FIN_CONCESION
        {
            get { return fechaFinConcesion; }
            set { fechaFinConcesion = value; }
        }

        private DateTime fechaInicioConcesion;

        public DateTime FECHA_INICIO_CONCESION
        {
            get { return fechaInicioConcesion; }
            set { fechaInicioConcesion = value; }
        }

        private string nombreEmpresa;

        public string NOMBRE_EMPRESA
        {
            get { return nombreEmpresa; }
            set { nombreEmpresa = value; }
        }

        private string razonSocial;

        public string RAZON_SOCIAL
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }



    }
}
