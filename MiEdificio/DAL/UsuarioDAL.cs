using BE;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {

        Acceso acceso = new Acceso();

        public BE.Usuario ValidateUser(BE.Usuario userIni, ServiceIdioma idiomaElegido)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@Username", userIni.USERNAME.Trim()));
            parametros.Add(acceso.crearParametro("@Password", userIni.CONTRASENIA.Trim()));
            DataTable tabla = acceso.leer("VALIDAR_CREDENCIAL_USUARIO", parametros);
            PerfilDAL gestorperfil = new PerfilDAL();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.Perfil perfil = new BE.Perfil(registro["descripcion"].ToString());
                    perfil.ID_TIPO = int.Parse(registro["id_rol"].ToString());
                    userIni.PERFIL = perfil;

                    Services.ServiceSesion.Instance.IdiomaSeleccionado = idiomaElegido;

                    //cargo la info del usuario
                    userIni.USERNAME = registro["username"].ToString().Trim();
                    userIni.ESTA_BLOQUEADO = bool.Parse(registro["esta_bloqueado"].ToString());
                    userIni.MAIL = registro["mail"].ToString();
                    userIni.IDV = registro["idv"].ToString();

                    //cargo el tipo de persona que es en base al perfil del usuario
                    if (userIni.PERFIL.DESCRIPCION.Trim().Equals("Adm. de Consorcio".Trim()))
                    {
                        BE.AdministradorConsorcio adm = new BE.AdministradorConsorcio();
                        adm.NOMBRE_EMPRESA = registro["nombre_empresa"].ToString();
                        adm.CUIT = registro["cuit"].ToString();
                        adm.RAZON_SOCIAL = registro["razon_social"].ToString();

                        if (!string.IsNullOrEmpty(registro["fecha_inicio_concesion"].ToString()))
                        {
                            adm.FECHA_INICIO_CONCESION = DateTime.Parse(
                                registro["fecha_inicio_concesion"].ToString());
                        }

                        if (!string.IsNullOrEmpty(registro["fecha_fin_concesion"].ToString()))
                        {
                            adm.FECHA_FIN_CONCESION = DateTime.Parse(
                                registro["fecha_fin_concesion"].ToString());
                        }

                        userIni.PERSONA = adm;
                    }
                    else
                    {
                        BE.Propietario prop = new BE.Propietario();
                        prop.NRO_DEPARTAMENTO = registro["nro_departamento"].ToString();
                        prop.NRO_TELEFONO = Int64.Parse(registro["telefono"].ToString());

                        userIni.PERSONA = prop;
                    }

                    //informacion general de la persona
                    userIni.PERSONA.NOMBRE = registro["nombre"].ToString();
                    userIni.PERSONA.APELLIDO = registro["apellido"].ToString();
                    userIni.PERSONA.DNI = Int64.Parse(registro["dni"].ToString());

                    if (!string.IsNullOrEmpty(registro["fecha_nacimiento"].ToString()))
                    {
                        userIni.PERSONA.FECHA_NACIMIENTO = DateTime.Parse(
                            registro["fecha_nacimiento"].ToString());
                    }

                    if (!string.IsNullOrEmpty(registro["fecha_alta"].ToString()))
                    {
                        userIni.FECHA_ALTA = DateTime.Parse(
                            registro["fecha_alta"].ToString());
                    }
                }
            }
            else
            {
                userIni = null;
            }

            return userIni;
        }

        public Boolean desbloquearUsuario(string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@Username", username.Trim()));
            int modificados = acceso.escribir("DESBLOQUEAR_USUARIO", parametros);

            return modificados != 0 ? true: false;
        }

        public List<BE.Usuario> listar(string username)
        {
            DataTable tabla = null;

            if (!string.IsNullOrEmpty(username))
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@Username", username.Trim()));
                tabla = acceso.leer("LISTAR_USUARIO", parametros);
            }
            else
            {
                tabla = acceso.leer("LISTAR_USUARIOS", null);
            }

            List<BE.Usuario> usuarios = new List<BE.Usuario>();
            PerfilDAL gestorPerfil = new PerfilDAL();
            IdiomaDAL gestorIdioma = new IdiomaDAL();
            foreach (DataRow registro in tabla.Rows)
            {
                //cargo la info del usuario
                BE.Usuario user = new BE.Usuario();
                user.USERNAME = registro["username"].ToString().Trim();
                user.ESTA_BLOQUEADO = bool.Parse(registro["esta_bloqueado"].ToString());
                user.MAIL = registro["mail"].ToString();
                user.CONTRASENIA = registro["Contraseña"].ToString();
                user.IDV = registro["idv"].ToString();
                user.CANT_INTENTOS = int.Parse(registro["cant_intentos"].ToString());

                //cargo el perfil y los permisos
                user.PERFIL = gestorPerfil.ObtenerPerfilUsuario(user);

                //cargo el tipo de persona que es en base al perfil del usuario
                if (user.PERFIL.DESCRIPCION.Trim().Equals("Adm. de Consorcio".Trim()))
                {
                    BE.AdministradorConsorcio adm = new BE.AdministradorConsorcio();
                    adm.NOMBRE_EMPRESA = registro["nombre_empresa"].ToString();
                    adm.CUIT = registro["cuit"].ToString();
                    adm.RAZON_SOCIAL = registro["razon_social"].ToString();

                    if (!string.IsNullOrEmpty(registro["fecha_inicio_concesion"].ToString()))
                    {
                        adm.FECHA_INICIO_CONCESION = DateTime.Parse(
                            registro["fecha_inicio_concesion"].ToString());
                    }

                    if (!string.IsNullOrEmpty(registro["fecha_fin_concesion"].ToString()))
                    {
                        adm.FECHA_FIN_CONCESION = DateTime.Parse(
                            registro["fecha_fin_concesion"].ToString());
                    }

                    user.PERSONA = adm;
                }
                else
                {
                    BE.Propietario prop = new BE.Propietario();
                    if (!string.IsNullOrEmpty(registro["nro_departamento"].ToString())){prop.NRO_DEPARTAMENTO = registro["nro_departamento"].ToString();}
                    if (!string.IsNullOrEmpty(registro["telefono"].ToString())) { prop.NRO_TELEFONO = Int64.Parse(registro["telefono"].ToString());}

                    user.PERSONA = prop;
                }

                //informacion general de la persona
                user.PERSONA.NOMBRE = registro["nombre"].ToString();
                user.PERSONA.APELLIDO = registro["apellido"].ToString();
                user.PERSONA.DNI = Int64.Parse(registro["dni"].ToString());

                if (!string.IsNullOrEmpty(registro["fecha_nacimiento"].ToString()))
                {
                    user.PERSONA.FECHA_NACIMIENTO = DateTime.Parse(
                        registro["fecha_nacimiento"].ToString());
                }

                if (!string.IsNullOrEmpty(registro["fecha_alta"].ToString()))
                {
                    user.FECHA_ALTA = DateTime.Parse(
                        registro["fecha_alta"].ToString());
                }

                usuarios.Add(user);
            }
            return usuarios;
        }

        //metodo que edita la informacion de un usuario
        public int Editar(BE.Usuario u)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@username", u.USERNAME.Trim()));
            parametros.Add(acceso.crearParametro("@nombre", u.PERSONA.NOMBRE.Trim()));
            parametros.Add(acceso.crearParametro("@apellido", u.PERSONA.APELLIDO.Trim()));
            parametros.Add(acceso.crearParametro("@password", !string.IsNullOrEmpty(u.CONTRASENIA)?u.CONTRASENIA:null));
            parametros.Add(acceso.crearParametro("@mail", u.MAIL));
            parametros.Add(acceso.crearParametro("@establoqueado", u.ESTA_BLOQUEADO));
            parametros.Add(acceso.crearParametro("@dni", u.PERSONA.DNI));
            parametros.Add(acceso.crearParametro("@fechanac", u.PERSONA.FECHA_NACIMIENTO));
            parametros.Add(acceso.crearParametro("@rol", u.PERFIL.ID_TIPO));
            parametros.Add(acceso.crearParametro("@idv", u.IDV));
            if (u.PERSONA is BE.Propietario)
            {
                parametros.Add(acceso.crearParametro("@nrodepto", ((BE.Propietario)u.PERSONA).NRO_DEPARTAMENTO));
                parametros.Add(acceso.crearParametro("@telefono", ((BE.Propietario)u.PERSONA).NRO_TELEFONO));

            }
            else
            {
                parametros.Add(acceso.crearParametro("@fechainicon", ((BE.AdministradorConsorcio)u.PERSONA).FECHA_INICIO_CONCESION));
                parametros.Add(acceso.crearParametro("@fechafincon", ((BE.AdministradorConsorcio)u.PERSONA).FECHA_FIN_CONCESION));
                parametros.Add(acceso.crearParametro("@empresa", ((BE.AdministradorConsorcio)u.PERSONA).NOMBRE_EMPRESA));
                parametros.Add(acceso.crearParametro("@razonsocial", ((BE.AdministradorConsorcio)u.PERSONA).RAZON_SOCIAL));
                parametros.Add(acceso.crearParametro("@cuit", ((BE.AdministradorConsorcio)u.PERSONA).CUIT));
            }
                return acceso.escribir("EDITAR_USUARIO", parametros);
        }

        public int Insertar(BE.Usuario u)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@username", u.USERNAME.Trim()));
            parametros.Add(acceso.crearParametro("@nombre", u.PERSONA.NOMBRE.Trim()));
            parametros.Add(acceso.crearParametro("@apellido", u.PERSONA.APELLIDO.Trim()));
            parametros.Add(acceso.crearParametro("@password", u.CONTRASENIA));
            parametros.Add(acceso.crearParametro("@mail", u.MAIL));
            parametros.Add(acceso.crearParametro("@establoqueado", u.ESTA_BLOQUEADO));
            parametros.Add(acceso.crearParametro("@dni", u.PERSONA.DNI));
            parametros.Add(acceso.crearParametro("@fechanac",u.PERSONA.FECHA_NACIMIENTO));
            parametros.Add(acceso.crearParametro("@rol",u.PERFIL.ID_TIPO));
            parametros.Add(acceso.crearParametro("@idv",u.IDV));

            if (u.PERSONA is BE.Propietario)
            {
                parametros.Add(acceso.crearParametro("@nrodepto", ((BE.Propietario)u.PERSONA).NRO_DEPARTAMENTO));
                parametros.Add(acceso.crearParametro("@telefono", ((BE.Propietario)u.PERSONA).NRO_TELEFONO));

            }
            else
            {
                parametros.Add(acceso.crearParametro("@cuit", ((BE.AdministradorConsorcio)u.PERSONA).CUIT));
                parametros.Add(acceso.crearParametro("@fechainicon", ((BE.AdministradorConsorcio)u.PERSONA).FECHA_INICIO_CONCESION));
                parametros.Add(acceso.crearParametro("@fechafincon", ((BE.AdministradorConsorcio)u.PERSONA).FECHA_FIN_CONCESION));
                parametros.Add(acceso.crearParametro("@empresa", ((BE.AdministradorConsorcio)u.PERSONA).NOMBRE_EMPRESA));
                parametros.Add(acceso.crearParametro("@razonsocial", ((BE.AdministradorConsorcio)u.PERSONA).RAZON_SOCIAL));
            }
            return acceso.escribir("INSERTAR_USUARIO", parametros);
        }

        public Boolean sumarIntentoErroneo(string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@Username", username.Trim()));
            int modificados = acceso.escribir("SUMAR_INTENTO", parametros);

            return modificados != 0 ? true : false;
        }

        //cambia el tipo de perfil del usuario en cuestion
        public Boolean CambiarPerfilUsuario(BE.Usuario usu, BE.Perfil perf)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@username", usu.USERNAME));
            parametros.Add(acceso.crearParametro("@idRol", perf.ID_TIPO));
            int modificados = acceso.escribir("CAMBIAR_PERFIL_USUARIO", parametros);

            return modificados != 0 ? true : false;
        }

        public Boolean ActualizarIDVUsuario(BE.Usuario usu, string idv)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idv", idv));
            parametros.Add(acceso.crearParametro("@usuario", usu.USERNAME));
            int modificados = acceso.escribir("ACTUALIZAR_IDV_USUARIO", parametros);

            return modificados != 0 ? true : false;
        }

    }
}
