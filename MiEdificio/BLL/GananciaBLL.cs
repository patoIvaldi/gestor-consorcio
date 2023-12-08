using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GananciaBLL
    {
        DAL.GananciaDAL gananciaDAL = new DAL.GananciaDAL();

        public GananciaBLL() { }

        private static GananciaBLL _instance;

        //singleton para la instancia
        public static GananciaBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GananciaBLL();
                }
                return _instance;
            }
        }

        //busca las ganancias por anio
        public List<BE.Ganancia> ListarGanancias(int anio = 0)
        {
            return gananciaDAL.Listar(anio);
        }
        //retorna los anios
        public List<string> ListarAnios()
        {
            return gananciaDAL.ListarAnios();
        }

    }
}
