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
    public partial class UC_textbox : UserControl
    {
        public UC_textbox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        public int MAX_LENGTH
        {
            get { return textBox1.MaxLength; }
            set { textBox1.MaxLength = value; }
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

        private void UC_textbox_Load(object sender, EventArgs e)
        {

        }
    }
}
