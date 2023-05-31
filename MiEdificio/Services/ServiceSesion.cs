using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceSesion
    {

        private ServiceSesion() { }

        private BE.Usuario user;

        public BE.Usuario USER
        {
            get { return user; }
        }

        private static ServiceSesion _instance;

        public static ServiceSesion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceSesion();
                }
                return _instance;
            }
        }

        public void IniciarSesion(BE.Usuario _user)
        {
            if (VerificarLogeado(_user))
            {
                if (this.user == null)
                {
                    this.user = _user;
                }
                else
                {
                 //   throw new SesionActivaException();
                }
            }
            else
            {
               // throw new YaLoggeadoException();
            }
        }

        public bool VerificarLogeado(BE.Usuario _user)
        {
            return !(this.user == _user);
        }

        public void CerrarSesion()
        {
            if (user != null)
            {
                user = null;
            }
        }

    }
}
