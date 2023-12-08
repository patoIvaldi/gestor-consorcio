﻿namespace UI
{
    partial class FormReporteCantReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteCantReservas));
            groupBox1 = new GroupBox();
            btn_deserializar = new Button();
            btn_serializar = new Button();
            cb_orden = new ComboBox();
            groupBox2 = new GroupBox();
            dgv_cantReservas = new DataGridView();
            tb_buscar = new TextBox();
            label1 = new Label();
            btn_buscar = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_cantReservas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_buscar);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tb_buscar);
            groupBox1.Controls.Add(btn_deserializar);
            groupBox1.Controls.Add(btn_serializar);
            groupBox1.Controls.Add(cb_orden);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 209);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenar:";
            // 
            // btn_deserializar
            // 
            btn_deserializar.Enabled = false;
            btn_deserializar.Location = new Point(97, 161);
            btn_deserializar.Name = "btn_deserializar";
            btn_deserializar.Size = new Size(152, 33);
            btn_deserializar.TabIndex = 2;
            btn_deserializar.Text = "Deserializar";
            btn_deserializar.UseVisualStyleBackColor = true;
            btn_deserializar.Click += btn_deserializar_Click;
            // 
            // btn_serializar
            // 
            btn_serializar.Location = new Point(183, 22);
            btn_serializar.Name = "btn_serializar";
            btn_serializar.Size = new Size(152, 50);
            btn_serializar.TabIndex = 1;
            btn_serializar.Text = "Serializar datos del DGV en XML";
            btn_serializar.UseVisualStyleBackColor = true;
            btn_serializar.Click += btn_serializar_Click;
            // 
            // cb_orden
            // 
            cb_orden.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            cb_orden.FormattingEnabled = true;
            cb_orden.Location = new Point(10, 33);
            cb_orden.Name = "cb_orden";
            cb_orden.Size = new Size(154, 23);
            cb_orden.TabIndex = 0;
            cb_orden.Text = "Elegir...";
            cb_orden.SelectedIndexChanged += cb_orden_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_cantReservas);
            groupBox2.Location = new Point(12, 227);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 257);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cantidad de reservas por usuario:";
            // 
            // dgv_cantReservas
            // 
            dgv_cantReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_cantReservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_cantReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cantReservas.Location = new Point(6, 22);
            dgv_cantReservas.MultiSelect = false;
            dgv_cantReservas.Name = "dgv_cantReservas";
            dgv_cantReservas.ReadOnly = true;
            dgv_cantReservas.RowTemplate.Height = 25;
            dgv_cantReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_cantReservas.Size = new Size(340, 226);
            dgv_cantReservas.TabIndex = 0;
            // 
            // tb_buscar
            // 
            tb_buscar.Enabled = false;
            tb_buscar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            tb_buscar.Location = new Point(6, 123);
            tb_buscar.Name = "tb_buscar";
            tb_buscar.Size = new Size(261, 23);
            tb_buscar.TabIndex = 3;
            tb_buscar.Text = " ...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 105);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 4;
            label1.Text = "Buscar archivo a deserializar:";
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(271, 122);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(75, 23);
            btn_buscar.TabIndex = 5;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormReporteCantReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(376, 496);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormReporteCantReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Cantidad de reservas por usuario";
            Load += FormReporteCantReservas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_cantReservas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgv_cantReservas;
        private ComboBox cb_orden;
        private Button btn_deserializar;
        private Button btn_serializar;
        private Button btn_buscar;
        private Label label1;
        private TextBox tb_buscar;
        private OpenFileDialog openFileDialog1;
    }
}