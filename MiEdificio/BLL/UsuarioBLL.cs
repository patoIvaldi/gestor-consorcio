using BE;
using DAL;
using Microsoft.VisualBasic.ApplicationServices;
using Services;

namespace BLL
{
    public class UsuarioBLL
    {

        DAL.UsuarioDAL usuarioDAL = new DAL.UsuarioDAL();
        public BE.Usuario userOut;

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

        public BE.Usuario Login(BE.Usuario userIn, ServiceIdioma idiomaElegido)
        {
            userOut = usuarioDAL.ValidateUser(
                Services.ServiceEncriptador.Instance.Encriptar(userIn)
                , idiomaElegido);

            if (userOut != null)
            {
                userOut.PERFIL = PerfilBLL.Instance.ObtenerPermisos(userOut.PERFIL);
                Services.ServiceSesion.Instance.IniciarSesion(userOut);

            } //camino por usuarios que hayan ingresado mal la contraseña
            else
            {
                BE.Usuario userBuscado = usuarioDAL.listar(userIn.USERNAME).FirstOrDefault();

                //busco por username solamente
                if (userBuscado != null)
                {
                    //si existe usuario, le sumo un intento erroneo
                    usuarioDAL.sumarIntentoErroneo(userBuscado.USERNAME);

                    if((userBuscado.CANT_INTENTOS + 1) > 3 && !userBuscado.ESTA_BLOQUEADO)
                    {
                        bloquearDesbloquearUsuario(userBuscado.USERNAME);
                    }
                }
            }

            return userOut;
        }

        public void Logout()
        {
            Services.ServiceSesion.Instance.CerrarSesion();
        }

        public Boolean bloquearDesbloquearUsuario(string username)
        {
            return usuarioDAL.desbloquearUsuario(username);        
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

        public Boolean esUsuarioBloqueado(string username)
        {
            BE.Usuario usuario = usuarioDAL.listar(username).FirstOrDefault();

            return usuario != null ? usuario.ESTA_BLOQUEADO : false;
        }

        public Boolean CambiarPerfilUsuario(BE.Usuario usu, BE.Perfil perf)
        {
            return usuarioDAL.CambiarPerfilUsuario(usu,perf);
        }

        public Boolean ExistePermiso(string nombrePermisoABuscar)
        {
            Boolean existe = false;

            foreach (BE.Rol permiso in this.userOut.PERFIL.obtenerPermisos())
            {
                //itero mientras no se haya encontrado
                if (!existe)
                {
                    if (permiso is BE.PermisoSimple)
                    {
                        existe = ((BE.PermisoSimple)permiso).NOMBRE.Trim().Equals(nombrePermisoABuscar.Trim());

                    }else if (permiso is BE.Perfil)
                    {
                       // existe = ((BE.Perfil)permiso).NOMBRE.Trim().Equals(nombrePermisoABuscar.Trim());
                    }
                }
            }

            return existe;
        }
    }
}