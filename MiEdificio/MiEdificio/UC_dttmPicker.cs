using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class UC_dttmPicker : UserControl
    {
        public UC_dttmPicker()
        {
            //dateTimePicker1.MaxDate = DateTime.Now;
            InitializeComponent();
        }

        private void UC_dttmPicker_Load(object sender, EventArgs e)
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

        private DateTime? valor;

        public DateTime? VALOR
        {
            get { return valor; }
            set
            {
                this.dateTimePicker1.Value = value.Value.CompareTo(dateTimePicker1.MinDate) < 0 ? DateTime.Today : value.Value;
                valor = this.dateTimePicker1.Value;
            }
        }


        //metodo que valida que el campo venga completo en caso de ser requerido
        public Boolean validar()
        {
            Boolean validacionOK = true;
            dateTimePicker1.BackColor = Color.White;

            if (this.requerido && this.valor is null)
            {
                validacionOK = false;
                dateTimePicker1.BackColor = Color.Red;
            }

            return validacionOK;
        }

        public void resetear()
        {
            this.valor = DateTime.Now;
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.valor = this.dateTimePicker1.Value;
        }
    }
}
