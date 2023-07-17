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
        public IDictionary<string, string> diccionario;

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

        public Boolean Agregar(Services.ServiceIdioma nuevo)
        {
            return idiomaDAL.InsertarOModificar(nuevo) > 0;
        }

        public Boolean Borrar(Services.ServiceIdioma idioma)
        {
            return idiomaDAL.Borrar(idioma) > 0;
        }

        public IDictionary<string,string> ListarTraducciones(Services.ServiceIdioma idioma)
        {
            //creamos el diccionario con las traducciones de cada componente.
            diccionario = new Dictionary<string, string>();

            //buscamos las traducciones en la BD
            List<Services.ServiceTraduccion> traducciones = idiomaDAL.ListarTraducciones(idioma);

            foreach (Services.ServiceTraduccion t in traducciones)
            {
                diccionario.Add(t.NOMBRE_OBJETO,t.TRADUCCION_TXT);
            }

            return diccionario;
        }
    }
}
