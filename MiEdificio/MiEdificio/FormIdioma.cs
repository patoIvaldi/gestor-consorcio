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
            enlazar();
        }

        //logica boton guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (BLL.IdiomaBLL.INSTANCE.Agregar(armarIdioma()))
                {
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
        }

        //logica boton borrar
        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (BLL.IdiomaBLL.INSTANCE.Borrar(armarIdioma()))
                {
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
    }
}
