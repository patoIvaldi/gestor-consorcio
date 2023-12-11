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
    public class ReservasBLL
    {

        DAL.ReservaDAL reservaDAL = new DAL.ReservaDAL();

        public ReservasBLL() { }

        private static ReservasBLL _instance;

        //singleton para la instancia de la reserva
        public static ReservasBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReservasBLL();
                }
                return _instance;
            }
        }

        //busca las reservas registradas en sistema
        //puede indicar por parametro la cantidad de registros que quiera retornar
        public List<BE.Reserva> ListarReservas(int cantRegistros = 0)
        {
            return reservaDAL.Listar(cantRegistros);
        }

        //metodo que agrega una reserva
        public Boolean AgregarReserva(BE.Reserva reserva)
        {
            Boolean modificadoOK = false;
            int registro = reservaDAL.AgregarReserva(reserva);

            if (registro > 0)
            {
                ArmarHashReserva(reserva);
                ArmarHashGlobalReserva();
                modificadoOK = true;
            }

            return modificadoOK;
        }

        //metodo que actualiza una reserva existente
        public Boolean ModificarReserva(BE.Reserva reserva, BE.ReservaControlCambios versionElegida, Boolean esRollback)
        {
            Boolean modificadoOK = false;
            int registro = reservaDAL.ModificarReserva(reserva, versionElegida, esRollback);

            if (registro > 0)
            {
                ArmarHashReserva(reserva);
                ArmarHashGlobalReserva();
                modificadoOK = true;
            }

            return modificadoOK;
        }

        //validamos la disponibilidad en base a las reglas de negocio establecidas:
        //el usuario no debe tener una reserva pendiente para ese area comun
        //ni tampoco que el area en comun ya este ocupada
        public Boolean ValidarDisponibilidad(BE.Reserva reserva)
        {
            return reservaDAL.ValidarDisponibilidad(reserva);
        }

        public DataTable BuscarCantidadReservas(Boolean ordenDescendente)
        {
            return reservaDAL.CantidadReservas(ordenDescendente);
        }

        //metodo que realiza la generacion del hash para la reserva
        private string ArmarHashReserva(BE.Reserva reserva)
        {
            string cadena = reserva.ESTADO + reserva.FECHA_CREACION.ToString() + reserva.AREA + reserva.FECHA_RESERVA_INICIO.ToString()
                + reserva.FECHA_RESERVA_FIN.ToString() + reserva.USUARIO_AUTOR.USERNAME + reserva.FEEDBACK != null ? reserva.FEEDBACK : "";

            reserva.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return reserva.IDV;
        }

        private void ArmarHashGlobalReserva()
        {
            //buscamos la lista de todas las reservas
            List<BE.Reserva> reservas = ListarReservas(0);
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Reserva r in reservas)
            {
                cadenaIDVs += r.IDV != null ? r.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalReserva = new BE.HASH_GLOBAL();
            idvGlobalReserva.NOMBRE_TABLA = Enumerador.TablaIDV.RESERVA.ToString();
            idvGlobalReserva.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalReserva);
        }

        public string RecalcularHashGlobalReservas()
        {
            //buscamos la lista de todas las reservas
            List<BE.Reserva> reservas = ListarReservas(0);
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Reserva r in reservas)
            {
                string idvRecalculado = ArmarHashReserva(r);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            //buscamos la lista de todas las reservas
            List<BE.Reserva> reservas = ListarReservas(0);
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Reserva r in reservas)
            {
                //recalculamos el hash para cada reserva
                string nuevoHashReserva = ArmarHashReserva(r);

                //persistimos el nuevo hash en la tabla de reservas
                reservaDAL.ActualizarIDVReserva(r, nuevoHashReserva);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashReserva != null ? nuevoHashReserva : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalReserva = new BE.HASH_GLOBAL();
            idvGlobalReserva.NOMBRE_TABLA = Enumerador.TablaIDV.RESERVA.ToString();
            idvGlobalReserva.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalReserva);
        }

    }
}
