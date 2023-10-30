using BE;
using BLL;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
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
    public partial class FormEventos : Form
    {

        TimeSpan? horaInicioFormateado = null;
        TimeSpan? horaFinFormateado = null;
        DateTime? fechaInicioSelected = null;
        DateTime? fechaFinSelected = null;

        public FormEventos()
        {
            InitializeComponent();
        }

        private void FormEventos_Load(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de bitacora eventos.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.Bitacora.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            enlazarCriticidades();
            enlazarOperaciones();
            enlazarUsuarios();
            enlazarEventos(20, null);

            //me suscribo al evento valuechanged de los datetimepicker
            DateTimePicker dateTimePickerEnUserControlInicio = uc_fechaInicio.dtp_publico;
            dateTimePickerEnUserControlInicio.ValueChanged += DateTimePickerEnUserControlInicio_ValueChanged;
            DateTimePicker dateTimePickerEnUserControlFin = uc_fechaFin.dtp_publico;
            dateTimePickerEnUserControlFin.ValueChanged += DateTimePickerEnUserControlFin_ValueChanged;
        }

        private void enlazarCriticidades()
        {
            cb_criticidad.DataSource = null;
            cb_criticidad.Items.Clear();
            cb_criticidad.Items.Add("");

            List<Enum> lista = new List<Enum>();

            foreach (BE.Enumerador.Criticidad opt in Enum.GetValues(typeof(BE.Enumerador.Criticidad)))
            {
                lista.Add(opt);
            }

            cb_criticidad.Items.AddRange(lista.ToArray());
        }

        private void enlazarOperaciones()
        {
            cb_operacion.DataSource = null;
            cb_operacion.Items.Clear();
            cb_operacion.Items.Add("");

            List<Enum> lista = new List<Enum>();

            foreach (BE.Enumerador.Operacion opt in Enum.GetValues(typeof(BE.Enumerador.Operacion)))
            {
                lista.Add(opt);
            }

            cb_operacion.Items.AddRange(lista.ToArray());

            //cb_operacion.DataSource = Enum.GetValues(typeof(BE.Enumerador.Operacion));
        }

        private void enlazarUsuarios()
        {
            cb_usuario.Items.Clear();
            cb_usuario.Items.Add("");
            cb_usuario.Items.AddRange(UsuarioBLL.Instance.listarUsuarios().ToArray());
        }

        private void enlazarEventos(int cantReg, List<BE.Evento> resultados)
        {
            dgv_eventos.DataSource = null;
            dgv_eventos.DataSource = resultados == null ? BLL.EventoBLL.Instance.ListarEventos(cantReg) : resultados;
            dgv_eventos.Columns["ID"].Visible = false;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            uc_fechaInicio.resetear();
            fechaInicioSelected = null;
            uc_fechaFin.resetear();
            fechaFinSelected = null;
            uc_horaInicio.TEXT_BOX = "";
            uc_horaFin.TEXT_BOX = "";
            enlazarCriticidades();
            enlazarOperaciones();
            enlazarUsuarios();
            enlazarEventos(20, null);
            cb_usuario.SelectionStart = 0;
            cb_usuario.SelectedIndex = 0;
            cb_criticidad.SelectionStart = 0;
            cb_criticidad.SelectedIndex = 0;
            cb_operacion.SelectionStart = 0;
            cb_operacion.SelectedIndex = 0;

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

        //metodo asociado al boton buscar
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (validarHora(uc_horaInicio.TEXT_BOX, true)
                && validarHora(uc_horaFin.TEXT_BOX, false))
            {
                BE.Usuario usuarioSelected = cb_usuario.SelectedItem != null && cb_usuario.SelectedItem != ""? (BE.Usuario)cb_usuario.SelectedItem:null;
                string operacionSelected = cb_operacion.SelectedItem != null && cb_operacion.SelectedItem != "" ? cb_operacion.SelectedItem.ToString() : null;
                string criticidadSelected = cb_criticidad.SelectedItem != null && cb_criticidad.SelectedItem != "" ? cb_criticidad.SelectedItem.ToString() : null;
                //string moduloSelected = (string)cb_operacion.SelectedItem;

                //buscamos los eventos en base a los filtros cargados
                enlazarEventos(0, BLL.EventoBLL.Instance.BuscarEventos(
                    fechaInicioSelected, horaInicioFormateado,
                    fechaFinSelected, horaFinFormateado, usuarioSelected != null ? usuarioSelected.USERNAME : null,
                    operacionSelected, criticidadSelected));

            }
        }

        private void uc_fechaInicio_Click(object sender, EventArgs e)
        {

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
