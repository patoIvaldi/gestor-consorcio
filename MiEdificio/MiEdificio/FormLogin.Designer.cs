namespace UI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pb_logo = new PictureBox();
            groupBox1 = new GroupBox();
            btn_ingresar = new Button();
            cb_idioma = new ComboBox();
            label1 = new Label();
            tb_usuario = new TextBox();
            pb_iconoUsuario = new PictureBox();
            lbl_pie = new Label();
            uC_tb_password1 = new UC_tb_password();
            ((System.ComponentModel.ISupportInitialize)pb_logo).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_iconoUsuario).BeginInit();
            SuspendLayout();
            // 
            // pb_logo
            // 
            pb_logo.Image = Properties.Resources.icono;
            pb_logo.InitialImage = Properties.Resources.icono;
            pb_logo.Location = new Point(315, 31);
            pb_logo.Name = "pb_logo";
            pb_logo.Size = new Size(163, 151);
            pb_logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_logo.TabIndex = 0;
            pb_logo.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_tb_password1);
            groupBox1.Controls.Add(btn_ingresar);
            groupBox1.Controls.Add(cb_idioma);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tb_usuario);
            groupBox1.Controls.Add(pb_iconoUsuario);
            groupBox1.Location = new Point(290, 188);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(213, 250);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btn_ingresar
            // 
            btn_ingresar.Location = new Point(66, 213);
            btn_ingresar.Name = "btn_ingresar";
            btn_ingresar.Size = new Size(70, 31);
            btn_ingresar.TabIndex = 7;
            btn_ingresar.Text = "Ingresar";
            btn_ingresar.UseVisualStyleBackColor = true;
            btn_ingresar.Click += btn_ingresar_Click;
            // 
            // cb_idioma
            // 
            cb_idioma.FormattingEnabled = true;
            cb_idioma.Location = new Point(57, 184);
            cb_idioma.Name = "cb_idioma";
            cb_idioma.Size = new Size(89, 23);
            cb_idioma.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(22, 80);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario:";
            label1.Click += label1_Click;
            // 
            // tb_usuario
            // 
            tb_usuario.Location = new Point(22, 98);
            tb_usuario.Name = "tb_usuario";
            tb_usuario.Size = new Size(170, 23);
            tb_usuario.TabIndex = 1;
            // 
            // pb_iconoUsuario
            // 
            pb_iconoUsuario.Image = Properties.Resources.icono_usuario;
            pb_iconoUsuario.Location = new Point(79, 22);
            pb_iconoUsuario.Name = "pb_iconoUsuario";
            pb_iconoUsuario.Size = new Size(57, 56);
            pb_iconoUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_iconoUsuario.TabIndex = 0;
            pb_iconoUsuario.TabStop = false;
            // 
            // lbl_pie
            // 
            lbl_pie.AutoSize = true;
            lbl_pie.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_pie.Location = new Point(284, 489);
            lbl_pie.Name = "lbl_pie";
            lbl_pie.Size = new Size(222, 13);
            lbl_pie.TabIndex = 2;
            lbl_pie.Text = "Powered by Ceiba - Buenos Aires, Argentina - ";
            // 
            // uC_tb_password1
            // 
            uC_tb_password1.ETIQUETA = "Contraseña";
            uC_tb_password1.Location = new Point(19, 128);
            uC_tb_password1.Name = "uC_tb_password1";
            uC_tb_password1.REQUERIDO = true;
            uC_tb_password1.Size = new Size(177, 45);
            uC_tb_password1.TabIndex = 3;
            uC_tb_password1.TEXT_BOX = "";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(800, 511);
            Controls.Add(lbl_pie);
            Controls.Add(groupBox1);
            Controls.Add(pb_logo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            Resize += Login_Resize;
            ((System.ComponentModel.ISupportInitialize)pb_logo).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_iconoUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_logo;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox tb_usuario;
        private PictureBox pb_iconoUsuario;
        private ComboBox cb_idioma;
        private Button btn_ingresar;
        private Label lbl_pie;
        private UC_tb_password uC_tb_password1;
    }
}