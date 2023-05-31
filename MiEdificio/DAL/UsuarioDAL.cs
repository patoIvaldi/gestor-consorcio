using Microsoft.Data.SqlClient;
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

        public BE.Usuario ValidateUser(BE.Usuario userIni)
        {
            
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@Username", userIni.USERNAME));
            parametros.Add(acceso.crearParametro("@Password", userIni.CONTRASENIA));
            DataTable tabla = acceso.leer("VALIDAR_CREDENCIAL_USUARIO", parametros);
            PerfilDAL gestorperfil = new PerfilDAL();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.Perfil perfil = new BE.Perfil(registro["descripcion"].ToString());
                    perfil.ID_TIPO = int.Parse(registro["id_rol"].ToString());

                    if (perfil.DESCRIPCION.Trim().Equals("Adm. de Consorcio".Trim()))
                    {
                        userIni.PERSONA = new BE.AdministradorConsorcio();
                    }
                    else
                    {
                        userIni.PERSONA = new BE.Propietario();
                    }
                    userIni.USERNAME = registro["username"].ToString();
                    //Services.Serv_Idioma idioma = new Servicios.Serv_Idioma();
                    //idioma.ID_Idioma = int.Parse(registro["id_idioma"].ToString());
                    //idioma.Descripcion = registro["DescripcionIdioma"].ToString();
                    //Servicios.Serv_Sesion.Instance.IdiomaSeleccionado = idioma;
                    userIni.PERSONA.NOMBRE = registro["nombre"].ToString();
                    userIni.PERSONA.APELLIDO = registro["apellido"].ToString();
                    userIni.PERFIL = perfil;
                }
            }
            else
            {
                userIni = null;
            }

            return userIni;
        }




    }
}
