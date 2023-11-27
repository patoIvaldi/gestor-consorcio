namespace UI
{
    partial class FormGenerarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerarReserva));
            groupBox1 = new GroupBox();
            dgv_reservas = new DataGridView();
            groupBox2 = new GroupBox();
            uc_horaFin = new UC_textbox();
            uc_horaInicio = new UC_textbox();
            label2 = new Label();
            label1 = new Label();
            btn_feedback = new Button();
            btn_reservar = new Button();
            cb_areas = new ComboBox();
            cb_usuarios = new ComboBox();
            uc_fechafin = new UC_dttmPicker();
            uc_fechainicio = new UC_dttmPicker();
            btn_cancelar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_reservas).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_reservas);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 342);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reservas:";
            // 
            // dgv_reservas
            // 
            dgv_reservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_reservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_reservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_reservas.Location = new Point(6, 22);
            dgv_reservas.MultiSelect = false;
            dgv_reservas.Name = "dgv_reservas";
            dgv_reservas.ReadOnly = true;
            dgv_reservas.RowTemplate.Height = 25;
            dgv_reservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_reservas.Size = new Size(764, 314);
            dgv_reservas.TabIndex = 0;
            dgv_reservas.CellClick += dgv_reservas_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_cancelar);
            groupBox2.Controls.Add(uc_horaFin);
            groupBox2.Controls.Add(uc_horaInicio);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btn_feedback);
            groupBox2.Controls.Add(btn_reservar);
            groupBox2.Controls.Add(cb_areas);
            groupBox2.Controls.Add(cb_usuarios);
            groupBox2.Controls.Add(uc_fechafin);
            groupBox2.Controls.Add(uc_fechainicio);
            groupBox2.Location = new Point(12, 360);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 178);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // uc_horaFin
            // 
            uc_horaFin.ETIQUETA = "Hora Fin:";
            uc_horaFin.Location = new Point(150, 82);
            uc_horaFin.MAX_LENGTH = 8;
            uc_horaFin.Name = "uc_horaFin";
            uc_horaFin.REQUERIDO = false;
            uc_horaFin.Size = new Size(80, 46);
            uc_horaFin.TabIndex = 11;
            uc_horaFin.TEXT_BOX = "00:00:00";
            // 
            // uc_horaInicio
            // 
            uc_horaInicio.ETIQUETA = "Hora Inicio";
            uc_horaInicio.Location = new Point(150, 26);
            uc_horaInicio.MAX_LENGTH = 8;
            uc_horaInicio.Name = "uc_horaInicio";
            uc_horaInicio.REQUERIDO = false;
            uc_horaInicio.Size = new Size(80, 46);
            uc_horaInicio.TabIndex = 10;
            uc_horaInicio.TEXT_BOX = "00:00:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(352, 129);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 8;
            label2.Text = "Área:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 129);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 7;
            label1.Text = "Usuario:";
            // 
            // btn_feedback
            // 
            btn_feedback.Enabled = false;
            btn_feedback.Location = new Point(352, 26);
            btn_feedback.Name = "btn_feedback";
            btn_feedback.Size = new Size(201, 66);
            btn_feedback.TabIndex = 6;
            btn_feedback.Text = "Generar Feedback";
            btn_feedback.UseVisualStyleBackColor = true;
            btn_feedback.Click += btn_feedback_Click;
            // 
            // btn_reservar
            // 
            btn_reservar.Location = new Point(686, 129);
            btn_reservar.Name = "btn_reservar";
            btn_reservar.Size = new Size(75, 41);
            btn_reservar.TabIndex = 5;
            btn_reservar.Text = "Reservar";
            btn_reservar.UseVisualStyleBackColor = true;
            btn_reservar.Click += btn_reservar_Click;
            // 
            // cb_areas
            // 
            cb_areas.Enabled = false;
            cb_areas.FormattingEnabled = true;
            cb_areas.Location = new Point(352, 147);
            cb_areas.Name = "cb_areas";
            cb_areas.Size = new Size(201, 23);
            cb_areas.TabIndex = 3;
            // 
            // cb_usuarios
            // 
            cb_usuarios.FormattingEnabled = true;
            cb_usuarios.Location = new Point(6, 147);
            cb_usuarios.Name = "cb_usuarios";
            cb_usuarios.Size = new Size(328, 23);
            cb_usuarios.TabIndex = 2;
            // 
            // uc_fechafin
            // 
            uc_fechafin.ETIQUETA = "Fecha/Hora de Fin:";
            uc_fechafin.Location = new Point(6, 78);
            uc_fechafin.Name = "uc_fechafin";
            uc_fechafin.REQUERIDO = false;
            uc_fechafin.Size = new Size(138, 50);
            uc_fechafin.TabIndex = 1;
            uc_fechafin.VALOR = new DateTime(2023, 10, 29, 0, 0, 0, 0);
            // 
            // uc_fechainicio
            // 
            uc_fechainicio.ETIQUETA = "Fecha/Hora de Inicio:";
            uc_fechainicio.Location = new Point(6, 22);
            uc_fechainicio.Name = "uc_fechainicio";
            uc_fechainicio.REQUERIDO = false;
            uc_fechainicio.Size = new Size(138, 50);
            uc_fechainicio.TabIndex = 0;
            uc_fechainicio.VALOR = new DateTime(2023, 10, 29, 0, 0, 0, 0);
            // 
            // btn_cancelar
            // 
            btn_cancelar.Location = new Point(686, 26);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(75, 38);
            btn_cancelar.TabIndex = 12;
            btn_cancelar.Text = "Cancelar Reserva";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // FormGenerarReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(800, 550);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormGenerarReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Generar Reserva";
            Load += FormGenerarReserva_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_reservas).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_reservas;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Button btn_feedback;
        private Button btn_reservar;
        private ComboBox cb_areas;
        private ComboBox cb_usuarios;
        private UC_dttmPicker uc_fechafin;
        private UC_dttmPicker uc_fechainicio;
        private UC_textbox uc_horaInicio;
        private UC_textbox uc_horaFin;
        private Button btn_cancelar;
    }
}