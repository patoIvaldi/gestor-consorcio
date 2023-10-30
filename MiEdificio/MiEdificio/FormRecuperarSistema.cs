using BE;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic.Logging;
using MiEdificio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormRecuperarSistema : Form
    {
        public FormRecuperarSistema(FormHome home)
        {
            this.formHome = home;
            InitializeComponent();
        }

        FormHome formHome;

        private void btn_salir_Click(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario cerró sesión desde el formulario de recuperaci+on del sistema.";
            evento.CRITICIDAD = Enumerador.Criticidad.Critica.ToString();
            evento.OPERACION = Enumerador.Operacion.Cerrar.ToString();
            evento.MODULO = Enumerador.Modulo.RecuperarSistema.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            this.Close();
            formHome.cerrarSesion();
        }

        private void btn_bd_Click(object sender, EventArgs e)
        {
            this.Close();
            FormRespaldo formRespaldo = new FormRespaldo();
            formRespaldo.ShowDialog();
        }

        private void btn_recalcular_Click(object sender, EventArgs e)
        {

        }

        private void FormRecuperarSistema_Load(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de recuperación del sistema.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.RecuperarSistema.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);
        }
    }
}
