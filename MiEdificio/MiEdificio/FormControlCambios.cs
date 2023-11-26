using BE;
using BLL;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FormControlCambios : Form
    {

        TimeSpan? horaInicioFormateado = null;
        TimeSpan? horaFinFormateado = null;
        DateTime? fechaInicioSelected = null;
        DateTime? fechaFinSelected = null;
        Boolean? valueCheckSelected = null;
        ReservaControlCambios versionSelected = null;

        public FormControlCambios()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //en la carga del formulario
        private void FormControlCambios_Load(object sender, EventArgs e)
        {

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de control de cambios.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.ControlCambios.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            enlazarUsuarios();
            enlazarEstados();
            enlazarCambios(100, null);
            btn_restaurar.Enabled = false;

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

        private void enlazarEstados()
        {
            cb_estados.DataSource = null;
            cb_estados.Items.Clear();
            cb_estados.Items.Add("");

            List<Enum> lista = new List<Enum>();

            foreach (BE.Enumerador.Estado opt in Enum.GetValues(typeof(BE.Enumerador.Estado)))
            {
                lista.Add(opt);
            }

            cb_estados.Items.AddRange(lista.ToArray());
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            valueCheckSelected = null;
            uc_fechainicio.resetear();
            fechaInicioSelected = null;
            uc_fechafin.resetear();
            fechaFinSelected = null;
            uc_horainicio.TEXT_BOX = "";
            uc_horafin.TEXT_BOX = "";
            check_activo.Checked = false;
            enlazarUsuarios();
            cb_usuarios.SelectionStart = 0;
            cb_usuarios.SelectedIndex = 0;
            enlazarEstados();
            cb_estados.SelectionStart = 0;
            cb_estados.SelectedIndex = 0;
            enlazarCambios(100, null);
            btn_restaurar.Enabled = false;
            versionSelected = null;
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

        //enlazamos los cambios en el datagridview
        private void enlazarCambios(int cantReg, List<BE.ReservaControlCambios> resultados)
        {
            dgv_cambios.DataSource = null;
            dgv_cambios.DataSource = resultados == null ? BLL.ReservaControlCambiosBLL.Instance.ListarCambiosReservas(cantReg) : resultados;
            BLL.GenericHelper.Instance.AdjustRowHeight(dgv_cambios);
        }

        //logica boton buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (validarHora(uc_horainicio.TEXT_BOX, true)
                && validarHora(uc_horafin.TEXT_BOX, false))
            {
                BE.Usuario usuarioSelected = cb_usuarios.SelectedItem != null && cb_usuarios.SelectedItem != "" ? (BE.Usuario)cb_usuarios.SelectedItem : null;
                string estadoSelected = cb_estados.SelectedItem != null && cb_estados.SelectedItem != "" ? cb_estados.SelectedItem.ToString() : null;

                //buscamos los cambios en base a los filtros cargados
                enlazarCambios(0, BLL.ReservaControlCambiosBLL.Instance.BuscarCambiosReservas(
                    fechaInicioSelected, horaInicioFormateado,
                    fechaFinSelected, horaFinFormateado, usuarioSelected != null ? usuarioSelected.USERNAME : null,
                    estadoSelected, valueCheckSelected));

            }
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

        //cargo la referencia del check
        private void check_activo_CheckedChanged(object sender, EventArgs e)
        {
            valueCheckSelected = check_activo.Checked;
        }

        //logica para restaurar la version seleccionada
        private void btn_restaurar_Click(object sender, EventArgs e)
        {
            if (versionSelected != null)
            {
                BE.Reserva reservaRollback = new BE.Reserva();
                reservaRollback.ID = versionSelected.ID_RESERVA;
                reservaRollback.ESTADO = versionSelected.ESTADO_RESERVA;
                reservaRollback.AREA = versionSelected.AREA;
                reservaRollback.FECHA_RESERVA_INICIO = versionSelected.FECHA_RESERVA_INICIO;
                reservaRollback.FECHA_RESERVA_FIN = versionSelected.FECHA_RESERVA_FIN;
                reservaRollback.USUARIO_AUTOR = versionSelected.USUARIO_RESERVA;
                reservaRollback.FEEDBACK = versionSelected.FEEDBACK;

                if (BLL.ReservasBLL.Instance.ModificarReserva(reservaRollback))
                {
                    MessageBox.Show("Versión de la reserva restaurada con éxito.");
                    enlazarCambios(100, null);
                }
                else
                {
                    MessageBox.Show("Error, no se pudo restaurar la versión seleccionada.");
                }
            }
        }

        //cargamos la version seleccionada
        private void dgv_cambios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            versionSelected = (BE.ReservaControlCambios)dgv_cambios.Rows[e.RowIndex].DataBoundItem;

            if (versionSelected != null)
            {
                btn_restaurar.Enabled = true;
            }
            else
            {
                btn_restaurar.Enabled = false;
            }
        }
    }
}
