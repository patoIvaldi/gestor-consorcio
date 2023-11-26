using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HashGlobalBLL
    {
        DAL.HashGlobalDAL hashDAL = new DAL.HashGlobalDAL();

        public HashGlobalBLL() { }

        private static HashGlobalBLL _instance;

        //singleton para la instancia del evento
        public static HashGlobalBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HashGlobalBLL();
                }
                return _instance;
            }
        }

        public Boolean InsertarHashGlobal(BE.HASH_GLOBAL hashEntity)
        {
            return hashDAL.InsertarHashGlobal(hashEntity) > 0 ? true : false;
        }

        public Boolean ExisteHash(string hashABuscar)
        {
            return hashDAL.BuscarHashGlobal(hashABuscar);
        }

    }
}
