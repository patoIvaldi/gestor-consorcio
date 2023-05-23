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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            lbl_pie.Text = lbl_pie.Text + DateTime.Now.Year.ToString();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            // Ajustar la posición de los controles para centrarlos
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(this.pb_logo.Name))
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = ((this.Height - control.Height) / 2) - 200;
                }
                else if (control.Name.Equals(this.lbl_pie.Name))
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = ((this.Height - control.Height) / 2) + 300;
                }
                else
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = (this.Height - control.Height) / 2;
                }
            }
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            FormHome form = new FormHome();
            form.ShowDialog();
            this.Close();
        }
    }
}
