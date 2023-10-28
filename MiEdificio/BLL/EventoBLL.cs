using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EventoBLL
    {
        DAL.EventoDAL eventoDAL = new DAL.EventoDAL();

        public EventoBLL() { }

        private static EventoBLL _instance;

        //singleton para la instancia del evento
        public static EventoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventoBLL();
                }
                return _instance;
            }
        }

        //busca los eventos registrados en sistema
        //puede indicar por parametro la cantidad de registros que quiera retornar
        public List<BE.Evento> ListarEventos(int cantRegistros=0)
        {
            return eventoDAL.Listar(cantRegistros);
        }

        //metodo que busca los eventos en base a los parametros enviados
        public List<BE.Evento> BuscarEventos(DateTime? fechaIni = null, TimeSpan? horaIni = null, DateTime? fechaFin = null,
            TimeSpan? horaFin = null,string usuario = null, string operacion = null, string criticidad = null, string modulo = null)
        {
            return eventoDAL.BuscarEventos(fechaIni,horaIni,fechaFin,horaFin,usuario,operacion,criticidad,modulo);
        }


    }
}
