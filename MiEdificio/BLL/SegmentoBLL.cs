using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SegmentoBLL
    {

        DAL.SegmentoDAL segmentoDAL = new DAL.SegmentoDAL();

        public SegmentoBLL() { }

        private static SegmentoBLL _instance;

        //singleton para la instancia del segmento
        public static SegmentoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SegmentoBLL();
                }
                return _instance;
            }
        }

        public List<BE.Segmento> obtenerSegmentosExpensa(int idExpensa)
        {
            return segmentoDAL.ObtenerSegmentosExpensa(idExpensa);
        }
    }
}
