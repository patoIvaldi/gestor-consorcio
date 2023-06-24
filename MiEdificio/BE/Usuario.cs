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

       // private int id;
        //public int ID
        //{
          //  get { return id; }
            //set { id = value; }
        //}

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
            set { fechaAlta = value; }
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

        //private Idioma idiomaPreferido;

        //public Idioma IDIOMA_PREFERIDO
        //{
           // get { return idiomaPreferido; }
            //set { idiomaPreferido = value; }
        //}

        private Persona persona;

        public Persona PERSONA
        {
            get { return persona; }
            set { persona = value; }
        }

        private Perfil perfil;

        public Perfil PERFIL
        {
            get { return perfil; }
            set { perfil = value; }
        }

        private Boolean estaBloqueado;

        public Boolean ESTA_BLOQUEADO
        {
            get { return estaBloqueado; }
            set { estaBloqueado = value; }
        }

        public override string ToString()
        {
            return this.USERNAME.Trim() + " - " + this.MAIL.Trim();
        }
    }
}
