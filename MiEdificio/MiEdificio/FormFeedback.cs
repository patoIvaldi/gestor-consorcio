using BE;
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

                Boolean modificada = BLL.ReservasBLL.Instance.ModificarReserva(reservaSelected, null, false);

                if (modificada)
                {
                    MessageBox.Show("Feedback cargado correctamente.");
                    this.Close();
                }

                BE.Evento evento = new Evento();
                evento.USUARIO = Services.ServiceSesion.Instance.USER;
                evento.DETALLE = "El usuario genero el feedback de la reserva: " + reservaSelected.ID;
                evento.CRITICIDAD = Enumerador.Criticidad.Alta.ToString();
                evento.OPERACION = Enumerador.Operacion.Insertar.ToString();
                evento.MODULO = Enumerador.Modulo.Reserva.ToString();

                BLL.EventoBLL.Instance.AgregarEvento(evento);
            }
        }

        private void FormFeedback_Load(object sender, EventArgs e)
        {

            TraducirComponentes();

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de feedback.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.Reserva.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            btn_guardar.Enabled = false;

            List<BE.Reserva> reservas = new List<BE.Reserva>();
            reservas.Add(reservaSelected);

            dgv_reserva.DataSource = null;
            dgv_reserva.DataSource = reservas;

        }

        public void TraducirComponentes()
        {
            IDictionary<string, string> traducciones = BLL.IdiomaBLL.INSTANCE.diccionario;

            if (traducciones is not null && traducciones.Count > 0)
            {
                this.Text = traducciones.ContainsKey(this.Name) ? traducciones[this.Name] : this.Text;

                foreach (Control c in this.Controls)
                {
                    //traduzco el texto del componente
                    c.Text = traducciones.ContainsKey(c.Name + "_" + this.Name) ? traducciones[c.Name + "_" + this.Name] : c.Text;

                    //si es un groupbox, recorro todos los componentes que tenga en su interior
                    if (c is GroupBox)
                    {
                        foreach (Control controlChild in ((GroupBox)c).Controls)
                        {
                            if (controlChild is UC_tb_numerico)
                            {
                                ((UC_tb_numerico)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_numerico)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_tb_password)
                            {
                                ((UC_tb_password)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_password)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_textbox)
                            {
                                ((UC_textbox)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_textbox)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_dttmPicker)
                            {
                                ((UC_dttmPicker)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_dttmPicker)controlChild).ETIQUETA;
                            }
                            else
                            {
                                controlChild.Text = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : controlChild.Text;
                            }
                        }
                    }
                }
            }
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
