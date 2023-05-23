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
    public partial class UC_tb_numerico : UserControl
    {
        public UC_tb_numerico()
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

        //metodo que valida que el campo venga completo en caso de ser requerido
        //y a su vez que el valor sea numerico
        public Boolean validar()
        {
            Boolean validacionOK = false;

            if (this.requerido && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                    !esNumerico(textBox1.Text) && !esNumericoLargo(textBox1.Text))
                {
                    textBox1.BackColor = Color.Yellow;
                    MessageBox.Show("Error, el campo es númerico.");
                }
                else
                {
                    validacionOK = true;
                    textBox1.BackColor = Color.White;
                }
            }
            return validacionOK;
        }

        //metodo que valida si el string de entrada es solo numeros
        public static Boolean esNumerico(string supuestoNumero)
        {
            Boolean esNumerico = true;

            try
            {
                int.Parse(supuestoNumero);
            }
            catch
            {
                esNumerico = false;
            }
            return esNumerico;
        }

        //valida si es un numerico largo
        public static Boolean esNumericoLargo(string supuestoNumero)
        {
            Boolean esNumerico = true;

            try
            {
                Int64.Parse(supuestoNumero);
            }
            catch
            {
                esNumerico = false;
            }
            return esNumerico;
        }

        private void UC_tb_numerico_Load(object sender, EventArgs e)
        {

        }
    }
}
