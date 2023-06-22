using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IdiomaDAL
    {
        Acceso acceso = new Acceso();

        public IdiomaDAL() { }

        public List<ServiceIdioma> Listar()
        {
            List<ServiceIdioma> idiomas = new List<ServiceIdioma>();
            DataTable tabla = acceso.leer("LISTAR_IDIOMAS", null);
            foreach (DataRow registro in tabla.Rows)
            {
                ServiceIdioma idioma = new ServiceIdioma();
                idioma.ID = registro["id"].ToString();
                idioma.DESCRIPCION = registro["Descripcion"].ToString();
                idiomas.Add(idioma);
            }
            return idiomas;
        }

    }
}
