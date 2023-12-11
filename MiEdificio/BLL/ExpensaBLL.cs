using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExpensaBLL
    {
        DAL.ExpensaDAL expensaDAL = new DAL.ExpensaDAL();
        DAL.SegmentoDAL segmentoDAL = new DAL.SegmentoDAL();

        public ExpensaBLL() { }

        private static ExpensaBLL _instance;

        //singleton para la instancia de la expensa
        public static ExpensaBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpensaBLL();
                }
                return _instance;
            }
        }

        //busca todas las expensas en base a un dni
        public List<BE.Expensa> ListarExpensas(Int64 dni)
        {
            return expensaDAL.Listar(dni);
        }

        public List<BE.Expensa> ListarExpensas()
        {
            return expensaDAL.ListarTodas();
        }

        //hace el dto de la expensa creada
        public Boolean GenerarExpensa(BE.Expensa exp)
        {
            ArmarHashExpensa(exp);
            Boolean exitoso = expensaDAL.Generar(exp) > 0;

            BE.Expensa generada = expensaDAL.BuscarPorPeriodoYDNI(exp.DNI,exp.PERIODO);

            if(generada is not null)
            {
                exp.ID = generada.ID;

                //generamos el idv para cada segmento
                foreach (BE.Segmento s in exp.SEGMENTOS)
                {
                    BLL.SegmentoBLL.Instance.ArmarHashSegmento(s);
                }

                exitoso = segmentoDAL.Generar(exp) > 0;
            }

            ArmarHashGlobalExpensa();
            BLL.SegmentoBLL.Instance.ArmarHashGlobalSegmento();

            return exitoso;
        }

        //metodo que busca si existe una expensa para el cliente y el periodo en cuestion
        public Boolean ExisteExpensaParaElPeriodo(BE.Expensa exp)
        {
            return expensaDAL.BuscarPorPeriodoYDNI(exp.DNI, exp.PERIODO) is not null;
        }

        //metodo que busca todas las expensas asociadas a un pago
        public List<BE.Expensa> BuscarPorIdPago(int idPago)
        {
            return expensaDAL.BuscarPorIdPago(idPago);
        }

        //recupero la recaudacion total de cada periodo
        public DataTable BuscarRecaudacionPorPeriodo(Boolean ordenDescendente)
        {
            return expensaDAL.RecaudacionPorPeriodo(ordenDescendente);
        }

        //metodo que realiza la generacion del hash para la expensa
        public string ArmarHashExpensa(BE.Expensa expensa)
        {
            string cadena = expensa.FECHA_EMISION.ToString() + expensa.MONTO.ToString() + expensa.ESTA_PAGA.ToString()
                + expensa.DTTM_1ER_VENCIMIENTO.ToString() + expensa.DTTM_2DO_VENCIMIENTO.ToString();

            expensa.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return expensa.IDV;
        }

        public void ArmarHashGlobalExpensa()
        {
            //buscamos la lista de todas las expensas
            List<BE.Expensa> expensas = ListarExpensas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Expensa e in expensas)
            {
                cadenaIDVs += e.IDV != null ? e.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalExpensa = new BE.HASH_GLOBAL();
            idvGlobalExpensa.NOMBRE_TABLA = Enumerador.TablaIDV.EXPENSA.ToString();
            idvGlobalExpensa.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalExpensa);
        }

        public string RecalcularHashGlobalExpensas()
        {
            //buscamos la lista de todas las expensas
            List<BE.Expensa> expensas = ListarExpensas();
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Expensa e in expensas)
            {
                string idvRecalculado = ArmarHashExpensa(e);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            //buscamos la lista de todas las expensas
            List<BE.Expensa> expensas = ListarExpensas();
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Expensa e in expensas)
            {
                //recalculamos el hash para cada expensa
                string nuevoHashExpensa = ArmarHashExpensa(e);

                //persistimos el nuevo hash en la tabla expensa
                expensaDAL.ActualizarIDVExpensa(e, nuevoHashExpensa);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashExpensa != null ? nuevoHashExpensa : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalExpensa = new BE.HASH_GLOBAL();
            idvGlobalExpensa.NOMBRE_TABLA = Enumerador.TablaIDV.EXPENSA.ToString();
            idvGlobalExpensa.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalExpensa);
        }
    }
}
