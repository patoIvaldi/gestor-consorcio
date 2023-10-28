namespace UI
{
    partial class FormEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEventos));
            groupBox1 = new GroupBox();
            btn_limpiar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_buscar = new Button();
            cb_usuario = new ComboBox();
            uc_horaFin = new UC_textbox();
            uc_horaInicio = new UC_textbox();
            cb_operacion = new ComboBox();
            cb_criticidad = new ComboBox();
            uc_fechaFin = new UC_dttmPicker();
            uc_fechaInicio = new UC_dttmPicker();
            dgv_eventos = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_eventos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_limpiar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btn_buscar);
            groupBox1.Controls.Add(cb_usuario);
            groupBox1.Controls.Add(uc_horaFin);
            groupBox1.Controls.Add(uc_horaInicio);
            groupBox1.Controls.Add(cb_operacion);
            groupBox1.Controls.Add(cb_criticidad);
            groupBox1.Controls.Add(uc_fechaFin);
            groupBox1.Controls.Add(uc_fechaInicio);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(709, 122);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda:";
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(623, 75);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 36);
            btn_limpiar.TabIndex = 2;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(368, 70);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 10;
            label3.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(228, 70);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 9;
            label2.Text = "Operación:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(228, 25);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 8;
            label1.Text = "Criticidad:";
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(623, 22);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(75, 36);
            btn_buscar.TabIndex = 7;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // cb_usuario
            // 
            cb_usuario.FormattingEnabled = true;
            cb_usuario.Location = new Point(368, 88);
            cb_usuario.Name = "cb_usuario";
            cb_usuario.Size = new Size(233, 23);
            cb_usuario.TabIndex = 6;
            // 
            // uc_horaFin
            // 
            uc_horaFin.ETIQUETA = "Hora Fin:";
            uc_horaFin.Location = new Point(117, 71);
            uc_horaFin.MAX_LENGTH = 8;
            uc_horaFin.Name = "uc_horaFin";
            uc_horaFin.REQUERIDO = false;
            uc_horaFin.Size = new Size(65, 46);
            uc_horaFin.TabIndex = 5;
            uc_horaFin.TEXT_BOX = "";
            // 
            // uc_horaInicio
            // 
            uc_horaInicio.ETIQUETA = "Hora Inicio:";
            uc_horaInicio.Location = new Point(6, 71);
            uc_horaInicio.MAX_LENGTH = 8;
            uc_horaInicio.Name = "uc_horaInicio";
            uc_horaInicio.REQUERIDO = false;
            uc_horaInicio.Size = new Size(75, 46);
            uc_horaInicio.TabIndex = 4;
            uc_horaInicio.TEXT_BOX = "";
            // 
            // cb_operacion
            // 
            cb_operacion.FormattingEnabled = true;
            cb_operacion.Location = new Point(228, 88);
            cb_operacion.Name = "cb_operacion";
            cb_operacion.Size = new Size(121, 23);
            cb_operacion.TabIndex = 3;
            // 
            // cb_criticidad
            // 
            cb_criticidad.FormattingEnabled = true;
            cb_criticidad.Location = new Point(228, 43);
            cb_criticidad.Name = "cb_criticidad";
            cb_criticidad.Size = new Size(121, 23);
            cb_criticidad.TabIndex = 2;
            // 
            // uc_fechaFin
            // 
            uc_fechaFin.ETIQUETA = "Fecha Fin:";
            uc_fechaFin.Location = new Point(117, 22);
            uc_fechaFin.Name = "uc_fechaFin";
            uc_fechaFin.REQUERIDO = false;
            uc_fechaFin.Size = new Size(105, 50);
            uc_fechaFin.TabIndex = 1;
            uc_fechaFin.VALOR = new DateTime(2023, 10, 21, 0, 0, 0, 0);
            // 
            // uc_fechaInicio
            // 
            uc_fechaInicio.ETIQUETA = "Fecha Inicio:";
            uc_fechaInicio.Location = new Point(6, 22);
            uc_fechaInicio.Name = "uc_fechaInicio";
            uc_fechaInicio.REQUERIDO = false;
            uc_fechaInicio.Size = new Size(105, 50);
            uc_fechaInicio.TabIndex = 0;
            uc_fechaInicio.VALOR = new DateTime(2023, 10, 21, 0, 0, 0, 0);
            uc_fechaInicio.Click += uc_fechaInicio_Click;
            // 
            // dgv_eventos
            // 
            dgv_eventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_eventos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_eventos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_eventos.Location = new Point(12, 140);
            dgv_eventos.MultiSelect = false;
            dgv_eventos.Name = "dgv_eventos";
            dgv_eventos.ReadOnly = true;
            dgv_eventos.RowTemplate.Height = 25;
            dgv_eventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_eventos.Size = new Size(709, 356);
            dgv_eventos.TabIndex = 1;
            // 
            // FormEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(733, 508);
            Controls.Add(dgv_eventos);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormEventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Bitácora de eventos del sistema";
            Load += FormEventos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_eventos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_eventos;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_buscar;
        private ComboBox cb_usuario;
        private UC_textbox uc_horaFin;
        private UC_textbox uc_horaInicio;
        private ComboBox cb_operacion;
        private ComboBox cb_criticidad;
        private UC_dttmPicker uc_fechaFin;
        private UC_dttmPicker uc_fechaInicio;
        private Button btn_limpiar;
    }
}