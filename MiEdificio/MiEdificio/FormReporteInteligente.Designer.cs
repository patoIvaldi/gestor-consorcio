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
            groupBox2 = new GroupBox();
            btn_buscar = new Button();
            uc_anio = new UC_tb_numerico();
            btn_serializar = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(450, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gráfico dispersión de reservas por meses";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_buscar);
            groupBox2.Controls.Add(uc_anio);
            groupBox2.Location = new Point(468, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 111);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrar";
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(52, 74);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(75, 23);
            btn_buscar.TabIndex = 1;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            // 
            // uc_anio
            // 
            uc_anio.ETIQUETA = "Elegir año:";
            uc_anio.Location = new Point(6, 22);
            uc_anio.MAX_LENGTH = 4;
            uc_anio.Name = "uc_anio";
            uc_anio.REQUERIDO = false;
            uc_anio.Size = new Size(163, 46);
            uc_anio.TabIndex = 0;
            uc_anio.TEXT_BOX = "2023";
            // 
            // btn_serializar
            // 
            btn_serializar.Location = new Point(474, 394);
            btn_serializar.Name = "btn_serializar";
            btn_serializar.Size = new Size(169, 43);
            btn_serializar.TabIndex = 2;
            btn_serializar.Text = "Serializar gráfico en JSON";
            btn_serializar.UseVisualStyleBackColor = true;
            // 
            // FormReporteInteligente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(655, 472);
            Controls.Add(btn_serializar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormReporteInteligente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Reporte inteligente";
            Load += FormReporteInteligente_Load;
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_buscar;
        private UC_tb_numerico uc_anio;
        private Button btn_serializar;
    }
}