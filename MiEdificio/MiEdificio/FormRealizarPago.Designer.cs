namespace UI
{
    partial class FormRealizarPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRealizarPago));
            groupBox1 = new GroupBox();
            uC_tb_codSeguridad = new UC_tb_numerico();
            uC_dttm_vencimiento = new UC_dttmPicker();
            uC_tb_nroTarjeta = new UC_tb_numerico();
            uC_tb_nombreCompleto = new UC_textbox();
            label1 = new Label();
            cb_formaPago = new ComboBox();
            btn_pagar = new Button();
            lbl_total = new Label();
            lbl_cantExpensas = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_tb_codSeguridad);
            groupBox1.Controls.Add(uC_dttm_vencimiento);
            groupBox1.Controls.Add(uC_tb_nroTarjeta);
            groupBox1.Controls.Add(uC_tb_nombreCompleto);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cb_formaPago);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(482, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del pago";
            // 
            // uC_tb_codSeguridad
            // 
            uC_tb_codSeguridad.ETIQUETA = "Código seguridad:";
            uC_tb_codSeguridad.Location = new Point(300, 105);
            uC_tb_codSeguridad.MAX_LENGTH = 3;
            uC_tb_codSeguridad.Name = "uC_tb_codSeguridad";
            uC_tb_codSeguridad.REQUERIDO = true;
            uC_tb_codSeguridad.Size = new Size(176, 46);
            uC_tb_codSeguridad.TabIndex = 5;
            uC_tb_codSeguridad.TEXT_BOX = "";
            // 
            // uC_dttm_vencimiento
            // 
            uC_dttm_vencimiento.ETIQUETA = "Fecha Venc:";
            uC_dttm_vencimiento.Location = new Point(188, 101);
            uC_dttm_vencimiento.Name = "uC_dttm_vencimiento";
            uC_dttm_vencimiento.REQUERIDO = true;
            uC_dttm_vencimiento.Size = new Size(105, 50);
            uC_dttm_vencimiento.TabIndex = 4;
            uC_dttm_vencimiento.VALOR = new DateTime(2023, 7, 13, 0, 0, 0, 0);
            // 
            // uC_tb_nroTarjeta
            // 
            uC_tb_nroTarjeta.ETIQUETA = "Nro Tarjeta:";
            uC_tb_nroTarjeta.Location = new Point(6, 105);
            uC_tb_nroTarjeta.MAX_LENGTH = 16;
            uC_tb_nroTarjeta.Name = "uC_tb_nroTarjeta";
            uC_tb_nroTarjeta.REQUERIDO = true;
            uC_tb_nroTarjeta.Size = new Size(176, 46);
            uC_tb_nroTarjeta.TabIndex = 3;
            uC_tb_nroTarjeta.TEXT_BOX = "";
            // 
            // uC_tb_nombreCompleto
            // 
            uC_tb_nombreCompleto.ETIQUETA = "Nombre completo:";
            uC_tb_nombreCompleto.Location = new Point(6, 61);
            uC_tb_nombreCompleto.MAX_LENGTH = 50;
            uC_tb_nombreCompleto.Name = "uC_tb_nombreCompleto";
            uC_tb_nombreCompleto.REQUERIDO = true;
            uC_tb_nombreCompleto.Size = new Size(176, 46);
            uC_tb_nombreCompleto.TabIndex = 2;
            uC_tb_nombreCompleto.TEXT_BOX = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(168, 18);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Forma de Pago:";
            // 
            // cb_formaPago
            // 
            cb_formaPago.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            cb_formaPago.ForeColor = Color.Gray;
            cb_formaPago.FormattingEnabled = true;
            cb_formaPago.Location = new Point(168, 36);
            cb_formaPago.Name = "cb_formaPago";
            cb_formaPago.Size = new Size(157, 23);
            cb_formaPago.TabIndex = 0;
            cb_formaPago.Text = "Seleccionar...";
            cb_formaPago.SelectedIndexChanged += cb_formaPago_SelectedIndexChanged;
            // 
            // btn_pagar
            // 
            btn_pagar.Location = new Point(190, 175);
            btn_pagar.Name = "btn_pagar";
            btn_pagar.Size = new Size(105, 30);
            btn_pagar.TabIndex = 1;
            btn_pagar.Text = "Pagar";
            btn_pagar.UseVisualStyleBackColor = true;
            btn_pagar.Click += btn_pagar_Click;
            // 
            // lbl_total
            // 
            lbl_total.AutoSize = true;
            lbl_total.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_total.Location = new Point(360, 179);
            lbl_total.Name = "lbl_total";
            lbl_total.Size = new Size(46, 20);
            lbl_total.TabIndex = 2;
            lbl_total.Text = "Total:";
            // 
            // lbl_cantExpensas
            // 
            lbl_cantExpensas.AutoSize = true;
            lbl_cantExpensas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_cantExpensas.Location = new Point(12, 174);
            lbl_cantExpensas.Name = "lbl_cantExpensas";
            lbl_cantExpensas.Size = new Size(103, 30);
            lbl_cantExpensas.TabIndex = 3;
            lbl_cantExpensas.Text = "Cantidad\r\nexpensas a pagar: ";
            // 
            // FormRealizarPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(507, 217);
            Controls.Add(lbl_cantExpensas);
            Controls.Add(lbl_total);
            Controls.Add(btn_pagar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormRealizarPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Datos del Pago";
            Load += FormRealizarPago_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private UC_tb_numerico uC_tb_codSeguridad;
        private UC_dttmPicker uC_dttm_vencimiento;
        private UC_tb_numerico uC_tb_nroTarjeta;
        private UC_textbox uC_tb_nombreCompleto;
        private Label label1;
        private ComboBox cb_formaPago;
        private Button btn_pagar;
        private Label lbl_total;
        private Label lbl_cantExpensas;
    }
}