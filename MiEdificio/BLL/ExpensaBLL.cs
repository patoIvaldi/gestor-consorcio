﻿using DAL;
using System;
using System.Collections.Generic;
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

        //hace el dto de la expensa creada
        public Boolean GenerarExpensa(BE.Expensa exp)
        {
            Boolean exitoso = expensaDAL.Generar(exp) > 0;

            BE.Expensa generada = expensaDAL.BuscarPorPeriodoYDNI(exp.DNI,exp.PERIODO);

            if(generada is not null)
            {
                exp.ID = generada.ID;
                exitoso = segmentoDAL.Generar(exp) > 0;
            }

            return exitoso;
        }

        public Boolean ExisteExpensaParaElPeriodo(BE.Expensa exp)
        {
            return expensaDAL.BuscarPorPeriodoYDNI(exp.DNI, exp.PERIODO) is not null;
        }
    }
}
