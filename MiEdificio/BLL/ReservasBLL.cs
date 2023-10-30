﻿using DAL;
using System;
using System.Collections.Generic;
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
            return reservaDAL.AgregarReserva(reserva) > 0 ? true : false;
        }


    }
}
