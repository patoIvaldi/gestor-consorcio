using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {

        public Usuario() {
        
            this.fechaAlta = DateTime.Now;
        }

        public Usuario(string user, string pass) : base(){

            this.username = user;
            this.contrasenia = pass;
        }

        private int cantIntentos;

        public int CANT_INTENTOS
        {
            get { return cantIntentos; }
            set { cantIntentos = value; }
        }

        private string contrasenia;

        public string CONTRASENIA
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        private DateTime fechaAlta;

        public DateTime FECHA_ALTA
        {
            get { return fechaAlta; }
        }

        private string mail;

        public string MAIL
        {
            get { return mail; }
            set { mail = value; }
        }

        private string username;

        public string USERNAME
        {
            get { return username; }
            set { username = value; }
        }

        private Persona persona;

        public Persona PERSONA
        {
            get { return persona; }
            set { persona = value; }
        }

        //private Idioma idiomaPreferido;

        //public Idioma IDIOMA_PREFERIDO
        //{
        //    get { return username; }
        //    set { username = value; }
        //}


    }
}
