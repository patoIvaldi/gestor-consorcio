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

        public FormGenerarReserva(string area)
        {
            this.area = area;
            InitializeComponent();
        }

        private void FormGenerarReserva_Load(object sender, EventArgs e)
        {
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
            cb_usuarios.Items.Add("");
            cb_usuarios.Items.AddRange(UsuarioBLL.Instance.listarUsuarios().ToArray());
        }

        private void enlazarAreas()
        {
            cb_areas.Items.Clear();
            cb_areas.Items.Add(this.area);
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
                BE.Reserva reserva = new Reserva();
                reserva.ESTADO = Enumerador.Estado.Pendiente.ToString();
                reserva.AREA = this.area;
                reserva.FECHA_RESERVA_INICIO = fechaInicioSelected.Value;
                reserva.FECHA_RESERVA_FIN = fechaFinSelected.Value;
                reserva.USUARIO_AUTOR = (BE.Usuario)cb_usuarios.SelectedItem;

                //TODO VALIDAR QUE NO ESTE OCUPADO EL AREA PARA ESA FECHA Y QUE EL USUARIO NO TENGA OTRA RESERVA ACTIVA

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
                }
                else
                {
                    MessageBox.Show("Error, no se pudo generar la reserva.");
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
    }
}
