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
    public partial class FormGenerarExpensa : Form
    {

        private BE.Persona personaSelected = null;
        private BE.Expensa expensaSelected = null;
        private List<BE.Segmento> nuevosSegmentos = new List<Segmento>();

        public FormGenerarExpensa()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //en la carga del formulario
        private void FormGenerarExpensa_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        //enlazo los propietarios
        private void enlazarPropietarios()
        {

            List<BE.Usuario> allUsers = BLL.UsuarioBLL.Instance.listarUsuarios();
            List<BE.Persona> propietarios = new List<BE.Persona>();

            foreach (BE.Usuario u in allUsers)
            {
                if (u.PERSONA is BE.Propietario)
                {
                    propietarios.Add(u.PERSONA);
                }
            }

            dgv_propietarios.DataSource = null;
            dgv_propietarios.DataSource = propietarios;
        }

        //enlazo las expensas de la persona
        private void enlazarExpensas(BE.Persona persona)
        {
            dgv_expensas.DataSource = null;
            dgv_expensas.DataSource = BLL.ExpensaBLL.Instance.ListarExpensas(persona.DNI);
        }

        //logica cuando el usuario selecciona un propietario
        private void dgv_propietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            personaSelected = (BE.Persona)dgv_propietarios.Rows[e.RowIndex].DataBoundItem;

            if (personaSelected is not null)
            {
                enlazarExpensas(personaSelected);
            }
        }

        //logica cuando el usuario selecciona una expensa
        private void dgv_expensas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            expensaSelected = (BE.Expensa)dgv_expensas.Rows[e.RowIndex].DataBoundItem;

            if (expensaSelected is not null)
            {
                enlazarDetalle(expensaSelected);
                grisarCampos();
            }
        }

        //enlazo el detalle de la expensa
        private void enlazarDetalle(BE.Expensa expensa)
        {
            dgv_detalle.DataSource = null;
            dgv_detalle.DataSource = BLL.SegmentoBLL.Instance.obtenerSegmentosExpensa(expensa.ID);
            uC_dttmFechaExpensa.VALOR = expensa.FECHA_EMISION;
        }

        //bloqueo los campos y botones
        private void grisarCampos()
        {
            uC_tb_descSegmento.Enabled = false;
            uC_tb_importeSegmento.Enabled = false;
            btn_agregarSeg.Enabled = false;
            btn_generarExp.Enabled = false;
            uC_dttmFechaExpensa.Enabled = false;
        }

        //logica del boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            uC_tb_descSegmento.Enabled = true;
            uC_tb_descSegmento.TEXT_BOX = "";
            uC_tb_importeSegmento.Enabled = true;
            uC_tb_importeSegmento.TEXT_BOX = "";
            btn_agregarSeg.Enabled = true;
            btn_generarExp.Enabled = true;
            uC_dttmFechaExpensa.Enabled = true;
            uC_dttmFechaExpensa.resetear();
            nuevosSegmentos.Clear();
            personaSelected = null;
            expensaSelected = null;

            dgv_detalle.DataSource = null;
            dgv_expensas.DataSource = null;
            enlazarPropietarios();
        }

        //logica boton agregar segmento
        private void btn_agregarSeg_Click(object sender, EventArgs e)
        {
            if (personaSelected is not null)
            {
                if (validarControles())
                {
                    agregarNuevoSegmento();
                }
                else
                {
                    MessageBox.Show("Error, complete todos los campos requeridos.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el propietario al que quiere generarle la expensa.");
            }
        }

        //creamos el nuevo segmento
        private void agregarNuevoSegmento()
        {
            BE.Segmento seg = new BE.Segmento();
            seg.DESCRIPCION = uC_tb_descSegmento.TEXT_BOX;
            seg.MONTO = int.Parse(uC_tb_importeSegmento.TEXT_BOX);
            nuevosSegmentos.Add(seg);

            dgv_detalle.DataSource = null;
            dgv_detalle.DataSource = nuevosSegmentos;

            //limpiamos
            uC_tb_descSegmento.TEXT_BOX = "";
            uC_tb_importeSegmento.TEXT_BOX = "";
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControles()
        {
            Boolean validacionOK = true;

            foreach (Control c in groupBox3.Controls)
            {
                //itero hasta encontrar alguno incorrecto
                if (validacionOK)
                {
                    if (c is UC_textbox)
                    {
                        validacionOK = ((UC_textbox)c).validar();

                    }
                    else if (c is UC_tb_numerico)
                    {
                        validacionOK = ((UC_tb_numerico)c).validar();
                    }
                }
            }
            return validacionOK;
        }

        //logica boton generar expensa
        private void btn_generarExp_Click(object sender, EventArgs e)
        {
            if (expensaSelected is null)
            {
                if (personaSelected is not null)
                {
                    if (nuevosSegmentos.Count > 0)
                    {
                        generarExpensa();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error, genere al menos 1 segmento nuevo para la expensa.");
                    }
                }
                else
                {
                    MessageBox.Show("Error, seleccione el propietario al que quiere generarle la expensa.");
                }
            }
            else
            {
                MessageBox.Show("Error, no puede generar una nueva expensa porque tiene una seleccionada. Haga clic en el boton limpiar.");
            }
        }

        //logica para la generacion de la expensa
        private void generarExpensa()
        {
            BE.Expensa newExpensa = new BE.Expensa(uC_dttmFechaExpensa.VALOR);
            newExpensa.ESTA_PAGA = false;
            newExpensa.DNI = personaSelected.DNI;
            newExpensa.agregarSegmentos(nuevosSegmentos);

            if (!BLL.ExpensaBLL.Instance.ExisteExpensaParaElPeriodo(newExpensa))
            {
                Boolean exitoso = BLL.ExpensaBLL.Instance.GenerarExpensa(newExpensa);

                if (exitoso)
                {
                    MessageBox.Show("Expensa generada con exito para el propietario: " + personaSelected.ToString());
                }
                else
                {
                    MessageBox.Show("Se produjo un error al generar la expensa.");
                }
            }
            else
            {
                MessageBox.Show("La persona: " + personaSelected.ToString() +
                    " ya posee una expensa para el periodo: " + newExpensa.PERIODO +
                    ". Por favor, genere otra con un mes distinto.");
            }

        }
    }
}
