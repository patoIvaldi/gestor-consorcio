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
    public partial class FormABMAreaComun : Form
    {
        public FormABMAreaComun()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                BE.AreaComun areaGenerada = new AreaComun();
                areaGenerada.NOMBRE = uc_nombre.TEXT_BOX;
                areaGenerada.DESCRIPCION = uc_descripcion.TEXT_BOX;
                areaGenerada.ES_AREA_HABILITADA = cb_habilitada.Checked;

                if (BLL.AreaComunBLL.Instance.AgregarArea(areaGenerada))
                {
                    BE.Evento evento = new Evento();
                    evento.USUARIO = Services.ServiceSesion.Instance.USER;
                    evento.DETALLE = "El usuario generó/modificó un area comun.";
                    evento.CRITICIDAD = Enumerador.Criticidad.Media.ToString();
                    evento.OPERACION = Enumerador.Operacion.Insertar.ToString();
                    evento.MODULO = Enumerador.Modulo.ABMAreaComun.ToString();

                    BLL.EventoBLL.Instance.AgregarEvento(evento);

                    enlazarAreas();
                    limpiar();
                    MessageBox.Show("Area comun creado/Modificado con éxito.");
                }
                else
                {
                    MessageBox.Show("Hubo un error al querer crear/modificar el area comun.");
                }
            }
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControles()
        {
            Boolean validacionOK = true;

            foreach (Control c in groupBox1.Controls)
            {
                //itero hasta encontrar alguno incorrecto
                if (validacionOK)
                {
                    if (c is UC_textbox)
                    {
                        validacionOK = ((UC_textbox)c).validar();
                    }
                }
            }
            return validacionOK;
        }

        private void enlazarAreas()
        {
            dgv_areas.DataSource = null;
            dgv_areas.DataSource = BLL.AreaComunBLL.Instance.ListarAreas();
        }

        private void FormABMAreaComun_Load(object sender, EventArgs e)
        {

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de ABMAreaComun.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.ABMAreaComun.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            TraducirComponentes();
            enlazarAreas();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            enlazarAreas();
        }

        private void limpiar()
        {
            uc_nombre.TEXT_BOX = "";
            uc_descripcion.TEXT_BOX = "";
            cb_habilitada.Checked = true;
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

        private void dgv_areas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BE.AreaComun areaSelected = (BE.AreaComun)dgv_areas.Rows[e.RowIndex].DataBoundItem;

            if (areaSelected is not null)
            {
                uc_nombre.TEXT_BOX = areaSelected.NOMBRE;
                uc_descripcion.TEXT_BOX = areaSelected.DESCRIPCION;
                cb_habilitada.Checked = areaSelected.ES_AREA_HABILITADA;
            }
        }
    }
}
