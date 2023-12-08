namespace UI
{
    partial class FormReporteInteligente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteInteligente));
            groupBox1 = new GroupBox();
            fp_grafico = new ScottPlot.FormsPlot();
            groupBox2 = new GroupBox();
            label1 = new Label();
            cb_anios = new ComboBox();
            btn_buscar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fp_grafico);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(621, 356);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gráfico";
            // 
            // fp_grafico
            // 
            fp_grafico.Enabled = false;
            fp_grafico.Location = new Point(7, 22);
            fp_grafico.Margin = new Padding(4, 3, 4, 3);
            fp_grafico.Name = "fp_grafico";
            fp_grafico.Size = new Size(607, 321);
            fp_grafico.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(cb_anios);
            groupBox2.Controls.Add(btn_buscar);
            groupBox2.Location = new Point(12, 374);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(621, 80);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 26);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 3;
            label1.Text = "Año:";
            // 
            // cb_anios
            // 
            cb_anios.FormattingEnabled = true;
            cb_anios.Location = new Point(20, 45);
            cb_anios.Name = "cb_anios";
            cb_anios.Size = new Size(121, 23);
            cb_anios.TabIndex = 2;
            cb_anios.SelectedIndexChanged += cb_anios_SelectedIndexChanged;
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(214, 22);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(75, 46);
            btn_buscar.TabIndex = 1;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // FormReporteInteligente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(645, 464);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormReporteInteligente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Reporte inteligente";
            Load += FormReporteInteligente_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_buscar;
        private ScottPlot.FormsPlot fp_grafico;
        private Label label1;
        private ComboBox cb_anios;
    }
}