﻿using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpensaDAL
    {

        Acceso acceso = new Acceso();

        public ExpensaDAL() { }


        public List<BE.Expensa> Listar(Int64 dni)
        {
            List<BE.Expensa> expensas = new List<BE.Expensa>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@dni", dni));

            DataTable tabla = acceso.leer("LISTAR_EXPENSAS", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Expensa e = new BE.Expensa(DateTime.Parse(registro["fecha_emision"].ToString()));
                e.ID = int.Parse(registro["id"].ToString());
                e.ESTA_PAGA = Boolean.Parse(registro["esta_paga"].ToString());
                e.DNI = dni;

                SegmentoDAL gestorSegmentos = new SegmentoDAL();

                //buscar segmentos
                e.agregarSegmentos(gestorSegmentos.ObtenerSegmentosExpensa(e.ID));

                expensas.Add(e);
            }
            return expensas;
        }

        public int Generar(BE.Expensa exp)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@fechaEmision", exp.FECHA_EMISION));
            parametros.Add(acceso.crearParametro("@esta_paga", exp.ESTA_PAGA));
            parametros.Add(acceso.crearParametro("@dni", exp.DNI));
            parametros.Add(acceso.crearParametro("@monto", exp.MONTO));
            parametros.Add(acceso.crearParametro("@periodo", exp.PERIODO));
            parametros.Add(acceso.crearParametro("@fvencimiento", exp.DTTM_1ER_VENCIMIENTO));
            parametros.Add(acceso.crearParametro("@svencimiento", exp.DTTM_2DO_VENCIMIENTO));

            modificados = acceso.escribir("INSERTAR_EXPENSA", parametros);

            return modificados;
        }

        public BE.Expensa BuscarPorPeriodoYDNI(Int64 dni, string periodo)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@dni", dni));
            parametros.Add(acceso.crearParametro("@periodo", periodo));

            DataTable tabla = acceso.leer("BUSCAR_EXPENSA", parametros);

            BE.Expensa e = null;

            foreach (DataRow registro in tabla.Rows)
            {
                e = new BE.Expensa(DateTime.Parse(registro["fecha_emision"].ToString()));
                e.ID = int.Parse(registro["id"].ToString());
                e.ESTA_PAGA = Boolean.Parse(registro["esta_paga"].ToString());
            }

            return e;
        }

        public int SaldarExpensa(int idExpensa, int idPago)
        {
            int modificados = 0;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idExpensa", idExpensa));
            parametros.Add(acceso.crearParametro("@idPago", idPago));

            modificados = acceso.escribir("SALDAR_EXPENSA", parametros);

            return modificados;
        }

        //metodo que busca todas las expensas asociadas a un pago
        public List<BE.Expensa> BuscarPorIdPago(Int64 idPago)
        {
            List<BE.Expensa> expensas = new List<BE.Expensa>();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@idPago", idPago));

            DataTable tabla = acceso.leer("BUSCAR_EXPENSAS_X_PAGO", parametros);
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Expensa e = new BE.Expensa(DateTime.Parse(registro["fecha_emision"].ToString()));
                e.ID = int.Parse(registro["id"].ToString());
                e.ESTA_PAGA = Boolean.Parse(registro["esta_paga"].ToString());
                e.DNI = long.Parse(registro["dni"].ToString());

                SegmentoDAL gestorSegmentos = new SegmentoDAL();

                //buscar segmentos
                e.agregarSegmentos(gestorSegmentos.ObtenerSegmentosExpensa(e.ID));

                expensas.Add(e);
            }
            return expensas;
        }

        public DataTable RecaudacionPorPeriodo(Boolean ordenDescendente)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.crearParametro("@ordenamiento", ordenDescendente));

            return acceso.leer("LISTAR_RECAUDACION", parametros);
        }

    }
}
