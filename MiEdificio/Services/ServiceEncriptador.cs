using BE;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class ServiceEncriptador
    {

        private ServiceEncriptador() { 
        
        }

        private static ServiceEncriptador _instance;

        //singleton de la instancia del encriptador
        public static ServiceEncriptador Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceEncriptador();
                }
                return _instance;
            }
        }

        //metodo que encripta mediante Hash
        public Usuario Encriptar(Usuario user)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream2 = null;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            stream2 = sha256.ComputeHash(encoding.GetBytes(user.CONTRASENIA));
            for (int i = 0; i < stream2.Length; i++)
            {
                sb2.AppendFormat("{0:x2}", stream2[i]);
            }
            Usuario userEncriptado = new Usuario();
            userEncriptado.USERNAME = user.USERNAME;
            userEncriptado.CONTRASENIA = sb2.ToString();
            return userEncriptado; // TODO poner de nuevo userEncriptado, use user solo para testing
        }

        //metodo que encripta mediante palabra secreta y forma Hash
        public Usuario Encriptar(Usuario user, string cadena)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            if (cadena.Equals("PassWord"))
            {
                stream = sha256.ComputeHash(encoding.GetBytes(user.CONTRASENIA));
                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                user.CONTRASENIA = sb.ToString();
            }
            return user;
        }

    }
}