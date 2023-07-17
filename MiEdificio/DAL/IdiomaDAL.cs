using BE;
using Microsoft.Data.SqlClient;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAL
{
    public class IdiomaDAL
    {
        Acceso acceso = new Acceso();

        public IdiomaDAL() { }

        public List<ServiceIdioma> Listar()
        {
            List<ServiceIdioma> idiomas = new List<ServiceIdioma>();
            DataTable tabla = acceso.leer("LISTAR_IDIOMAS", null);
            foreach (DataRow registro in tabla.Rows)
            {
                ServiceIdioma idioma = new ServiceIdioma();
                idioma.ID = registro["id"].ToString();
                idioma.DESCRIPCION = registro["Descripcion"].ToString();
                idioma.ES_ESTANDAR = Boolean.Parse(registro["estandar"].ToString());
                idiomas.Add(idioma);
            }
            return idiomas;
        }

        public int InsertarOModificar(Services.ServiceIdioma nuevo)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", nuevo.ID));
            parametros.Add(acceso.crearParametro("@descripcion", nuevo.DESCRIPCION));
            parametros.Add(acceso.crearParametro("@es_estandar", nuevo.ES_ESTANDAR));

            if (existe(nuevo.ID))
            {
               modificados = acceso.escribir("EDITAR_IDIOMA", parametros);
            }
            else
            {
                modificados = acceso.escribir("INSERTAR_IDIOMA", parametros);
            }

            return modificados;
        }

        public Boolean existe(string idABuscar)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", idABuscar));
            DataTable tabla = acceso.leer("LISTAR_IDIOMA", parametros);
            return tabla.Rows.Count > 0;
        }

        public int Borrar(Services.ServiceIdioma nuevo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@id", nuevo.ID));
            return acceso.escribir("BORRAR_IDIOMA", parametros); ;
        }

        public List<ServiceTraduccion> ListarTraducciones(ServiceIdioma idioma)
        {
            List<ServiceTraduccion> traducciones = new List<ServiceTraduccion>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idIdioma", idioma.ID));

            DataTable tabla = acceso.leer("LISTAR_TRADUCCIONES", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                ServiceTraduccion t = new ServiceTraduccion();
                t.NOMBRE_OBJETO = registro["nombre_objeto"].ToString();
                t.TRADUCCION_TXT = registro["traduccion"].ToString();
                t.IDIOMA = idioma;

                traducciones.Add(t);
            }
            return traducciones;
        }

    }
}
