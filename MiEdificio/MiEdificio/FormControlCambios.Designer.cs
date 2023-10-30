namespace UI
{
    partial class FormControlCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControlCambios));
            dgv_cambios = new DataGridView();
            groupBox1 = new GroupBox();
            check_activo = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            btn_limpiar = new Button();
            btn_buscar = new Button();
            cb_estados = new ComboBox();
            cb_usuarios = new ComboBox();
            uc_horafin = new UC_textbox();
            uc_horainicio = new UC_textbox();
            uc_fechafin = new UC_dttmPicker();
            uc_fechainicio = new UC_dttmPicker();
            ((System.ComponentModel.ISupportInitialize)dgv_cambios).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_cambios
            // 
            dgv_cambios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_cambios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_cambios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_cambios.Location = new Point(12, 12);
            dgv_cambios.MultiSelect = false;
            dgv_cambios.Name = "dgv_cambios";
            dgv_cambios.ReadOnly = true;
            dgv_cambios.RowTemplate.Height = 25;
            dgv_cambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_cambios.Size = new Size(1059, 371);
            dgv_cambios.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(check_activo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btn_limpiar);
            groupBox1.Controls.Add(btn_buscar);
            groupBox1.Controls.Add(cb_estados);
            groupBox1.Controls.Add(cb_usuarios);
            groupBox1.Controls.Add(uc_horafin);
            groupBox1.Controls.Add(uc_horainicio);
            groupBox1.Controls.Add(uc_fechafin);
            groupBox1.Controls.Add(uc_fechainicio);
            groupBox1.Location = new Point(12, 389);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1059, 85);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda de cambios:";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // check_activo
            // 
            check_activo.AutoSize = true;
            check_activo.Location = new Point(866, 46);
            check_activo.Name = "check_activo";
            check_activo.Size = new Size(60, 19);
            check_activo.TabIndex = 11;
            check_activo.Text = "Activo";
            check_activo.UseVisualStyleBackColor = true;
            check_activo.CheckedChanged += check_activo_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(716, 26);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 9;
            label2.Text = "Estado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(457, 26);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 8;
            label1.Text = "Usuario:";
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(977, 55);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(76, 24);
            btn_limpiar.TabIndex = 7;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(978, 16);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(75, 25);
            btn_buscar.TabIndex = 6;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // cb_estados
            // 
            cb_estados.FormattingEnabled = true;
            cb_estados.Location = new Point(716, 44);
            cb_estados.Name = "cb_estados";
            cb_estados.Size = new Size(121, 23);
            cb_estados.TabIndex = 5;
            // 
            // cb_usuarios
            // 
            cb_usuarios.FormattingEnabled = true;
            cb_usuarios.Location = new Point(457, 44);
            cb_usuarios.Name = "cb_usuarios";
            cb_usuarios.Size = new Size(238, 23);
            cb_usuarios.TabIndex = 4;
            // 
            // uc_horafin
            // 
            uc_horafin.ETIQUETA = "Hora Fin:";
            uc_horafin.Location = new Point(346, 26);
            uc_horafin.MAX_LENGTH = 8;
            uc_horafin.Name = "uc_horafin";
            uc_horafin.REQUERIDO = false;
            uc_horafin.Size = new Size(83, 46);
            uc_horafin.TabIndex = 3;
            uc_horafin.TEXT_BOX = "";
            // 
            // uc_horainicio
            // 
            uc_horainicio.ETIQUETA = "Hora Inicio:";
            uc_horainicio.Location = new Point(252, 26);
            uc_horainicio.MAX_LENGTH = 8;
            uc_horainicio.Name = "uc_horainicio";
            uc_horainicio.REQUERIDO = false;
            uc_horainicio.Size = new Size(76, 46);
            uc_horainicio.TabIndex = 2;
            uc_horainicio.TEXT_BOX = "";
            // 
            // uc_fechafin
            // 
            uc_fechafin.ETIQUETA = "Fecha Fin:";
            uc_fechafin.Location = new Point(129, 22);
            uc_fechafin.Name = "uc_fechafin";
            uc_fechafin.REQUERIDO = false;
            uc_fechafin.Size = new Size(105, 50);
            uc_fechafin.TabIndex = 1;
            uc_fechafin.VALOR = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            // 
            // uc_fechainicio
            // 
            uc_fechainicio.ETIQUETA = "Fecha Inicio:";
            uc_fechainicio.Location = new Point(6, 22);
            uc_fechainicio.Name = "uc_fechainicio";
            uc_fechainicio.REQUERIDO = false;
            uc_fechainicio.Size = new Size(105, 50);
            uc_fechainicio.TabIndex = 0;
            uc_fechainicio.VALOR = new DateTime(2023, 10, 28, 0, 0, 0, 0);
            // 
            // FormControlCambios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(1083, 483);
            Controls.Add(groupBox1);
            Controls.Add(dgv_cambios);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormControlCambios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Control de cambios";
            Load += FormControlCambios_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_cambios).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_cambios;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button btn_limpiar;
        private Button btn_buscar;
        private ComboBox cb_estados;
        private ComboBox cb_usuarios;
        private UC_textbox uc_horafin;
        private UC_textbox uc_horainicio;
        private UC_dttmPicker uc_fechafin;
        private UC_dttmPicker uc_fechainicio;
        private CheckBox check_activo;
    }
}