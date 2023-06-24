using BE;
using DAL;
using Microsoft.VisualBasic.ApplicationServices;
using Services;

namespace BLL
{
    public class UsuarioBLL
    {

        DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();

        public UsuarioBLL()
        {
        
        }

        private static UsuarioBLL _instance;

        //singleton para la instancia del usuario
        public static UsuarioBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioBLL();
                }
                return _instance;
            }
        }

        public BE.Usuario Login(BE.Usuario user, ServiceIdioma idiomaElegido)
        {
            user = usuarioDAL.ValidateUser(
                Services.ServiceEncriptador.Instance.Encriptar(user)
                ,idiomaElegido);

            if (user != null)
            {
                user.PERFIL = PerfilBLL.Instance.ObtenerPermisos(user.PERFIL);
                Services.ServiceSesion.Instance.IniciarSesion(user);
            }

            return user;
        }

        public void Logout()
        {
            Services.ServiceSesion.Instance.CerrarSesion();
        }

        //metodo que realiza el cambio de contraseña del usuario
        //public Boolean cambiarPassword(BE.Usuario userModif)
        //{
            //return usuarioDAL.cambiarPassword(
              //  Services.ServiceEncriptador.Instance.Encriptar(userModif));
        //}

        public Boolean bloquearDesbloquearUsuario(string username)
        {
            return usuarioDAL.desbloquearUsuario(username);        
        }

        public int marcarIntentoFallido()
        {
            //recupero los intentos que tiene
            //le sumo uno
            //llego a los 3? bloqueo
            //sino no hago nada
            //retorno cantidad de intentos fallidos hasta el momento.
            return 0;
        }

        //metodo que busca todos los usuarios en la BD
        public List<BE.Usuario> listarUsuarios()
        {
            return usuarioDAL.listar(string.Empty);
        }

        public Boolean insertarOEditarUsuario(BE.Usuario usuario)
        {
            int registro = 0;

            if (existeUsuario(usuario.USERNAME))
            {
                registro = usuarioDAL.Editar(usuario);
            }
            else
            {
                registro = usuarioDAL.Insertar(usuario);
            }

            return registro > 0 ? true:false; 
        }

        public Boolean existeUsuario(string username)
        {
            return !string.IsNullOrEmpty(username)?usuarioDAL.listar(username).Count > 0:false;
        }
    }
}