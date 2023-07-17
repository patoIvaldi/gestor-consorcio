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
    public partial class FormCambiarIdioma : Form
    {

        FormHome home;

        public FormCambiarIdioma(FormHome home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void FormCambiarIdioma_Load(object sender, EventArgs e)
        {
            //recupero los idiomas configurados y los cargo en la pantalla
            cb_idioma.DataSource = null;
            cb_idioma.DataSource = BLL.IdiomaBLL.INSTANCE.Listar();
            cb_idioma.DisplayMember = "DESCRIPCION";
        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            this.Close();
            home.TraducirComponentes();
        }

        private void cb_idioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Services.ServiceIdioma idiomaElegido = (Services.ServiceIdioma)cb_idioma.SelectedItem;

            if (idiomaElegido is not null)
            {
                TraducirComponentes(
                    BLL.IdiomaBLL.INSTANCE.ListarTraducciones(idiomaElegido));
            }
        }

        private void TraducirComponentes(IDictionary<string, string> traducciones)
        {
            if (traducciones is not null && traducciones.Count > 0)
            {
                cb_idioma.Text = traducciones.ContainsKey(cb_idioma.Name + "_" + this.Name) ? traducciones[cb_idioma.Name + "_" + this.Name] : cb_idioma.Text;
                gb_cambiarIdioma.Text = traducciones.ContainsKey(gb_cambiarIdioma.Name + "_" + this.Name) ? traducciones[gb_cambiarIdioma.Name + "_" + this.Name] : gb_cambiarIdioma.Text;
                btn_cambiar.Text = traducciones.ContainsKey(btn_cambiar.Name + "_" + this.Name) ? traducciones[btn_cambiar.Name + "_" + this.Name] : btn_cambiar.Text;
                this.Text = traducciones.ContainsKey(this.Name) ? traducciones[this.Name] : this.Text;
            }
        }
    }
}
