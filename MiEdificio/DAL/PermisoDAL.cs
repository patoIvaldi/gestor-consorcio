using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermisoDAL
    {

        Acceso acceso = new Acceso();

        //obtiene todos los permisos en la BD
        public List<BE.PermisoSimple> ObtenerPermisosConfigurados()
        {
            List<BE.PermisoSimple> permisos = new List<BE.PermisoSimple>();
            DataTable tabla = acceso.leer("LISTAR_PERMISOS_SIMPLES", null);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.PermisoSimple ps = new BE.PermisoSimple(
                    registro["nombre"].ToString(), registro["Descripcion"].ToString());
                ps.ID_TIPO = int.Parse(registro["id_permiso"].ToString());
                permisos.Add(ps);
            }

            return permisos;
        }

        public List<BE.PermisoSimple> ObtenerPermisosHijos(BE.PermisoSimple perMaestro)
        {
            List<BE.PermisoSimple> permisos = new List<BE.PermisoSimple>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idPadre", perMaestro.ID_TIPO));

            DataTable tabla = acceso.leer("LISTAR_HIJOS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.PermisoSimple ps = new BE.PermisoSimple(
                    registro["nombre"].ToString(), registro["Descripcion"].ToString());
                ps.ID_TIPO = int.Parse(registro["Id_permiso_hijo"].ToString());
                permisos.Add(ps);
            }

            return permisos;
        }

        public List<BE.PermisoSimple> ObtenerListaPermisos(BE.Perfil perfil)
        {
            List<BE.PermisoSimple> permisos = new List<BE.PermisoSimple>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", perfil.ID_TIPO));

            DataTable tabla = acceso.leer("LISTAR_PERMISOS_X_PERFIL", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.PermisoSimple permiso = new BE.PermisoSimple(
                    registro["nombre"].ToString(),
                    registro["descripcion"].ToString());

                permiso.ID_TIPO = int.Parse(registro["id_permiso"].ToString());
                permisos.Add(permiso);
            }
            return permisos;
        }

        public int InsertarOModificar(BE.PermisoSimple newPermiso)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@descripcion", newPermiso.DESCRIPCION));
            parametros.Add(acceso.crearParametro("@nombre", newPermiso.NOMBRE));

            if (newPermiso.ID_TIPO != 0 && existe(newPermiso.ID_TIPO.ToString()))
            {
                parametros.Add(acceso.crearParametro("@id", newPermiso.ID_TIPO));
                modificados = acceso.escribir("EDITAR_PERMISO", parametros);
            }
            else
            {
                modificados = acceso.escribir("INSERTAR_PERMISO", parametros);
            }

            return modificados;
        }

        public Boolean existe(string idABuscar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", idABuscar));
            DataTable tabla = acceso.leer("LISTAR_PERMISO", parametros);
            return tabla.Rows.Count > 0;
        }

        public int Borrar(BE.PermisoSimple permisoABorrar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", permisoABorrar.ID_TIPO));
            return acceso.escribir("BORRAR_PERMISO", parametros); ;
        }

        public Boolean existePermisoPerfil(int idPerfil, int idPermiso)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idRol", idPerfil));
            parametros.Add(acceso.crearParametro("@idPermiso", idPermiso));
            DataTable tabla = acceso.leer("EXISTE_PERMISO_PERFIL", parametros);
            return tabla.Rows.Count > 0;
        }

        public int AsociarPermisoPerfil(int idPerfil,int idPermiso)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idRol", idPerfil));
            parametros.Add(acceso.crearParametro("@idPermiso", idPermiso));

            modificados = acceso.escribir("ASOCIAR_PERMISO_PERFIL", parametros);

            return modificados;
        }

        public int DesasociarPermisoPerfil(int idPerfil, int idPermiso)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idRol", idPerfil));
            parametros.Add(acceso.crearParametro("@idPermiso", idPermiso));

            modificados = acceso.escribir("DESASOCIAR_PERMISO_PERFIL", parametros);

            return modificados;
        }

        public int AsociarPermisoPermiso(int idPermisoPadre, int idPermisoHijo)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idPermisoPadre", idPermisoPadre));
            parametros.Add(acceso.crearParametro("@idPermisoHijo", idPermisoHijo));

            modificados = acceso.escribir("ASOCIAR_PERMISO_PERMISO", parametros);

            return modificados;
        }

        public Boolean existePermisoPermiso(int idPermisoPadre, int idPermisoHijo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idPermisoPadre", idPermisoPadre));
            parametros.Add(acceso.crearParametro("@idPermisoHijo", idPermisoHijo));
            DataTable tabla = acceso.leer("EXISTE_PERMISO_PERMISO", parametros);
            return tabla.Rows.Count > 0;
        }

    }
}
