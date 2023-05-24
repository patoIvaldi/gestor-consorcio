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
    public partial class UC_tb_password : UserControl
    {
        public UC_tb_password()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // se restringe la visualizacion de la password
            textBox1.PasswordChar = '*';
        }

        public string ETIQUETA
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private Boolean requerido;

        public Boolean REQUERIDO
        {
            get { return requerido; }
            set { requerido = value; }
        }

        public string TEXT_BOX
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        //metodo que valida que el campo venga completo en caso de ser requerido
        public Boolean validar()
        {
            Boolean validacionOK = true;
            textBox1.BackColor = Color.White;

            if (this.requerido && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                validacionOK = false;
                textBox1.BackColor = Color.Red;
            }

            return validacionOK;
        }

        private void UC_tb_password_Load(object sender, EventArgs e)
        {

        }
    }
}
