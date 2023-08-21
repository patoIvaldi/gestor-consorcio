namespace UI
{
    partial class FormGenerarExpensa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerarExpensa));
            groupBox1 = new GroupBox();
            dgv_propietarios = new DataGridView();
            groupBox2 = new GroupBox();
            dgv_detalle = new DataGridView();
            groupBox3 = new GroupBox();
            btn_agregarSeg = new Button();
            uC_tb_importeSegmento = new UC_tb_numerico();
            uC_tb_descSegmento = new UC_textbox();
            groupBox4 = new GroupBox();
            dgv_expensas = new DataGridView();
            btn_generarExp = new Button();
            btn_limpiar = new Button();
            uC_dttmFechaExpensa = new UC_dttmPicker();
            groupBox5 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_propietarios).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_detalle).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_expensas).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgv_propietarios);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Propietarios";
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
            dgv_propietarios.Size = new Size(544, 72);
            dgv_propietarios.TabIndex = 0;
            dgv_propietarios.CellClick += dgv_propietarios_CellClick;
            dgv_propietarios.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgv_detalle);
            groupBox2.Location = new Point(218, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 180);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de la expensa";
            // 
            // dgv_detalle
            // 
            dgv_detalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_detalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_detalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_detalle.Location = new Point(6, 22);
            dgv_detalle.MultiSelect = false;
            dgv_detalle.Name = "dgv_detalle";
            dgv_detalle.ReadOnly = true;
            dgv_detalle.RowTemplate.Height = 25;
            dgv_detalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_detalle.Size = new Size(338, 152);
            dgv_detalle.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btn_agregarSeg);
            groupBox3.Controls.Add(uC_tb_importeSegmento);
            groupBox3.Controls.Add(uC_tb_descSegmento);
            groupBox3.Location = new Point(12, 118);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 180);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agregar segmento";
            // 
            // btn_agregarSeg
            // 
            btn_agregarSeg.Location = new Point(50, 126);
            btn_agregarSeg.Name = "btn_agregarSeg";
            btn_agregarSeg.Size = new Size(75, 40);
            btn_agregarSeg.TabIndex = 3;
            btn_agregarSeg.Text = "Agregar Segmento";
            btn_agregarSeg.UseVisualStyleBackColor = true;
            btn_agregarSeg.Click += btn_agregarSeg_Click;
            // 
            // uC_tb_importeSegmento
            // 
            uC_tb_importeSegmento.ETIQUETA = "Importe:";
            uC_tb_importeSegmento.Location = new Point(6, 64);
            uC_tb_importeSegmento.MAX_LENGTH = 32767;
            uC_tb_importeSegmento.Name = "uC_tb_importeSegmento";
            uC_tb_importeSegmento.REQUERIDO = true;
            uC_tb_importeSegmento.Size = new Size(176, 46);
            uC_tb_importeSegmento.TabIndex = 2;
            uC_tb_importeSegmento.TEXT_BOX = "";
            // 
            // uC_tb_descSegmento
            // 
            uC_tb_descSegmento.ETIQUETA = "Descripción:";
            uC_tb_descSegmento.Location = new Point(6, 19);
            uC_tb_descSegmento.MAX_LENGTH = 30;
            uC_tb_descSegmento.Name = "uC_tb_descSegmento";
            uC_tb_descSegmento.REQUERIDO = true;
            uC_tb_descSegmento.Size = new Size(176, 46);
            uC_tb_descSegmento.TabIndex = 1;
            uC_tb_descSegmento.TEXT_BOX = "";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgv_expensas);
            groupBox4.Location = new Point(574, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(598, 355);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Expensas";
            // 
            // dgv_expensas
            // 
            dgv_expensas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_expensas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_expensas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_expensas.Location = new Point(6, 22);
            dgv_expensas.MultiSelect = false;
            dgv_expensas.Name = "dgv_expensas";
            dgv_expensas.ReadOnly = true;
            dgv_expensas.RowTemplate.Height = 25;
            dgv_expensas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_expensas.Size = new Size(586, 327);
            dgv_expensas.TabIndex = 0;
            dgv_expensas.CellClick += dgv_expensas_CellClick;
            // 
            // btn_generarExp
            // 
            btn_generarExp.Location = new Point(475, 16);
            btn_generarExp.Name = "btn_generarExp";
            btn_generarExp.Size = new Size(75, 42);
            btn_generarExp.TabIndex = 4;
            btn_generarExp.Text = "Generar expensa";
            btn_generarExp.UseVisualStyleBackColor = true;
            btn_generarExp.Click += btn_generarExp_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(6, 18);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 40);
            btn_limpiar.TabIndex = 4;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // uC_dttmFechaExpensa
            // 
            uC_dttmFechaExpensa.ETIQUETA = "Fecha emisión:";
            uC_dttmFechaExpensa.Location = new Point(351, 13);
            uC_dttmFechaExpensa.Name = "uC_dttmFechaExpensa";
            uC_dttmFechaExpensa.REQUERIDO = false;
            uC_dttmFechaExpensa.Size = new Size(105, 50);
            uC_dttmFechaExpensa.TabIndex = 5;
            uC_dttmFechaExpensa.VALOR = new DateTime(2023, 7, 10, 0, 0, 0, 0);
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btn_limpiar);
            groupBox5.Controls.Add(btn_generarExp);
            groupBox5.Controls.Add(uC_dttmFechaExpensa);
            groupBox5.Location = new Point(12, 297);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(556, 69);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            // 
            // FormGenerarExpensa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(1184, 373);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormGenerarExpensa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Generar expensa";
            Load += FormGenerarExpensa_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_propietarios).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_detalle).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_expensas).EndInit();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgv_propietarios;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btn_agregarSeg;
        private UC_tb_numerico uC_tb_importeSegmento;
        private UC_textbox uC_tb_descSegmento;
        private GroupBox groupBox4;
        private Button btn_generarExp;
        private Button btn_limpiar;
        private UC_dttmPicker uC_dttmFechaExpensa;
        private DataGridView dgv_detalle;
        private DataGridView dgv_expensas;
        private GroupBox groupBox5;
    }
}