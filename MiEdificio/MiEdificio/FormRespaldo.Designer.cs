namespace UI
{
    partial class FormRespaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRespaldo));
            groupBox1 = new GroupBox();
            btn_bkp = new Button();
            uc_fecha = new UC_dttmPicker();
            label2 = new Label();
            tb_dirBKP = new TextBox();
            groupBox2 = new GroupBox();
            btn_confirmarRestore = new Button();
            btn_buscarRestore = new Button();
            label1 = new Label();
            tb_dirRestore = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            btn_limpiar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_bkp);
            groupBox1.Controls.Add(uc_fecha);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tb_dirBKP);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(512, 84);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generar backup:";
            // 
            // btn_bkp
            // 
            btn_bkp.Location = new Point(429, 33);
            btn_bkp.Name = "btn_bkp";
            btn_bkp.Size = new Size(75, 39);
            btn_bkp.TabIndex = 5;
            btn_bkp.Text = "Generar Backup";
            btn_bkp.UseVisualStyleBackColor = true;
            btn_bkp.Click += btn_bkp_Click;
            // 
            // uc_fecha
            // 
            uc_fecha.Enabled = false;
            uc_fecha.ETIQUETA = "Fecha ocurrencia";
            uc_fecha.Location = new Point(307, 24);
            uc_fecha.Name = "uc_fecha";
            uc_fecha.REQUERIDO = false;
            uc_fecha.Size = new Size(105, 50);
            uc_fecha.TabIndex = 4;
            uc_fecha.VALOR = new DateTime(2023, 10, 23, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 27);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre del archivo generado:";
            // 
            // tb_dirBKP
            // 
            tb_dirBKP.Enabled = false;
            tb_dirBKP.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            tb_dirBKP.ForeColor = Color.Gray;
            tb_dirBKP.Location = new Point(6, 45);
            tb_dirBKP.Name = "tb_dirBKP";
            tb_dirBKP.Size = new Size(293, 23);
            tb_dirBKP.TabIndex = 0;
            tb_dirBKP.Text = " ...";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_confirmarRestore);
            groupBox2.Controls.Add(btn_buscarRestore);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tb_dirRestore);
            groupBox2.Location = new Point(12, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(512, 73);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Realizar restore:";
            // 
            // btn_confirmarRestore
            // 
            btn_confirmarRestore.Location = new Point(431, 22);
            btn_confirmarRestore.Name = "btn_confirmarRestore";
            btn_confirmarRestore.Size = new Size(75, 42);
            btn_confirmarRestore.TabIndex = 3;
            btn_confirmarRestore.Text = "Confirmar Restore";
            btn_confirmarRestore.UseVisualStyleBackColor = true;
            btn_confirmarRestore.Click += btn_confirmarRestore_Click;
            // 
            // btn_buscarRestore
            // 
            btn_buscarRestore.Location = new Point(307, 41);
            btn_buscarRestore.Name = "btn_buscarRestore";
            btn_buscarRestore.Size = new Size(75, 24);
            btn_buscarRestore.TabIndex = 2;
            btn_buscarRestore.Text = "Buscar";
            btn_buscarRestore.UseVisualStyleBackColor = true;
            btn_buscarRestore.Click += btn_Restore_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 1;
            label1.Text = "Directorio:";
            // 
            // tb_dirRestore
            // 
            tb_dirRestore.Enabled = false;
            tb_dirRestore.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            tb_dirRestore.ForeColor = Color.Gray;
            tb_dirRestore.Location = new Point(6, 41);
            tb_dirRestore.Name = "tb_dirRestore";
            tb_dirRestore.Size = new Size(293, 23);
            tb_dirRestore.TabIndex = 0;
            tb_dirRestore.Text = " ...";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(202, 181);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(118, 23);
            btn_limpiar.TabIndex = 2;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // FormRespaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(534, 213);
            Controls.Add(btn_limpiar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormRespaldo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Restore/Backup";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_bkp;
        private UC_dttmPicker uc_fecha;
        private Label label2;
        private TextBox tb_dirBKP;
        private Button btn_buscarRestore;
        private Label label1;
        private TextBox tb_dirRestore;
        private OpenFileDialog openFileDialog1;
        private Button btn_confirmarRestore;
        private SaveFileDialog saveFileDialog1;
        private Button btn_limpiar;
    }
}