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

        public BE.Perfil ObtenerPermisos(BE.Perfil perfil)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@id", perfil.ID_TIPO));
                DataTable tabla = acceso.leer("LISTAR_PERMISOS_X_PERFIL", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.Permiso permiso = new BE.Permiso(
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

        public void ObtenerHijos(BE.Perfil perfil, BE.Permiso permisoPadre)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(acceso.crearParametro("@idPadre", permisoPadre.ID_TIPO));
                DataTable tabla = acceso.leer("LISTAR_HIJOS", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    BE.Permiso permiso = new BE.Permiso(
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


    }
}
