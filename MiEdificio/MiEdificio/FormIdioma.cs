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
    public partial class FormIdioma : Form
    {
        public FormIdioma()
        {
            InitializeComponent();
        }

        private void FormIdioma_Load(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de ABMIdiomas.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.ABMIdioma.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            TraducirComponentes();
            enlazar();
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

        //logica boton guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (BLL.IdiomaBLL.INSTANCE.Agregar(armarIdioma()))
                {
                    BE.Evento evento = new Evento();
                    evento.USUARIO = Services.ServiceSesion.Instance.USER;
                    evento.DETALLE = "El usuario generó/modificó un idioma.";
                    evento.CRITICIDAD = Enumerador.Criticidad.Media.ToString();
                    evento.OPERACION = Enumerador.Operacion.Insertar.ToString();
                    evento.MODULO = Enumerador.Modulo.ABMIdioma.ToString();

                    BLL.EventoBLL.Instance.AgregarEvento(evento);

                    enlazar();
                    limpiar();
                    MessageBox.Show("Idioma creado/Modificado con éxito.");
                }
                else
                {
                    MessageBox.Show("Hubo un error al querer crear/modificar el idioma.");
                }
            }
        }

        private Services.ServiceIdioma armarIdioma()
        {
            Services.ServiceIdioma idiomaNew = new Services.ServiceIdioma();
            idiomaNew.ID = uc_tb_id.TEXT_BOX.Trim().ToUpper();
            idiomaNew.DESCRIPCION = uc_tb_descripcion.TEXT_BOX;
            idiomaNew.ES_ESTANDAR = cb_porDefecto.Checked;

            return idiomaNew;
        }

        //logica boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            enlazar();
        }

        //logica boton borrar
        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (BLL.IdiomaBLL.INSTANCE.Borrar(armarIdioma()))
                {
                    BE.Evento evento = new Evento();
                    evento.USUARIO = Services.ServiceSesion.Instance.USER;
                    evento.DETALLE = "El usuario borró el idioma: "+ uc_tb_descripcion.TEXT_BOX;
                    evento.CRITICIDAD = Enumerador.Criticidad.Critica.ToString();
                    evento.OPERACION = Enumerador.Operacion.Eliminar.ToString();
                    evento.MODULO = Enumerador.Modulo.ABMIdioma.ToString();

                    BLL.EventoBLL.Instance.AgregarEvento(evento);

                    enlazar();
                    limpiar();
                    MessageBox.Show("Idioma borrado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se pudo borrar el idioma.");
                }
            }
        }

        //enlazamos el datagrid
        private void enlazar()
        {
            dgv_idiomas.DataSource = null;
            dgv_idiomas.DataSource = BLL.IdiomaBLL.INSTANCE.Listar();
        }

        //limpiar campos
        private void limpiar()
        {
            uc_tb_id.TEXT_BOX = "";
            uc_tb_descripcion.TEXT_BOX = "";
            cb_porDefecto.Checked = false;
            uc_tb_id.Enabled = true;
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

        //cargo los textbox cuando usuario hace clic en un registro
        private void dgv_idiomas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Services.ServiceIdioma idiomaSelected = (Services.ServiceIdioma)dgv_idiomas.Rows[e.RowIndex].DataBoundItem;

            if (idiomaSelected is not null)
            {
                uc_tb_id.TEXT_BOX = idiomaSelected.ID;
                uc_tb_descripcion.TEXT_BOX = idiomaSelected.DESCRIPCION;
                cb_porDefecto.Checked = idiomaSelected.ES_ESTANDAR;
                uc_tb_id.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
