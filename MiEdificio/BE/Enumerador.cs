﻿using System;
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
            Insertar, Modificar, Eliminar
        }


        public enum Criticidad
        {
            Baja, Media, Alta, Critica
        }

        public enum Modulo
        {
            ABMUsuarios, ABMPerfiles, ABMIdioma, GeneracionExpensa, CambioClave, CambioIdioma, CierreSesion,Reserva, PagoExpensa, VisualizarDocumento, Reportes, Ayuda
        }

    }
}