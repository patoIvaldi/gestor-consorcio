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
    }
}
