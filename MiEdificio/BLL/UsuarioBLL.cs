using BE;
using DAL;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                        BE.Evento evento = new Evento();
                        evento.USUARIO = userBuscado;
                        evento.DETALLE = "Se le bloqueó la cuenta al usuario por máximos intentos erróneos.";
                        evento.CRITICIDAD = Enumerador.Criticidad.Critica.ToString();
                        evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
                        evento.MODULO = Enumerador.Modulo.Login.ToString();

                        BLL.EventoBLL.Instance.AgregarEvento(evento);

                        bloquearDesbloquearUsuario(userBuscado.USERNAME);
                    }

                    //actualizamos los hashes
                    ArmarHashUsuario(userBuscado);
                    ArmarHashGlobalUsuarios();
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
            Boolean bloqueadoDesbloqueado = usuarioDAL.desbloquearUsuario(username);

            //actualizamos los hashes
            BE.Usuario userBuscado = usuarioDAL.listar(username).FirstOrDefault();
            if (userBuscado != null)
            {
                ArmarHashUsuario(userBuscado);
                ArmarHashGlobalUsuarios();
            }

            return bloqueadoDesbloqueado;        
        }

        //metodo que busca todos los usuarios en la BD
        public List<BE.Usuario> listarUsuarios()
        {
            return usuarioDAL.listar(string.Empty);
        }

        public Boolean insertarOEditarUsuario(BE.Usuario usuario)
        {
            int registro = 0;

            //generamos el hash para el registro
            ArmarHashUsuario(usuario);

            if (existeUsuario(usuario.USERNAME))
            {
                registro = usuarioDAL.Editar(usuario);
            }
            else
            {
                registro = usuarioDAL.Insertar(usuario);
            }

            //refrescamos el hash global
            ArmarHashGlobalUsuarios();

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

            Boolean cambioPerfil = usuarioDAL.CambiarPerfilUsuario(usu, perf);

            //actualizamos los hashes
            BE.Usuario userBuscado = usuarioDAL.listar(usu.USERNAME).FirstOrDefault();
            if (userBuscado != null && cambioPerfil)
            {
                ArmarHashUsuario(userBuscado);
                ArmarHashGlobalUsuarios();
            }

            return cambioPerfil;
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

        //metodo que busca un usuario en base a su username
        public BE.Usuario recuperarUsuario(string username)
        {
            BE.Usuario usuarioBuscado = null;

            List<BE.Usuario> recuperados = usuarioDAL.listar(username);

            if (!recuperados.IsNullOrEmpty())
            {
                usuarioBuscado = recuperados.First();
            }
            return usuarioBuscado;
        }

        //metodo que realiza la generacion del hash para el usuario
        private string ArmarHashUsuario(BE.Usuario usuario)
        {
            string cadena = usuario.USERNAME + usuario.CANT_INTENTOS.ToString() + usuario.ESTA_BLOQUEADO.ToString() +
                usuario.MAIL + usuario.PERSONA.DNI.ToString() + usuario.PERFIL.ID_TIPO.ToString();

            usuario.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return usuario.IDV;
        }

        private void ArmarHashGlobalUsuarios()
        {
            //buscamos la lista de todos los usuarios
            List<BE.Usuario> usuarios = listarUsuarios();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Usuario u in usuarios)
            {
                cadenaIDVs += u.IDV != null? u.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalUsuario = new BE.HASH_GLOBAL();
            idvGlobalUsuario.NOMBRE_TABLA = Enumerador.TablaIDV.USUARIO.ToString();
            idvGlobalUsuario.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalUsuario);
        }

        public string RecalcularHashGlobalUsuarios()
        {
            //buscamos la lista de todos los usuarios
            List<BE.Usuario> usuarios = listarUsuarios();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Usuario u in usuarios)
            {
                string idvRecalculado = ArmarHashUsuario(u);
                //MessageBox.Show(u.ToString()+" --> " + idvRecalculado);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }
            //MessageBox.Show("hash final: "+ Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs));
            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }
    }
}