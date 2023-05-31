using System;
using System.Collections.Generic;
using Microsoft.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    class Acceso
    {

        private SqlConnection conexion;

        //metodo que se encarga de abrir la conexion con la BD
        public Boolean abrir()
        {
            Boolean exitoso = false;

            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=MiEdificio; Integrated Security=True; MultipleActiveResultSets=True; Trust Server Certificate=True;";
            //conexion.ConnectionString = ConfigurationManager.ConnectionStrings["MiEdificio"].ConnectionString;

            try
            {
                if (conexion != null && conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                    exitoso = true;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                exitoso = false;
                cerrar();
            }
            return exitoso;
        }

        //metodo que se encarga de cerrar la conexion con la BD
        public void cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

       // metodo que crea el comando para ejecutar en la BD
        private SqlCommand crearComando(string Sql, List<SqlParameter> parametros = null,
            CommandType tipo = CommandType.StoredProcedure)
        {

            SqlCommand comando = new SqlCommand(Sql, conexion);
            comando.CommandType = tipo;

            if (parametros != null && parametros.Count > 0)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }

            return comando;
        }

        //metodo que modifica los datos en la BD, retorna la cantidad de registros afectados
        public int escribir(string Sql, List<SqlParameter> parametros = null)
        {

            int resultado = 0;

            SqlCommand cmd = crearComando(Sql, parametros);

            try
            {
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
                resultado = -1;
            }

            return resultado;
        }

        //metodo que lee en la BD y completa un dataTable
        public DataTable leer(string Sql, List<SqlParameter> parametros = null)
        {
            abrir();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = crearComando(Sql, parametros);
            DataTable tabla = new DataTable();
            ad.Fill(tabla);
            cerrar();
            return tabla;
        }

        //metodo que crea un parametro del tipo STRING
        public SqlParameter crearParametro(string nom, string valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.String;
            return par;
        }

        //metodo que crea un parametro del tipo INT32 entero corto
        public SqlParameter crearParametro(string nom, int valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Int32;
            return par;
        }

        //metodo que crea un parametro del tipo DATE
        public SqlParameter crearParametro(string nom, DateTime valor)
        {
            SqlParameter par = new SqlParameter(nom, valor.Date);
            par.DbType = DbType.Date;
            return par;
        }

        //metodo que crea un parametro del tipo INT64 entero largo
        public SqlParameter crearParametro(string nom, Int64 valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Int64;
            return par;
        }

        //metodo que crea un parametro del tipo BOOL para los flags
        public SqlParameter crearParametro(string nom, bool valor)
        {
            SqlParameter par = new SqlParameter(nom, valor);
            par.DbType = DbType.Boolean;
            return par;
        }

    }
}
