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
    public partial class FormFeedback : Form
    {

        BE.Reserva reservaSelected;

        public FormFeedback(BE.Reserva reservaEnviada)
        {
            this.reservaSelected = reservaEnviada;
            InitializeComponent();
        }

        private void dgv_reserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            reservaSelected = (BE.Reserva)dgv_reserva.Rows[e.RowIndex].DataBoundItem;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (reservaSelected != null)
            {
                reservaSelected.FEEDBACK = rt_feedback.Text;

                Boolean modificada = BLL.ReservasBLL.Instance.ModificarReserva(reservaSelected);

                if (modificada)
                {
                    MessageBox.Show("Feedback cargado correctamente.");
                    this.Close();
                }
            }
        }

        private void FormFeedback_Load(object sender, EventArgs e)
        {
            btn_guardar.Enabled = false;

            List<BE.Reserva> reservas = new List<BE.Reserva>();
            reservas.Add(reservaSelected);

            dgv_reserva.DataSource = null;
            dgv_reserva.DataSource = reservas;

        }

        private void rt_feedback_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rt_feedback.Text))
            {
                btn_guardar.Enabled = true;
            }
            else
            {
                btn_guardar.Enabled = false;
            }
        }
    }
}
