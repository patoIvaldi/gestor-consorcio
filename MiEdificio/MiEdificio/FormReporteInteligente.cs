using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class FormReporteInteligente : Form
    {
        public FormReporteInteligente()
        {
            InitializeComponent();
        }

        private void FormReporteInteligente_Load(object sender, EventArgs e)
        {
            // Agregar áreas comunes
           // chart1.Series.Add("Reservas");

            // Datos de ejemplo (días del año y reservas)
           // string[] areasComunes = { "Sum", "Pileta", "Parrilla" };
            //int[] reservasDias = { 30, 50, 20 }; // Número de reservas para cada área común

            // Agregar puntos al gráfico
            //for (int i = 0; i < areasComunes.Length; i++)
            //{
                //chart1.Series["Reservas"].Points.AddXY(areasComunes[i], reservasDias[i]);
            //}
        }
    }
}
