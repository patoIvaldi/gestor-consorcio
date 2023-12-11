using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PagoBLL
    {

        DAL.PagoDAL pagoDAL = new DAL.PagoDAL();
        DAL.ExpensaDAL expensaDAL = new DAL.ExpensaDAL();

        public PagoBLL() { }

        private static PagoBLL _instance;

        //singleton para la instancia del pago
        public static PagoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PagoBLL();
                }
                return _instance;
            }
        }

        //busca todos los pagos en base a un dni
        public List<BE.Pago> ListarPagos(Int64 dni)
        {
            return pagoDAL.Listar(dni);
        }

        public List<BE.Pago> ListarPagos()
        {
            return pagoDAL.ListarTodos();
        }

        //generamos el pago y saldamos las expensas
        public Boolean GenerarPago(BE.Pago newPago, List<BE.Expensa> expensasASaldar)
        {
            Boolean exitoso = false;

            ArmarHashPago(newPago);
            exitoso = pagoDAL.Generar(newPago) > 0;
            ArmarHashGlobalPago();

            //si pudimos generar el pago
            if (exitoso)
            {
                //recupero el id del pago generado
                BE.Pago creado = pagoDAL.BuscarPagoPorFechaYDNI(
                    newPago.FECHA_EJECUCION, newPago.DNI);

                //por cada expensa, la saldo
                foreach (BE.Expensa e in expensasASaldar)
                {
                    exitoso = expensaDAL.SaldarExpensa(e.ID,creado.ID) > 0;
                    ExpensaBLL.Instance.ArmarHashExpensa(e);
                    expensaDAL.ActualizarIDVExpensa(e, e.IDV);
                    ExpensaBLL.Instance.ArmarHashGlobalExpensa();
                }
            }

            return exitoso;
        }

        //metodo que realiza la generacion del hash para el pago
        private string ArmarHashPago(BE.Pago pago)
        {
            string cadena = pago.COD_SEGURIDAD.ToString() + pago.FECHA_EJECUCION.ToString() + pago.FECHA_VENC_TARJETA.ToString()
                + pago.FORMA_PAGO + pago.MONTO.ToString() + pago.NOMBRE_TARJETA!=null? pago.NOMBRE_TARJETA:"" + pago.NRO_TARJETA.ToString() + pago.DNI.ToString();

            pago.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return pago.IDV;
        }

        private void ArmarHashGlobalPago()
        {
            //buscamos la lista de todos los pagos
            List<BE.Pago> pagos = ListarPagos();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Pago p in pagos)
            {
                cadenaIDVs += p.IDV != null ? p.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalPagos = new BE.HASH_GLOBAL();
            idvGlobalPagos.NOMBRE_TABLA = Enumerador.TablaIDV.PAGO.ToString();
            idvGlobalPagos.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalPagos);
        }

        public string RecalcularHashGlobalPagos()
        {
            //buscamos la lista de todos los pagos
            List<BE.Pago> pagos = ListarPagos();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Pago p in pagos)
            {
                string idvRecalculado = ArmarHashPago(p);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            //buscamos la lista de todos los pagos
            List<BE.Pago> pagos = ListarPagos();
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Pago p in pagos)
            {
                //recalculamos el hash para cada pago
                string nuevoHashPago = ArmarHashPago(p);

                //persistimos el nuevo hash en la tabla de pago
                pagoDAL.ActualizarIDVPago(p, nuevoHashPago);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashPago != null ? nuevoHashPago : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalPago = new BE.HASH_GLOBAL();
            idvGlobalPago.NOMBRE_TABLA = Enumerador.TablaIDV.PAGO.ToString();
            idvGlobalPago.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalPago);
        }

    }
}
