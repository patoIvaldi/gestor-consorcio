using BLL;
using Microsoft.IdentityModel.Tokens;
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
        private List<BE.Expensa> expensasSelected = new List<BE.Expensa>();
        private BE.Persona personaSelected;
        private BE.Pago pagoSelected;
        float total;

        public FormPagarExpensas(int numMenu)
        {
            this.numMenu = numMenu;
            InitializeComponent();
        }

        private void FormPagarExpensas_Load(object sender, EventArgs e)
        {
            btn_imprimir.Enabled = false;
            btn_imprimirExpensa.Enabled = false;
            btn_pagar.Enabled = false;

            if (this.numMenu == 2)
            {
                this.Text = "MiEdificio - Visualizar Documentos";
                btn_imprimir.Enabled = true;
                btn_imprimirExpensa.Enabled = true;
                dgv_expensas.MultiSelect = false;
                lbl_monto.Visible = false;
                lbl_saldoImpago_txt.Visible = false;
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
            personaSelected = (BE.Persona)dgv_propietarios.Rows[e.RowIndex].DataBoundItem;

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
            total = 0;
            expensasSelected = new List<BE.Expensa>();
            btn_pagar.Enabled = false;
            btn_imprimirExpensa.Enabled = false;

            foreach (DataGridViewRow row in dgv_expensas.SelectedRows)
            {
                if (this.numMenu != 2)
                {
                    //si esta paga, no la tengo en cuenta
                    if (!((BE.Expensa)row.DataBoundItem).ESTA_PAGA)
                    {
                        btn_pagar.Enabled = true;
                        expensasSelected.Add((BE.Expensa)row.DataBoundItem);
                        total += Convert.ToSingle(row.Cells["monto"].Value);
                    }
                }
                else
                {
                    btn_imprimirExpensa.Enabled = true;
                    expensasSelected.Add((BE.Expensa)row.DataBoundItem);
                }

            }

            lbl_monto.Text = convertirAMonedad(total);
        }

        private string convertirAMonedad(float valor)
        {
            decimal valorDecimal = Convert.ToDecimal(valor);

            CultureInfo cultureInfo = new CultureInfo("es-AR");

            return valorDecimal.ToString("C", cultureInfo);

        }

        public void refrescarDGVExpensasPagos()
        {
            enlazarPagos(personaSelected);
            enlazarExpensas(personaSelected);
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            if (!expensasSelected.IsNullOrEmpty())
            {
                FormRealizarPago doPago = new FormRealizarPago(expensasSelected,
                    total, this);

                doPago.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar alguna expensa impaga.");
            }
        }

        //logica boton imprimir detalle expensa
        private void btn_imprimirExpensa_Click(object sender, EventArgs e)
        {
            if (!expensasSelected.IsNullOrEmpty())
            {
                BE.Expensa expImprimir = (BE.Expensa)expensasSelected.First();

                StringBuilder sb = new StringBuilder();
                sb.Append("Fecha/Hora actual: " + DateTime.Now);
                sb.Append("\n");
                sb.Append(DetallePersonaTXT());
                sb.Append("\n");
                sb.Append(DetalleExpensasTXT(expImprimir));
                sb.Append("\n");
                sb.Append("\n-------------------------------");
                sb.Append("\n SEGMENTOS COBRADOS:");
                sb.Append("\n-------------------------------");

                List<BE.Segmento> segmentos = SegmentoBLL.Instance.obtenerSegmentosExpensa(
                    expImprimir.ID);

                foreach (BE.Segmento s in segmentos)
                {
                    sb.Append(DetalleSegmentoTXT(s));
                }
                sb.Append("\n");
                sb.Append("\n ----- Powered by CEIBA, Buenos Aires, Argentina. -----");
                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show("Debe seleccionar una expensa.");
            }
        }

        private StringBuilder DetalleExpensasTXT(BE.Expensa expImprimir)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n-------------------------------");
            sb.Append("\n Detalle de la expensa: " + expImprimir.ID + " para el periodo: " + expImprimir.PERIODO);
            sb.Append("\n-------------------------------");
            sb.Append("\n Monto: " + convertirAMonedad(expImprimir.MONTO) + " - estado: ");
            if (expImprimir.ESTA_PAGA)
            {
                sb.Append("PAGA");
            }
            else
            {
                sb.Append("IMPAGA");
            }
            sb.Append("\n Fecha emisión: " + expImprimir.FECHA_EMISION);
            sb.Append("\n Fecha 1er vencimiento: " + expImprimir.DTTM_1ER_VENCIMIENTO);
            sb.Append("\n Fecha 2do vencimiento: " + expImprimir.DTTM_2DO_VENCIMIENTO);
            return sb;
        }

        private StringBuilder DetallePersonaTXT()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n-------------------------------");
            sb.Append("\n Detalle de la persona");
            sb.Append("\n-------------------------------");
            sb.Append("\n DNI: " + personaSelected.DNI);
            sb.Append("\n Apellido y Nombre: " + personaSelected.APELLIDO + ", " + personaSelected.NOMBRE);
            sb.Append("\n Edad: " + personaSelected.EDAD + " años.");
            sb.Append("\n-------------------------------");

            return sb;
        }

        private StringBuilder DetalleSegmentoTXT(BE.Segmento seg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n Segmento ID: " + seg.ID + " - Descripción: " + seg.DESCRIPCION);
            sb.Append("\n Monto: " + convertirAMonedad(seg.MONTO));
            sb.Append("\n-------------------------------");

            return sb;
        }

        //al seleccionar un pago
        private void dgv_pagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pagoSelected = (BE.Pago)dgv_pagos.Rows[e.RowIndex].DataBoundItem;
        }

        //logica del boton imprimir pago
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (pagoSelected is not null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Fecha/Hora actual: " + DateTime.Now);
                sb.Append("\n");
                sb.Append(DetallePersonaTXT());
                sb.Append("\n");
                sb.Append(DatosPagoTXT(pagoSelected));
                sb.Append("\n");

                List<BE.Expensa> expensasSaldadas = ExpensaBLL.Instance.BuscarPorIdPago(pagoSelected.ID);

                sb.Append("\n-------------------------------");
                sb.Append("\n Detalle expensas saldadas por el pago, total: " + expensasSaldadas.Count + " expensas.");
                sb.Append("\n-------------------------------");

                foreach (BE.Expensa eS in expensasSaldadas)
                {
                    sb.Append("\n expensa ID: " + eS.ID + " - Monto: " + convertirAMonedad(eS.MONTO));
                }

                sb.Append("\n");
                sb.Append("\n ----- Powered by CEIBA, Buenos Aires, Argentina. -----");
                MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show("Debe seleccionar un pago.");
            }
        }

        private StringBuilder DatosPagoTXT(BE.Pago p)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n-------------------------------");
            sb.Append("\n Detalle del Pago ID: " + p.ID + " - Monto: " + convertirAMonedad(p.MONTO));
            sb.Append("\n-------------------------------");
            sb.Append("\n Forma de pago: " + p.FORMA_PAGO);
            sb.Append("\n Fecha de ejecución: " + p.FECHA_EJECUCION);
            sb.Append("\n-------------------------------");
            return sb;
        }
    }
}
