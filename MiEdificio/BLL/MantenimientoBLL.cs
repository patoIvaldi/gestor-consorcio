using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MantenimientoBLL
    {

        DAL.MantenimientoDAL mantenimientoDAL = new DAL.MantenimientoDAL();

        private MantenimientoBLL() { }

        private static MantenimientoBLL instance;

        public static MantenimientoBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MantenimientoBLL();
                }
                return instance;
            }
        }

        //crear metodo backup
        public void crearBackup(Services.ServiceBackup backup)
        {
            mantenimientoDAL.realizarBackup(backup);
        }

        //crear metodo restore
        public void crearRestore(Services.ServiceRestore restore)
        {
            mantenimientoDAL.realizarRestore(restore);
        }
    }
}
