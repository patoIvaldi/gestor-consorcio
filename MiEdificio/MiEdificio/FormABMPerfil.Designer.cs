namespace UI
{
    partial class FormABMPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABMPerfil));
            gb_perfil = new GroupBox();
            btn_borrarPerfil = new Button();
            btn_limpiarPerfil = new Button();
            btn_guardarPerfil = new Button();
            uC_tb_descPerfil = new UC_textbox();
            dgv_perfil = new DataGridView();
            uC_tb_idPerfil = new UC_tb_numerico();
            gb_permiso = new GroupBox();
            btn_guardarPermiso = new Button();
            btn_limparPermiso = new Button();
            dgv_permiso = new DataGridView();
            btn_eliminarPermiso = new Button();
            uC_tb_nombrePermiso = new UC_textbox();
            uC_tb_descPermiso = new UC_textbox();
            uC_tb_idPermiso = new UC_tb_numerico();
            btn_asignar = new Button();
            btn_desasignar = new Button();
            groupBox1 = new GroupBox();
            dgv_perperfil = new DataGridView();
            groupBox2 = new GroupBox();
            dgv_perper = new DataGridView();
            cb_asociar = new ComboBox();
            btn_relPerPer = new Button();
            label1 = new Label();
            gb_perfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_perfil).BeginInit();
            gb_permiso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_permiso).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_perperfil).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_perper).BeginInit();
            SuspendLayout();
            // 
            // gb_perfil
            // 
            gb_perfil.Controls.Add(btn_borrarPerfil);
            gb_perfil.Controls.Add(btn_limpiarPerfil);
            gb_perfil.Controls.Add(btn_guardarPerfil);
            gb_perfil.Controls.Add(uC_tb_descPerfil);
            gb_perfil.Controls.Add(dgv_perfil);
            gb_perfil.Controls.Add(uC_tb_idPerfil);
            gb_perfil.Location = new Point(12, 12);
            gb_perfil.Name = "gb_perfil";
            gb_perfil.Size = new Size(548, 158);
            gb_perfil.TabIndex = 0;
            gb_perfil.TabStop = false;
            gb_perfil.Text = "ABM Perfil";
            // 
            // btn_borrarPerfil
            // 
            btn_borrarPerfil.Location = new Point(9, 118);
            btn_borrarPerfil.Name = "btn_borrarPerfil";
            btn_borrarPerfil.Size = new Size(73, 33);
            btn_borrarPerfil.TabIndex = 4;
            btn_borrarPerfil.Text = "Eliminar";
            btn_borrarPerfil.UseVisualStyleBackColor = true;
            btn_borrarPerfil.Click += btn_borrarPerfil_Click;
            // 
            // btn_limpiarPerfil
            // 
            btn_limpiarPerfil.Location = new Point(88, 118);
            btn_limpiarPerfil.Name = "btn_limpiarPerfil";
            btn_limpiarPerfil.Size = new Size(73, 33);
            btn_limpiarPerfil.TabIndex = 3;
            btn_limpiarPerfil.Text = "Limpiar";
            btn_limpiarPerfil.UseVisualStyleBackColor = true;
            btn_limpiarPerfil.Click += btn_limpiarPerfil_Click;
            // 
            // btn_guardarPerfil
            // 
            btn_guardarPerfil.Location = new Point(167, 118);
            btn_guardarPerfil.Name = "btn_guardarPerfil";
            btn_guardarPerfil.Size = new Size(73, 33);
            btn_guardarPerfil.TabIndex = 2;
            btn_guardarPerfil.Text = "Guardar";
            btn_guardarPerfil.UseVisualStyleBackColor = true;
            btn_guardarPerfil.Click += btn_guardarPerfil_Click;
            // 
            // uC_tb_descPerfil
            // 
            uC_tb_descPerfil.ETIQUETA = "Descripción:";
            uC_tb_descPerfil.Location = new Point(6, 65);
            uC_tb_descPerfil.MAX_LENGTH = 20;
            uC_tb_descPerfil.Name = "uC_tb_descPerfil";
            uC_tb_descPerfil.REQUERIDO = true;
            uC_tb_descPerfil.Size = new Size(176, 47);
            uC_tb_descPerfil.TabIndex = 1;
            uC_tb_descPerfil.TEXT_BOX = "";
            // 
            // dgv_perfil
            // 
            dgv_perfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_perfil.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_perfil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_perfil.Location = new Point(243, 13);
            dgv_perfil.MultiSelect = false;
            dgv_perfil.Name = "dgv_perfil";
            dgv_perfil.ReadOnly = true;
            dgv_perfil.RowTemplate.Height = 25;
            dgv_perfil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_perfil.Size = new Size(299, 138);
            dgv_perfil.TabIndex = 1;
            dgv_perfil.CellClick += dgv_perfil_CellClick;
            // 
            // uC_tb_idPerfil
            // 
            uC_tb_idPerfil.Enabled = false;
            uC_tb_idPerfil.ETIQUETA = "ID:";
            uC_tb_idPerfil.Location = new Point(6, 22);
            uC_tb_idPerfil.MAX_LENGTH = 32767;
            uC_tb_idPerfil.Name = "uC_tb_idPerfil";
            uC_tb_idPerfil.REQUERIDO = false;
            uC_tb_idPerfil.Size = new Size(176, 46);
            uC_tb_idPerfil.TabIndex = 0;
            uC_tb_idPerfil.TEXT_BOX = "";
            // 
            // gb_permiso
            // 
            gb_permiso.Controls.Add(btn_guardarPermiso);
            gb_permiso.Controls.Add(btn_limparPermiso);
            gb_permiso.Controls.Add(dgv_permiso);
            gb_permiso.Controls.Add(btn_eliminarPermiso);
            gb_permiso.Controls.Add(uC_tb_nombrePermiso);
            gb_permiso.Controls.Add(uC_tb_descPermiso);
            gb_permiso.Controls.Add(uC_tb_idPermiso);
            gb_permiso.Location = new Point(12, 176);
            gb_permiso.Name = "gb_permiso";
            gb_permiso.Size = new Size(548, 183);
            gb_permiso.TabIndex = 2;
            gb_permiso.TabStop = false;
            gb_permiso.Text = "ABM Permiso";
            // 
            // btn_guardarPermiso
            // 
            btn_guardarPermiso.Location = new Point(167, 144);
            btn_guardarPermiso.Name = "btn_guardarPermiso";
            btn_guardarPermiso.Size = new Size(73, 33);
            btn_guardarPermiso.TabIndex = 5;
            btn_guardarPermiso.Text = "Guardar";
            btn_guardarPermiso.UseVisualStyleBackColor = true;
            btn_guardarPermiso.Click += btn_guardarPermiso_Click;
            // 
            // btn_limparPermiso
            // 
            btn_limparPermiso.Location = new Point(88, 144);
            btn_limparPermiso.Name = "btn_limparPermiso";
            btn_limparPermiso.Size = new Size(73, 33);
            btn_limparPermiso.TabIndex = 4;
            btn_limparPermiso.Text = "Limpiar";
            btn_limparPermiso.UseVisualStyleBackColor = true;
            btn_limparPermiso.Click += btn_limparPermiso_Click;
            // 
            // dgv_permiso
            // 
            dgv_permiso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_permiso.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_permiso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_permiso.Location = new Point(243, 12);
            dgv_permiso.MultiSelect = false;
            dgv_permiso.Name = "dgv_permiso";
            dgv_permiso.ReadOnly = true;
            dgv_permiso.RowTemplate.Height = 25;
            dgv_permiso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_permiso.Size = new Size(299, 165);
            dgv_permiso.TabIndex = 3;
            dgv_permiso.CellClick += dgv_permiso_CellClick;
            // 
            // btn_eliminarPermiso
            // 
            btn_eliminarPermiso.Location = new Point(9, 144);
            btn_eliminarPermiso.Name = "btn_eliminarPermiso";
            btn_eliminarPermiso.Size = new Size(73, 33);
            btn_eliminarPermiso.TabIndex = 3;
            btn_eliminarPermiso.Text = "Eliminar";
            btn_eliminarPermiso.UseVisualStyleBackColor = true;
            btn_eliminarPermiso.Click += btn_eliminarPermiso_Click;
            // 
            // uC_tb_nombrePermiso
            // 
            uC_tb_nombrePermiso.ETIQUETA = "Nombre:";
            uC_tb_nombrePermiso.Location = new Point(6, 95);
            uC_tb_nombrePermiso.MAX_LENGTH = 20;
            uC_tb_nombrePermiso.Name = "uC_tb_nombrePermiso";
            uC_tb_nombrePermiso.REQUERIDO = true;
            uC_tb_nombrePermiso.Size = new Size(176, 43);
            uC_tb_nombrePermiso.TabIndex = 2;
            uC_tb_nombrePermiso.TEXT_BOX = "";
            // 
            // uC_tb_descPermiso
            // 
            uC_tb_descPermiso.ETIQUETA = "Descripción:";
            uC_tb_descPermiso.Location = new Point(6, 54);
            uC_tb_descPermiso.MAX_LENGTH = 50;
            uC_tb_descPermiso.Name = "uC_tb_descPermiso";
            uC_tb_descPermiso.REQUERIDO = true;
            uC_tb_descPermiso.Size = new Size(177, 46);
            uC_tb_descPermiso.TabIndex = 1;
            uC_tb_descPermiso.TEXT_BOX = "";
            // 
            // uC_tb_idPermiso
            // 
            uC_tb_idPermiso.Enabled = false;
            uC_tb_idPermiso.ETIQUETA = "ID:";
            uC_tb_idPermiso.Location = new Point(6, 12);
            uC_tb_idPermiso.MAX_LENGTH = 32767;
            uC_tb_idPermiso.Name = "uC_tb_idPermiso";
            uC_tb_idPermiso.REQUERIDO = false;
            uC_tb_idPermiso.Size = new Size(177, 44);
            uC_tb_idPermiso.TabIndex = 0;
            uC_tb_idPermiso.TEXT_BOX = "";
            // 
            // btn_asignar
            // 
            btn_asignar.Location = new Point(185, 372);
            btn_asignar.Name = "btn_asignar";
            btn_asignar.Size = new Size(73, 33);
            btn_asignar.TabIndex = 4;
            btn_asignar.Text = "Asignar";
            btn_asignar.UseVisualStyleBackColor = true;
            btn_asignar.Click += btn_asignar_Click;
            // 
            // btn_desasignar
            // 
            btn_desasignar.Location = new Point(12, 372);
            btn_desasignar.Name = "btn_desasignar";
            btn_desasignar.Size = new Size(73, 33);
            btn_desasignar.TabIndex = 5;
            btn_desasignar.Text = "Desasignar";
            btn_desasignar.UseVisualStyleBackColor = true;
            btn_desasignar.Click += btn_desasignar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_perperfil);
            groupBox1.Location = new Point(566, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 158);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permisos asociados al Perfil:";
            // 
            // dgv_perperfil
            // 
            dgv_perperfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_perperfil.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_perperfil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_perperfil.Location = new Point(6, 13);
            dgv_perperfil.MultiSelect = false;
            dgv_perperfil.Name = "dgv_perperfil";
            dgv_perperfil.ReadOnly = true;
            dgv_perperfil.RowTemplate.Height = 25;
            dgv_perperfil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_perperfil.Size = new Size(307, 138);
            dgv_perperfil.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_perper);
            groupBox2.Location = new Point(566, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(319, 183);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Permisos asociados al Permiso:";
            // 
            // dgv_perper
            // 
            dgv_perper.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_perper.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_perper.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_perper.Location = new Point(6, 12);
            dgv_perper.MultiSelect = false;
            dgv_perper.Name = "dgv_perper";
            dgv_perper.ReadOnly = true;
            dgv_perper.RowTemplate.Height = 25;
            dgv_perper.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_perper.Size = new Size(307, 165);
            dgv_perper.TabIndex = 0;
            // 
            // cb_asociar
            // 
            cb_asociar.FormattingEnabled = true;
            cb_asociar.Location = new Point(601, 375);
            cb_asociar.Name = "cb_asociar";
            cb_asociar.Size = new Size(173, 23);
            cb_asociar.TabIndex = 8;
            cb_asociar.Text = "Seleccionar...";
            cb_asociar.SelectedIndexChanged += cb_asociar_SelectedIndexChanged;
            // 
            // btn_relPerPer
            // 
            btn_relPerPer.Location = new Point(790, 366);
            btn_relPerPer.Name = "btn_relPerPer";
            btn_relPerPer.Size = new Size(73, 39);
            btn_relPerPer.TabIndex = 9;
            btn_relPerPer.Text = "Asociar permisos";
            btn_relPerPer.UseVisualStyleBackColor = true;
            btn_relPerPer.Click += btn_relPerPer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(404, 381);
            label1.Name = "label1";
            label1.Size = new Size(191, 15);
            label1.TabIndex = 10;
            label1.Text = "Asociarlo con el siguiente permiso:";
            // 
            // FormABMPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(897, 411);
            Controls.Add(label1);
            Controls.Add(btn_relPerPer);
            Controls.Add(cb_asociar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btn_desasignar);
            Controls.Add(btn_asignar);
            Controls.Add(gb_permiso);
            Controls.Add(gb_perfil);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormABMPerfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - ABM Perfil";
            Load += FormABMPerfil_Load;
            gb_perfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_perfil).EndInit();
            gb_permiso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_permiso).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_perperfil).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_perper).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gb_perfil;
        private UC_textbox uC_tb_descPerfil;
        private UC_tb_numerico uC_tb_idPerfil;
        private Button btn_borrarPerfil;
        private Button btn_limpiarPerfil;
        private Button btn_guardarPerfil;
        private DataGridView dgv_perfil;
        private GroupBox gb_permiso;
        private DataGridView dgv_permiso;
        private UC_textbox uC_tb_nombrePermiso;
        private UC_textbox uC_tb_descPermiso;
        private UC_tb_numerico uC_tb_idPermiso;
        private Button btn_asignar;
        private Button btn_desasignar;
        private Button btn_guardarPermiso;
        private Button btn_limparPermiso;
        private Button btn_eliminarPermiso;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cb_asociar;
        private Button btn_relPerPer;
        private Label label1;
        private DataGridView dgv_perperfil;
        private DataGridView dgv_perper;
    }
}