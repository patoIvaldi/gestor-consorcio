using BE;
using BLL;
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
    public partial class FormGenerarReserva : Form
    {

        public string area = "";
        DateTime? fechaInicioSelected = null;
        DateTime? fechaFinSelected = null;
        TimeSpan? horaInicioFormateado = null;
        TimeSpan? horaFinFormateado = null;
        BE.Reserva reservaSelected = null;

        public FormGenerarReserva(string area)
        {
            this.area = area;
            InitializeComponent();
        }

        private void FormGenerarReserva_Load(object sender, EventArgs e)
        {
            btn_feedback.Enabled = false;
            btn_cancelar.Enabled = false;

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de generación de reservas.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.ControlCambios.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            enlazarUsuarios();
            enlazarAreas();
            enlazarReservas(50, null);

            //me suscribo al evento valuechanged de los datetimepicker
            DateTimePicker dateTimePickerEnUserControlInicio = uc_fechainicio.dtp_publico;
            dateTimePickerEnUserControlInicio.ValueChanged += DateTimePickerEnUserControlInicio_ValueChanged;
            DateTimePicker dateTimePickerEnUserControlFin = uc_fechafin.dtp_publico;
            dateTimePickerEnUserControlFin.ValueChanged += DateTimePickerEnUserControlFin_ValueChanged;
        }

        private void enlazarUsuarios()
        {
            cb_usuarios.Items.Clear();

            if (Services.ServiceSesion.Instance.USER.PERSONA is BE.AdministradorConsorcio) //esto hay que validar por permisos
            {
                cb_usuarios.Items.Add("");
                cb_usuarios.Items.AddRange(UsuarioBLL.Instance.listarUsuarios().ToArray());
                cb_usuarios.Enabled = true;
            }
            else
            {
                List<BE.Usuario> usuarios = new List<Usuario>();
                usuarios.Add(Services.ServiceSesion.Instance.USER);

                cb_usuarios.Items.AddRange(usuarios.ToArray());
                cb_usuarios.SelectedIndex = 0;
                cb_usuarios.Enabled = false;
            }
        }

        private void enlazarAreas()
        {
            cb_areas.Items.Clear();
            cb_areas.Items.Add(this.area);
            cb_areas.SelectedIndex = 0;
        }

        private void enlazarReservas(int cantReg, List<BE.Reserva> reservas)
        {
            dgv_reservas.DataSource = null;
            dgv_reservas.DataSource = reservas == null ? BLL.ReservasBLL.Instance.ListarReservas(cantReg) : reservas;
            BLL.GenericHelper.Instance.AdjustRowHeight(dgv_reservas);
        }

        //logica boton generar reserva
        private void btn_reservar_Click(object sender, EventArgs e)
        {
            if (camposCargadosCorrectamente())
            {
                if (validarHora(uc_horaInicio.TEXT_BOX, true) &&
                    validarHora(uc_horaFin.TEXT_BOX, false))
                {
                    BE.Reserva reserva = new Reserva();
                    reserva.ESTADO = Enumerador.Estado.Pendiente.ToString();
                    reserva.AREA = this.area;
                    reserva.FECHA_RESERVA_INICIO = fechaInicioSelected.Value.Add((TimeSpan)horaInicioFormateado);
                    reserva.FECHA_RESERVA_FIN = fechaFinSelected.Value.Add((TimeSpan)horaFinFormateado);
                    reserva.USUARIO_AUTOR = (BE.Usuario)cb_usuarios.SelectedItem;

                    //VALIDA QUE NO ESTE OCUPADO EL AREA PARA ESA FECHA Y QUE EL USUARIO NO TENGA OTRA RESERVA ACTIVA
                    if (!BLL.ReservasBLL.Instance.ValidarDisponibilidad(reserva))
                    {
                        //generamos la reserva
                        if (BLL.ReservasBLL.Instance.AgregarReserva(reserva))
                        {

                            BE.Evento evento = new Evento();
                            evento.USUARIO = Services.ServiceSesion.Instance.USER;
                            evento.DETALLE = "El usuario generó la reserva: " + reserva.ID;
                            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
                            evento.OPERACION = Enumerador.Operacion.Insertar.ToString();
                            evento.MODULO = Enumerador.Modulo.Reserva.ToString();

                            BLL.EventoBLL.Instance.AgregarEvento(evento);

                            MessageBox.Show("Reserva generada con éxito.");
                            enlazarReservas(50, null);
                        }
                        else
                        {
                            MessageBox.Show("Error, no se pudo generar la reserva.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, El area comun ya se encuentra reservada en esa fecha o ya posee una reserva pendiente para ese area comun.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error, debe completar todos los campos para generar la reserva.");
            }
        }

        //validamos los campos cargados
        private Boolean camposCargadosCorrectamente()
        {
            Boolean isOk = false;

            if (cb_areas.SelectedItem != null && cb_usuarios.SelectedItem != null
                && fechaInicioSelected != null && fechaFinSelected != null)
            {
                isOk = true;
            }

            return isOk;
        }

        //metodo que esta suscripto al valuechanged del datetimepicker del user control
        private void DateTimePickerEnUserControlInicio_ValueChanged(object sender, EventArgs e)
        {
            // El valor del DateTimePicker en el UserControl ha cambiado.
            // Actualiza la variable 'fechaInicio' con el nuevo valor.
            fechaInicioSelected = ((DateTimePicker)sender).Value;
        }

        private void DateTimePickerEnUserControlFin_ValueChanged(object sender, EventArgs e)
        {
            // El valor del DateTimePicker en el UserControl ha cambiado.
            // Actualiza la variable 'fechaInicio' con el nuevo valor.
            fechaFinSelected = ((DateTimePicker)sender).Value;
        }

        //Metodo que valida el formato de hora ingresada por el usuario
        private Boolean validarHora(string horaStr, Boolean esHoraInicio)
        {
            Boolean horaOK = true;

            //validamos la hora ingresada
            if (horaOK && !string.IsNullOrEmpty(horaStr))
            {

                List<string> valoresHora = horaStr.Split(':').ToList();

                if (valoresHora.Count() != 3)
                {
                    horaOK = false;
                    MessageBox.Show("Error, debe ingresar la hora con formato hh:mm:ss ");
                }
                else
                {
                    try
                    {
                        if (esHoraInicio)
                        {
                            horaInicioFormateado = new TimeSpan(int.Parse(valoresHora.ElementAt(0)),
                                int.Parse(valoresHora.ElementAt(1)), int.Parse(valoresHora.ElementAt(2)));
                        }
                        else
                        {
                            horaFinFormateado = new TimeSpan(int.Parse(valoresHora.ElementAt(0)),
                                int.Parse(valoresHora.ElementAt(1)), int.Parse(valoresHora.ElementAt(2)));
                        }
                    }
                    catch
                    {
                        horaOK = false;
                        MessageBox.Show("Error, las horas, minutos y segundos del formato hh:mm:ss deben ser solo números.");
                    }
                }
            }

            return horaOK;
        }

        private void btn_feedback_Click(object sender, EventArgs e)
        {
            if (reservaSelected != null)
            {
                FormFeedback formFeedback = new FormFeedback(reservaSelected);
                formFeedback.ShowDialog();

                enlazarReservas(50, null);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una reserva.");
            }
        }

        private void dgv_reservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            reservaSelected = (BE.Reserva)dgv_reservas.Rows[e.RowIndex].DataBoundItem;

            //logica para poder dar feedback dentro del rango permitido
            if (reservaSelected != null && DateTime.Now.Subtract(reservaSelected.FECHA_RESERVA_FIN).TotalHours >= 0
                && DateTime.Now.Subtract(reservaSelected.FECHA_RESERVA_FIN).TotalHours <= 24)
            {
                btn_feedback.Enabled = true;
            }
            else
            {
                btn_feedback.Enabled = false;
            }

            //logica para cancelar reservas
            if (reservaSelected != null && reservaSelected.ESTADO.Equals(Enumerador.Estado.Pendiente.ToString())
                && reservaSelected.USUARIO_AUTOR.USERNAME.Equals(Services.ServiceSesion.Instance.USER.USERNAME))
            {
                btn_cancelar.Enabled = true;
            }
            else
            {
                btn_cancelar.Enabled = false;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (reservaSelected != null)
            {
                reservaSelected.ESTADO = Enumerador.Estado.Cancelado.ToString();

                Boolean modificada = BLL.ReservasBLL.Instance.ModificarReserva(reservaSelected);

                if (modificada)
                {
                    MessageBox.Show("Reserva cancelada.");
                    enlazarReservas(50, null);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una reserva.");
            }
        }
    }
}
