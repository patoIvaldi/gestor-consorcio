namespace UI
{
    partial class FormIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIdioma));
            groupBox1 = new GroupBox();
            btn_borrar = new Button();
            btn_limpiar = new Button();
            btn_guardar = new Button();
            cb_porDefecto = new CheckBox();
            uc_tb_descripcion = new UC_textbox();
            uc_tb_id = new UC_textbox();
            dgv_idiomas = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_idiomas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_borrar);
            groupBox1.Controls.Add(btn_limpiar);
            groupBox1.Controls.Add(btn_guardar);
            groupBox1.Controls.Add(cb_porDefecto);
            groupBox1.Controls.Add(uc_tb_descripcion);
            groupBox1.Controls.Add(uc_tb_id);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 131);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btn_borrar
            // 
            btn_borrar.Location = new Point(6, 98);
            btn_borrar.Name = "btn_borrar";
            btn_borrar.Size = new Size(74, 27);
            btn_borrar.TabIndex = 5;
            btn_borrar.Text = "Borrar";
            btn_borrar.UseVisualStyleBackColor = true;
            btn_borrar.Click += btn_borrar_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(237, 98);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(74, 27);
            btn_limpiar.TabIndex = 4;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(317, 98);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(74, 27);
            btn_guardar.TabIndex = 3;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // cb_porDefecto
            // 
            cb_porDefecto.AutoSize = true;
            cb_porDefecto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            cb_porDefecto.Location = new Point(10, 61);
            cb_porDefecto.Name = "cb_porDefecto";
            cb_porDefecto.Size = new Size(152, 19);
            cb_porDefecto.TabIndex = 2;
            cb_porDefecto.Text = "¿Es idioma por defecto?";
            cb_porDefecto.UseVisualStyleBackColor = true;
            // 
            // uc_tb_descripcion
            // 
            uc_tb_descripcion.ETIQUETA = "Descripción:";
            uc_tb_descripcion.Location = new Point(189, 12);
            uc_tb_descripcion.MAX_LENGTH = 20;
            uc_tb_descripcion.Name = "uc_tb_descripcion";
            uc_tb_descripcion.REQUERIDO = true;
            uc_tb_descripcion.Size = new Size(176, 46);
            uc_tb_descripcion.TabIndex = 1;
            uc_tb_descripcion.TEXT_BOX = "";
            // 
            // uc_tb_id
            // 
            uc_tb_id.ETIQUETA = "ID:";
            uc_tb_id.Location = new Point(6, 12);
            uc_tb_id.MAX_LENGTH = 2;
            uc_tb_id.Name = "uc_tb_id";
            uc_tb_id.REQUERIDO = true;
            uc_tb_id.Size = new Size(177, 46);
            uc_tb_id.TabIndex = 0;
            uc_tb_id.TEXT_BOX = "";
            // 
            // dgv_idiomas
            // 
            dgv_idiomas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_idiomas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_idiomas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_idiomas.Location = new Point(12, 140);
            dgv_idiomas.MultiSelect = false;
            dgv_idiomas.Name = "dgv_idiomas";
            dgv_idiomas.ReadOnly = true;
            dgv_idiomas.RowTemplate.Height = 25;
            dgv_idiomas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_idiomas.Size = new Size(397, 150);
            dgv_idiomas.TabIndex = 0;
            dgv_idiomas.CellClick += dgv_idiomas_CellClick;
            // 
            // FormIdioma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(419, 305);
            Controls.Add(dgv_idiomas);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormIdioma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Idiomas";
            Load += FormIdioma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_idiomas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_borrar;
        private Button btn_limpiar;
        private Button btn_guardar;
        private CheckBox cb_porDefecto;
        private UC_textbox uc_tb_descripcion;
        private UC_textbox uc_tb_id;
        private DataGridView dgv_idiomas;
    }
}