using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class UC_button : UserControl
    {
        public UC_button()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UC_button_Load(object sender, EventArgs e)
        {
            //button1.FlatStyle = FlatStyle.Flat;
            // button1.FlatAppearance.BorderSize = 1;
            // button1.FlatAppearance.BorderColor = Color.Gray;
            //button1.BackColor = Color.FromArgb(255, 204, 153, 153); // Cambia el color de fondo
            // button1.ForeColor = Color.White; // Cambia el color del texto

            // GraphicsPath path = new GraphicsPath();
            // int borderRadius = 2; // Cambia el radio de borde
            // path.AddEllipse(0, 0, button1.Width, button1.Height);
            // button1.Region = new Region(path);
        }

        public string ETIQUETA
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }
    }
}
