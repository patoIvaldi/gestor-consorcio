using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IdiomaBLL
    {

        DAL.IdiomaDAL idiomaDAL = new DAL.IdiomaDAL();

        public IdiomaBLL() {

        }

        private static IdiomaBLL _instance;
        public static IdiomaBLL INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IdiomaBLL();
                }
                return _instance;
            }
        }

        public List<Services.ServiceIdioma> Listar()
        {
            return idiomaDAL.Listar();
        }
    }
}
