using BE;
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

        //metodo que realiza la generacion del hash para la ganancia
        private string ArmarHashGanancia(BE.Ganancia ganancia)
        {
            string cadena = ganancia.ANIO.ToString() + ganancia.MES.ToString() + ganancia.GANANCIA.ToString();

            ganancia.IDV = Services.ServiceEncriptador.Instance.GenerarHASH(cadena);

            return ganancia.IDV;
        }

        private void ArmarHashGlobalGanancia()
        {
            //buscamos la lista de todas las ganancias
            List<BE.Ganancia> ganancias = ListarGanancias(0);
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Ganancia u in ganancias)
            {
                cadenaIDVs += u.IDV != null ? u.IDV : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalGanancia = new BE.HASH_GLOBAL();
            idvGlobalGanancia.NOMBRE_TABLA = Enumerador.TablaIDV.GANANCIA.ToString();
            idvGlobalGanancia.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalGanancia);
        }

        public string RecalcularHashGlobalGanancias()
        {
            //buscamos la lista de todas las ganancias
            List<BE.Ganancia> ganancias = ListarGanancias(0);
            string cadenaIDVs = "";

            //concatenamos cada uno de los hashes
            foreach (BE.Ganancia a in ganancias)
            {
                string idvRecalculado = ArmarHashGanancia(a);
                cadenaIDVs += idvRecalculado != null ? idvRecalculado : "";
            }

            return Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);
        }

        public void SanearSistemaIDV()
        {
            //buscamos la lista de todas las ganancias
            List<BE.Ganancia> ganancias = ListarGanancias(0);
            string cadenaIDVs = "";

            //generamos y concatenamos cada uno de los hashes
            foreach (BE.Ganancia a in ganancias)
            {
                //recalculamos el hash para cada ganacia
                string nuevoHashGanancia = ArmarHashGanancia(a);

                //persistimos el nuevo hash en la tabla ganancia
                gananciaDAL.ActualizarIDVGanancia(a, nuevoHashGanancia);

                //lo concatenamos a la cadena de hashes para generar el global
                cadenaIDVs += nuevoHashGanancia != null ? nuevoHashGanancia : "";
            }

            //generamos el hash global
            BE.HASH_GLOBAL idvGlobalGanancia = new BE.HASH_GLOBAL();
            idvGlobalGanancia.NOMBRE_TABLA = Enumerador.TablaIDV.GANANCIA.ToString();
            idvGlobalGanancia.IDV_GLOBAL = Services.ServiceEncriptador.Instance.GenerarHASH(cadenaIDVs);

            BLL.HashGlobalBLL.Instance.InsertarHashGlobal(idvGlobalGanancia);
        }

    }
}
