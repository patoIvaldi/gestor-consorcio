using DAL;

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

        public BE.Usuario Login(BE.Usuario user)
        {
            user = usuarioDAL.ValidateUser(
                Services.ServiceEncriptador.Instance.Encriptar(user));

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


    }
}