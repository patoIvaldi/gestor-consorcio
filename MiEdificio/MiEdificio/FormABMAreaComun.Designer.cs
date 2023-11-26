namespace UI
{
    partial class FormABMAreaComun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABMAreaComun));
            groupBox1 = new GroupBox();
            btn_limpiar = new Button();
            btn_guardar = new Button();
            cb_habilitada = new CheckBox();
            uc_descripcion = new UC_textbox();
            uc_nombre = new UC_textbox();
            dgv_areas = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_areas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_limpiar);
            groupBox1.Controls.Add(btn_guardar);
            groupBox1.Controls.Add(cb_habilitada);
            groupBox1.Controls.Add(uc_descripcion);
            groupBox1.Controls.Add(uc_nombre);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(414, 137);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(252, 96);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 29);
            btn_limpiar.TabIndex = 4;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(333, 96);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(75, 29);
            btn_guardar.TabIndex = 3;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // cb_habilitada
            // 
            cb_habilitada.AutoSize = true;
            cb_habilitada.Checked = true;
            cb_habilitada.CheckState = CheckState.Checked;
            cb_habilitada.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cb_habilitada.Location = new Point(11, 74);
            cb_habilitada.Name = "cb_habilitada";
            cb_habilitada.Size = new Size(115, 19);
            cb_habilitada.TabIndex = 2;
            cb_habilitada.Text = "¿Area habilitada?";
            cb_habilitada.UseVisualStyleBackColor = true;
            // 
            // uc_descripcion
            // 
            uc_descripcion.ETIQUETA = "Descripción:";
            uc_descripcion.Location = new Point(213, 22);
            uc_descripcion.MAX_LENGTH = 1000;
            uc_descripcion.Name = "uc_descripcion";
            uc_descripcion.REQUERIDO = false;
            uc_descripcion.Size = new Size(182, 46);
            uc_descripcion.TabIndex = 1;
            uc_descripcion.TEXT_BOX = "";
            // 
            // uc_nombre
            // 
            uc_nombre.ETIQUETA = "Nombre:";
            uc_nombre.Location = new Point(6, 22);
            uc_nombre.MAX_LENGTH = 100;
            uc_nombre.Name = "uc_nombre";
            uc_nombre.REQUERIDO = true;
            uc_nombre.Size = new Size(176, 46);
            uc_nombre.TabIndex = 0;
            uc_nombre.TEXT_BOX = "";
            // 
            // dgv_areas
            // 
            dgv_areas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_areas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_areas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_areas.Location = new Point(12, 154);
            dgv_areas.MultiSelect = false;
            dgv_areas.Name = "dgv_areas";
            dgv_areas.ReadOnly = true;
            dgv_areas.RowTemplate.Height = 25;
            dgv_areas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_areas.Size = new Size(414, 150);
            dgv_areas.TabIndex = 1;
            dgv_areas.CellClick += dgv_areas_CellClick;
            // 
            // FormABMAreaComun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(438, 316);
            Controls.Add(dgv_areas);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormABMAreaComun";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Alta Area Comun";
            Load += FormABMAreaComun_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_areas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private UC_textbox uc_descripcion;
        private UC_textbox uc_nombre;
        private CheckBox cb_habilitada;
        private Button btn_limpiar;
        private Button btn_guardar;
        private DataGridView dgv_areas;
    }
}