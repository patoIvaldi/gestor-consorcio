using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Enumerador
    {

        public enum Operacion
        {
            Insertar, Modificar, Eliminar, Iniciar, Cerrar
        }


        public enum Criticidad
        {
            Baja, Media, Alta, Critica
        }

        public enum Modulo
        {
            ABMUsuarios, ABMPerfiles, ABMIdioma, GeneracionExpensa, CambioClave, CambioIdioma, CierreSesion,Reserva, PagoExpensa, VisualizarDocumento, Reportes, Ayuda, Home, Login, AsignarPerfil, Bitacora, ControlCambios, RecuperarSistema, Respaldo, ABMAreaComun
        }

        public enum Estado
        {
            Pendiente, Cancelado, Finalizado
        }

        public enum TablaIDV
        {
            USUARIO,RESERVA,SEGMENTO,PAGO,EXPENSA,AREA_COMUN
        }
    }
}
