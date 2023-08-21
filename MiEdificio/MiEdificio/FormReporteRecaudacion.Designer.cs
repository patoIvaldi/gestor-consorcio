namespace UI
{
    partial class FormReporteRecaudacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteRecaudacion));
            gb_recaudacion = new GroupBox();
            btn_imprimir = new Button();
            label1 = new Label();
            cb_orden = new ComboBox();
            dgv_recaudacion = new DataGridView();
            gb_recaudacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_recaudacion).BeginInit();
            SuspendLayout();
            // 
            // gb_recaudacion
            // 
            gb_recaudacion.Controls.Add(btn_imprimir);
            gb_recaudacion.Controls.Add(label1);
            gb_recaudacion.Controls.Add(cb_orden);
            gb_recaudacion.Controls.Add(dgv_recaudacion);
            gb_recaudacion.Location = new Point(12, 12);
            gb_recaudacion.Name = "gb_recaudacion";
            gb_recaudacion.Size = new Size(322, 348);
            gb_recaudacion.TabIndex = 0;
            gb_recaudacion.TabStop = false;
            gb_recaudacion.Text = "Recaudación por periodo:";
            // 
            // btn_imprimir
            // 
            btn_imprimir.Location = new Point(192, 301);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(79, 41);
            btn_imprimir.TabIndex = 3;
            btn_imprimir.Text = "Exportar PDF";
            btn_imprimir.UseVisualStyleBackColor = true;
            btn_imprimir.Click += btn_imprimir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 299);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 2;
            label1.Text = "Ordenar recaudación:";
            // 
            // cb_orden
            // 
            cb_orden.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            cb_orden.FormattingEnabled = true;
            cb_orden.Location = new Point(6, 319);
            cb_orden.Name = "cb_orden";
            cb_orden.Size = new Size(134, 23);
            cb_orden.TabIndex = 1;
            cb_orden.Text = "Elegir...";
            cb_orden.SelectedIndexChanged += cb_orden_SelectedIndexChanged;
            // 
            // dgv_recaudacion
            // 
            dgv_recaudacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_recaudacion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_recaudacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_recaudacion.Location = new Point(6, 22);
            dgv_recaudacion.MultiSelect = false;
            dgv_recaudacion.Name = "dgv_recaudacion";
            dgv_recaudacion.ReadOnly = true;
            dgv_recaudacion.RowTemplate.Height = 25;
            dgv_recaudacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_recaudacion.Size = new Size(310, 272);
            dgv_recaudacion.TabIndex = 0;
            dgv_recaudacion.CellClick += dgv_recaudacion_CellClick;
            // 
            // FormReporteRecaudacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(346, 372);
            Controls.Add(gb_recaudacion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormReporteRecaudacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Recaudación por período";
            Load += FormReporteRecaudacion_Load;
            gb_recaudacion.ResumeLayout(false);
            gb_recaudacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_recaudacion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_recaudacion;
        private Label label1;
        private ComboBox cb_orden;
        private DataGridView dgv_recaudacion;
        private Button btn_imprimir;
    }
}