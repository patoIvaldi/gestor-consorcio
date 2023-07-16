using BLL;
using Microsoft.IdentityModel.Tokens;
using MiEdificio;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UI
{
    public partial class FormRealizarPago : Form
    {

        FormPagarExpensas formAnt;
        List<BE.Expensa> expensasAPagar;
        float montoInformado;

        public FormRealizarPago(List<BE.Expensa> expensasSelected,
            float montoTotal, FormPagarExpensas formAnterior)
        {
            //this.Owner = FormHome;
            this.formAnt = formAnterior;
            this.expensasAPagar = expensasSelected;
            this.montoInformado = montoTotal;

            InitializeComponent();
        }

        private void FormRealizarPago_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            uC_dttm_vencimiento.resetear();

            this.lbl_total.Text = "Total: " + convertirAMonedad(this.montoInformado);
            this.lbl_cantExpensas.Text += this.expensasAPagar.Count();
        }

        private string convertirAMonedad(float valor)
        {
            decimal valorDecimal = Convert.ToDecimal(valor);

            CultureInfo cultureInfo = new CultureInfo("es-AR");

            return valorDecimal.ToString("C", cultureInfo);

        }

        private void cargarComboBox()
        {
            cb_formaPago.Items.Clear();
            cb_formaPago.Items.Add("Efectivo");
            cb_formaPago.Items.Add("Tarjeta de Crédito");
            cb_formaPago.Items.Add("Tarjeta de Débito");
        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {

            if (validarControles())
            {

                BE.Pago newPago = new BE.Pago();
                newPago.DNI = expensasAPagar.First().DNI;
                newPago.NOMBRE_TARJETA = uC_tb_nombreCompleto.TEXT_BOX;
                newPago.MONTO = this.montoInformado;
                newPago.FECHA_VENC_TARJETA = uC_dttm_vencimiento.VALOR;
                newPago.FECHA_EJECUCION = DateTime.Now;
                newPago.FORMA_PAGO = (string)cb_formaPago.SelectedItem;
                
                if (!uC_tb_nroTarjeta.TEXT_BOX.IsNullOrEmpty())
                {
                    newPago.NRO_TARJETA = Int64.Parse(uC_tb_nroTarjeta.TEXT_BOX);
                }
                
                if (!uC_tb_codSeguridad.TEXT_BOX.IsNullOrEmpty())
                {
                    newPago.COD_SEGURIDAD = int.Parse(uC_tb_codSeguridad.TEXT_BOX);
                }

                Boolean exitoso = PagoBLL.Instance.GenerarPago(newPago,expensasAPagar);

                if (exitoso)
                {
                    MessageBox.Show("Pago generado con éxito.");
                    this.Close();
                    formAnt.refrescarDGVExpensasPagos();
                    formAnt.Show();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo realizar el pago.");
                }
            }
            else
            {
                MessageBox.Show("Error, por la forma de pago elegida, debe completar todos los campos requeridos.");
            }
        }

        //bloqueo los campos segun la forma de pago elegida.
        private void cb_formaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fpElegida = (string)cb_formaPago.SelectedItem;

            if (!fpElegida.IsNullOrEmpty())
            {
                uC_tb_nombreCompleto.Enabled = true;
                uC_tb_nroTarjeta.Enabled = true;
                uC_tb_codSeguridad.Enabled = true;
                uC_dttm_vencimiento.Enabled = true;

                if (fpElegida.Equals("Efectivo"))
                {
                    uC_tb_nombreCompleto.Enabled = false;
                    uC_tb_nombreCompleto.TEXT_BOX = "";
                    uC_tb_nombreCompleto.REQUERIDO = false;
                    uC_tb_nroTarjeta.Enabled = false;
                    uC_tb_nroTarjeta.TEXT_BOX = "";
                    uC_tb_nroTarjeta.REQUERIDO = false;
                    uC_tb_codSeguridad.Enabled = false;
                    uC_tb_codSeguridad.REQUERIDO = false;
                    uC_tb_codSeguridad.TEXT_BOX = "";
                    uC_dttm_vencimiento.Enabled = false;
                    uC_dttm_vencimiento.REQUERIDO = false;
                    uC_dttm_vencimiento.resetear();
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
                    else if (c is UC_tb_numerico)
                    {
                        validacionOK = ((UC_tb_numerico)c).validar();

                    }else if(c is UC_dttmPicker){

                        validacionOK = ((UC_dttmPicker)c).validar();
                    }
                }
            }
            return validacionOK;
        }
    }
}
