namespace UI
{
    partial class FormPagarExpensas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPagarExpensas));
            groupBox1 = new GroupBox();
            dgv_propietarios = new DataGridView();
            groupBox2 = new GroupBox();
            dgv_pagos = new DataGridView();
            groupBox3 = new GroupBox();
            dgv_expensas = new DataGridView();
            btn_pagar = new Button();
            lbl_monto = new Label();
            btn_imprimir = new Button();
            lbl_saldoImpago_txt = new Label();
            btn_imprimirExpensa = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_propietarios).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_pagos).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_expensas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_propietarios);
            groupBox1.Location = new Point(699, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 216);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Propietarios:";
            // 
            // dgv_propietarios
            // 
            dgv_propietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_propietarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_propietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_propietarios.Location = new Point(6, 22);
            dgv_propietarios.MultiSelect = false;
            dgv_propietarios.Name = "dgv_propietarios";
            dgv_propietarios.ReadOnly = true;
            dgv_propietarios.RowTemplate.Height = 25;
            dgv_propietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_propietarios.Size = new Size(461, 185);
            dgv_propietarios.TabIndex = 0;
            dgv_propietarios.CellClick += dgv_propietarios_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_pagos);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(681, 216);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pagos:";
            // 
            // dgv_pagos
            // 
            dgv_pagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_pagos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_pagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_pagos.Location = new Point(6, 22);
            dgv_pagos.MultiSelect = false;
            dgv_pagos.Name = "dgv_pagos";
            dgv_pagos.ReadOnly = true;
            dgv_pagos.RowTemplate.Height = 25;
            dgv_pagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_pagos.Size = new Size(669, 185);
            dgv_pagos.TabIndex = 0;
            dgv_pagos.CellClick += dgv_pagos_CellClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgv_expensas);
            groupBox3.Location = new Point(12, 275);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1160, 257);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Expensas:";
            // 
            // dgv_expensas
            // 
            dgv_expensas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_expensas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_expensas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_expensas.Location = new Point(6, 22);
            dgv_expensas.Name = "dgv_expensas";
            dgv_expensas.ReadOnly = true;
            dgv_expensas.RowTemplate.Height = 25;
            dgv_expensas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_expensas.Size = new Size(1148, 229);
            dgv_expensas.TabIndex = 0;
            dgv_expensas.SelectionChanged += dgv_expensas_SelectionChanged;
            // 
            // btn_pagar
            // 
            btn_pagar.Location = new Point(18, 538);
            btn_pagar.Name = "btn_pagar";
            btn_pagar.Size = new Size(105, 35);
            btn_pagar.TabIndex = 3;
            btn_pagar.Text = "Pagar";
            btn_pagar.UseVisualStyleBackColor = true;
            btn_pagar.Click += btn_pagar_Click;
            // 
            // lbl_monto
            // 
            lbl_monto.AutoSize = true;
            lbl_monto.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_monto.Location = new Point(268, 541);
            lbl_monto.Name = "lbl_monto";
            lbl_monto.Size = new Size(0, 30);
            lbl_monto.TabIndex = 5;
            // 
            // btn_imprimir
            // 
            btn_imprimir.Location = new Point(18, 234);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(105, 35);
            btn_imprimir.TabIndex = 6;
            btn_imprimir.Text = "Imprimir Pago";
            btn_imprimir.UseVisualStyleBackColor = true;
            btn_imprimir.Click += btn_imprimir_Click;
            // 
            // lbl_saldoImpago_txt
            // 
            lbl_saldoImpago_txt.AutoSize = true;
            lbl_saldoImpago_txt.Location = new Point(129, 548);
            lbl_saldoImpago_txt.Name = "lbl_saldoImpago_txt";
            lbl_saldoImpago_txt.Size = new Size(83, 15);
            lbl_saldoImpago_txt.TabIndex = 7;
            lbl_saldoImpago_txt.Text = "Saldo impago:";
            // 
            // btn_imprimirExpensa
            // 
            btn_imprimirExpensa.Location = new Point(1041, 535);
            btn_imprimirExpensa.Name = "btn_imprimirExpensa";
            btn_imprimirExpensa.Size = new Size(105, 48);
            btn_imprimirExpensa.TabIndex = 8;
            btn_imprimirExpensa.Text = "Imprimir detalle expensa";
            btn_imprimirExpensa.UseVisualStyleBackColor = true;
            btn_imprimirExpensa.Click += btn_imprimirExpensa_Click;
            // 
            // FormPagarExpensas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(1184, 585);
            Controls.Add(btn_imprimirExpensa);
            Controls.Add(lbl_saldoImpago_txt);
            Controls.Add(btn_imprimir);
            Controls.Add(groupBox1);
            Controls.Add(lbl_monto);
            Controls.Add(btn_pagar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormPagarExpensas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Pagar expensas";
            Load += FormPagarExpensas_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_propietarios).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_pagos).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_expensas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_propietarios;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btn_pagar;
        private Label lbl_monto;
        private Button btn_imprimir;
        private DataGridView dgv_pagos;
        private DataGridView dgv_expensas;
        private Label lbl_saldoImpago_txt;
        private Button btn_imprimirExpensa;
    }
}