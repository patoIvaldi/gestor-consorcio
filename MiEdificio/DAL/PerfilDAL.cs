using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PerfilDAL
    {
        Acceso acceso = new Acceso();

        //Metodo que obtiene todos los permisos del perfil
        public BE.Perfil ObtenerPermisos(BE.Perfil perfil)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@id", perfil.ID_TIPO));
                DataTable tabla = acceso.leer("LISTAR_PERMISOS_X_PERFIL", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.PermisoSimple permiso = new BE.PermisoSimple(
                        registro["nombre"].ToString(),
                        registro["descripcion"].ToString());

                    permiso.ID_TIPO = int.Parse(registro["id_permiso"].ToString());

                    if (registro["nombre"] != DBNull.Value)
                    {
                        perfil.agregarPermiso(permiso);
                    }
                    else
                    {
                        this.ObtenerHijos(perfil, permiso);
                    }
                }
            }
            catch (Exception ex)
            { 
                
            }
            return perfil;
        }

        public void ObtenerHijos(BE.Perfil perfil, BE.PermisoSimple permisoPadre)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@idPadre", permisoPadre.ID_TIPO));
                DataTable tabla = acceso.leer("LISTAR_HIJOS", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.PermisoSimple permiso = new BE.PermisoSimple(
                        registro["nombre"].ToString(),
                        registro["descripcion"].ToString());

                    permiso.ID_TIPO = int.Parse(registro["id_permiso_hijo"].ToString());

                    if (registro["nombre"] != DBNull.Value)
                    {
                        perfil.agregarPermiso(permiso);
                    }
                    else
                    {
                        this.ObtenerHijos(perfil, permiso);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //Metodo que obtiene el perfil del usuario
        public BE.Perfil ObtenerPerfilUsuario(BE.Usuario u)
        {
            BE.Perfil p = new BE.Perfil();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@username", u.USERNAME));
            DataTable tabla = acceso.leer("OBTENER_PERFIL_USUARIO", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                p.ID_TIPO = int.Parse(registro["id_rol"].ToString());
                p.DESCRIPCION = registro["Descripcion"].ToString();
            }
            
            return ObtenerPermisos(p);
        }

        //busco todos los perfiles alojados en la BD
        public List<BE.Perfil> ObtenerPerfiles()
        {
            List<BE.Perfil> perfiles = new List<BE.Perfil>();
            DataTable tabla = acceso.leer("LISTAR_PERFILES", null);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Perfil p = new BE.Perfil();
                p.ID_TIPO = int.Parse(registro["id_rol"].ToString());
                p.DESCRIPCION = registro["Descripcion"].ToString();
                perfiles.Add(p);
            }

            return perfiles;
        }

        public int InsertarOModificar(BE.Perfil newPerfil)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@descripcion", newPerfil.DESCRIPCION));

            if (newPerfil.ID_TIPO != 0 && existe(newPerfil.ID_TIPO.ToString()))
            {
                parametros.Add(acceso.crearParametro("@id", newPerfil.ID_TIPO));
                modificados = acceso.escribir("EDITAR_PERFIL", parametros);
            }
            else
            {
                modificados = acceso.escribir("INSERTAR_PERFIL", parametros);
            }

            return modificados;
        }

        public Boolean existe(string idABuscar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", idABuscar));
            DataTable tabla = acceso.leer("LISTAR_PERFIL", parametros);
            return tabla.Rows.Count > 0;
        }

        public int Borrar(BE.Perfil perfilABorrar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", perfilABorrar.ID_TIPO));
            return acceso.escribir("BORRAR_PERFIL", parametros); ;
        }

    }
}
