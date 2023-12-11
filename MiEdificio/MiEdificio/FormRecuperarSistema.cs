using BE;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic.Logging;
using MiEdificio;
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
    public partial class FormRecuperarSistema : Form
    {
        public FormRecuperarSistema(FormHome home)
        {
            this.formHome = home;
            InitializeComponent();
        }

        FormHome formHome;

        private void btn_salir_Click(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario cerró sesión desde el formulario de recuperacion del sistema.";
            evento.CRITICIDAD = Enumerador.Criticidad.Critica.ToString();
            evento.OPERACION = Enumerador.Operacion.Cerrar.ToString();
            evento.MODULO = Enumerador.Modulo.RecuperarSistema.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            this.Close();
            formHome.necesitaReiniciar = true;
            formHome.cerrarSesion();
        }

        private void btn_bd_Click(object sender, EventArgs e)
        {
            this.Close();
            FormRespaldo formRespaldo = new FormRespaldo();
            formRespaldo.ControlBox = false;
            formRespaldo.ShowDialog();

            MessageBox.Show("Se reiniciara la sesion.");
            this.Close();
            formHome.necesitaReiniciar = true;
            formHome.cerrarSesion();
        }

        private void btn_recalcular_Click(object sender, EventArgs e)
        {
            BLL.UsuarioBLL.Instance.SanearSistemaIDV();
            BLL.AreaComunBLL.Instance.SanearSistemaIDV();
            BLL.GananciaBLL.Instance.SanearSistemaIDV();
            BLL.MetricaBLL.Instance.SanearSistemaIDV();
            BLL.ExpensaBLL.Instance.SanearSistemaIDV();
            BLL.PagoBLL.Instance.SanearSistemaIDV();
            BLL.SegmentoBLL.Instance.SanearSistemaIDV();
            BLL.ReservasBLL.Instance.SanearSistemaIDV();

            MessageBox.Show("Los digitos verificadores fueron recalculados y el sistema ya se encuentra operativo nuevamente. Se reiniciara la sesion.");

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario recalculo los digitos verificadores y el sistema se encuentra operativo.";
            evento.CRITICIDAD = Enumerador.Criticidad.Critica.ToString();
            evento.OPERACION = Enumerador.Operacion.Modificar.ToString();
            evento.MODULO = Enumerador.Modulo.RecuperarSistema.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            this.Close();
            formHome.necesitaReiniciar = true;
            formHome.cerrarSesion();
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

        private void FormRecuperarSistema_Load(object sender, EventArgs e)
        {
            TraducirComponentes();

            btn_bd.Enabled = true;
            btn_recalcular.Enabled = true;
            btn_salir.Enabled = true;

            if (Services.ServiceSesion.Instance.USER.PERFIL.DESCRIPCION.Trim().Equals("Propietario".Trim()))
            {
                btn_bd.Enabled = false;
                btn_recalcular.Enabled = false;
            }
            else
            {
                BE.Evento evento = new Evento();
                evento.USUARIO = Services.ServiceSesion.Instance.USER;
                evento.DETALLE = "El usuario ingresó a la pantalla de recuperación del sistema.";
                evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
                evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
                evento.MODULO = Enumerador.Modulo.RecuperarSistema.ToString();

                BLL.EventoBLL.Instance.AgregarEvento(evento);
            }
        }
    }
}
