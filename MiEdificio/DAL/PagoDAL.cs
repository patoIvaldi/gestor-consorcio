using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PagoDAL
    {

        Acceso acceso = new Acceso();

        public PagoDAL()
        {

        }

        public List<BE.Pago> Listar(Int64 dni)
        {
            List<BE.Pago> pagos = new List<BE.Pago>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@dni", dni));

            DataTable tabla = acceso.leer("LISTAR_PAGOS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Pago p = new BE.Pago();
                p.ID = int.Parse(registro["id"].ToString());
                p.COD_SEGURIDAD = int.Parse(registro["codSeguridad"].ToString());
                p.FECHA_EJECUCION = DateTime.Parse(registro["fecha_ejecucion"].ToString());
                p.FECHA_VENC_TARJETA = DateTime.Parse(registro["fecha_vencTarjeta"].ToString());
                p.FORMA_PAGO = registro["forma_de_pago"].ToString();
                p.MONTO = float.Parse(registro["monto"].ToString());
                p.NOMBRE_TARJETA = registro["nombre_tarjeta"].ToString();
                p.IDV = registro["idv"].ToString();
                p.NRO_TARJETA = Int64.Parse(registro["nro_tarjeta"].ToString());

                pagos.Add(p);
            }
            return pagos;
        }

        public List<BE.Pago> ListarTodos()
        {
            List<BE.Pago> pagos = new List<BE.Pago>();

            DataTable tabla = acceso.leer("LISTAR_PAGOS_TODOS", null);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Pago p = new BE.Pago();
                p.ID = int.Parse(registro["id"].ToString());
                p.COD_SEGURIDAD = int.Parse(registro["codSeguridad"].ToString());
                p.FECHA_EJECUCION = DateTime.Parse(registro["fecha_ejecucion"].ToString());
                p.FECHA_VENC_TARJETA = DateTime.Parse(registro["fecha_vencTarjeta"].ToString());
                p.FORMA_PAGO = registro["forma_de_pago"].ToString();
                p.MONTO = float.Parse(registro["monto"].ToString());
                p.NOMBRE_TARJETA = registro["nombre_tarjeta"].ToString();
                p.IDV = registro["idv"].ToString();
                p.NRO_TARJETA = Int64.Parse(registro["nro_tarjeta"].ToString());

                pagos.Add(p);
            }
            return pagos;
        }

        public int Generar(BE.Pago newPago)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@codSeguridad", newPago.COD_SEGURIDAD));
            parametros.Add(acceso.crearParametro("@fecha_ejecucion", newPago.FECHA_EJECUCION));
            parametros.Add(acceso.crearParametro("@fecha_vencTarjeta", newPago.FECHA_VENC_TARJETA));
            parametros.Add(acceso.crearParametro("@forma_de_pago", newPago.FORMA_PAGO));
            parametros.Add(acceso.crearParametro("@monto", newPago.MONTO));
            parametros.Add(acceso.crearParametro("@nombre_tarjeta", newPago.NOMBRE_TARJETA));
            parametros.Add(acceso.crearParametro("@nro_tarjeta", newPago.NRO_TARJETA));
            parametros.Add(acceso.crearParametro("@dni", newPago.DNI));
            parametros.Add(acceso.crearParametro("@idv", newPago.IDV));

            modificados = acceso.escribir("INSERTAR_PAGO", parametros);

            return modificados;
        }

        public BE.Pago BuscarPagoPorFechaYDNI(DateTime fechaEjec, Int64 dni)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@dni", dni));
            parametros.Add(acceso.crearParametro("@fecha_ejecucion", fechaEjec));

            DataTable tabla = acceso.leer("BUSCAR_PAGO", parametros);
            BE.Pago p = null;
            foreach (DataRow registro in tabla.Rows)
            {
                p = new BE.Pago();
                p.ID = int.Parse(registro["id"].ToString());
                p.COD_SEGURIDAD = int.Parse(registro["codSeguridad"].ToString());
                p.FECHA_EJECUCION = DateTime.Parse(registro["fecha_ejecucion"].ToString());
                p.FECHA_VENC_TARJETA = DateTime.Parse(registro["fecha_vencTarjeta"].ToString());
                p.FORMA_PAGO = registro["forma_de_pago"].ToString();
                p.MONTO = float.Parse(registro["monto"].ToString());
                p.NOMBRE_TARJETA = registro["nombre_tarjeta"].ToString();
                p.IDV = registro["idv"].ToString();
                p.NRO_TARJETA = Int64.Parse(registro["nro_tarjeta"].ToString());
            }
            return p;
        }

        public Boolean ActualizarIDVPago(BE.Pago pago, string idv)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idv", idv));
            parametros.Add(acceso.crearParametro("@idPago", pago.ID));
            int modificados = acceso.escribir("ACTUALIZAR_IDV_PAGO", parametros);

            return modificados != 0 ? true : false;
        }

    }
}
