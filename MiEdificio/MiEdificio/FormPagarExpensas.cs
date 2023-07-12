using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPagarExpensas : Form
    {

        private int numMenu = 0;

        public FormPagarExpensas(int numMenu)
        {
            this.numMenu = numMenu;
            InitializeComponent();
        }

        private void FormPagarExpensas_Load(object sender, EventArgs e)
        {
            if (this.numMenu == 2)
            {
                this.Text = "MiEdificio - Visualizar Documentos";
            }

            enlazarPropietarios();
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

        private void dgv_propietarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BE.Persona personaSelected = (BE.Persona)dgv_propietarios.Rows[e.RowIndex].DataBoundItem;

            if (personaSelected is not null)
            {
                enlazarExpensas(personaSelected);
                enlazarPagos(personaSelected);
            }
        }

        //enlazo las expensas de la persona
        private void enlazarExpensas(BE.Persona persona)
        {
            dgv_expensas.DataSource = null;
            dgv_expensas.DataSource = BLL.ExpensaBLL.Instance.ListarExpensas(persona.DNI);
            dgv_expensas.Columns["DNI"].Visible = false;
        }

        //enlazo los pagos de la persona
        private void enlazarPagos(BE.Persona persona)
        {
            dgv_pagos.DataSource = null;
            dgv_pagos.DataSource = BLL.PagoBLL.Instance.ListarPagos(persona.DNI);

            dgv_pagos.Columns["DNI"].Visible = false;
            dgv_pagos.Columns["COD_SEGURIDAD"].Visible = false;
            dgv_pagos.Columns["NRO_TARJETA"].Visible = false;
            dgv_pagos.Columns["FECHA_VENC_TARJETA"].Visible = false;
            dgv_pagos.Columns["NOMBRE_TARJETA"].Visible = false;
        }

        private void dgv_expensas_SelectionChanged(object sender, EventArgs e)
        {
            float total = 0;

            foreach (DataGridViewRow row in dgv_expensas.SelectedRows)
            {
                total += Convert.ToSingle(row.Cells["monto"].Value);
            }

            lbl_monto.Text = convertirAMonedad(total);
        }

        private string convertirAMonedad(float valor)
        {
            decimal valorDecimal = Convert.ToDecimal(valor);

            CultureInfo cultureInfo = new CultureInfo("es-AR");

            return valorDecimal.ToString("C", cultureInfo);

        }
    }
}
