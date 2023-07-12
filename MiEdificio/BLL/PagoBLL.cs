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

        //generamos el pago y saldamos las expensas
        public Boolean GenerarPago(BE.Pago newPago, List<BE.Expensa> expensasASaldar)
        {
            Boolean exitoso = false;

            exitoso = pagoDAL.Generar(newPago) > 0;

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
                }
            }

            return exitoso;
        }

    }
}
