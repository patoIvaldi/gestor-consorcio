namespace UI
{
    partial class FormAsignarPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsignarPerfil));
            groupBox1 = new GroupBox();
            cb_perfiles = new ComboBox();
            cb_usuarios = new ComboBox();
            btn_asignar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cb_perfiles);
            groupBox1.Controls.Add(cb_usuarios);
            groupBox1.Controls.Add(btn_asignar);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(401, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asignar perfil a usuario:";
            // 
            // cb_perfiles
            // 
            cb_perfiles.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            cb_perfiles.FormattingEnabled = true;
            cb_perfiles.Location = new Point(16, 79);
            cb_perfiles.Name = "cb_perfiles";
            cb_perfiles.Size = new Size(232, 23);
            cb_perfiles.TabIndex = 2;
            cb_perfiles.Text = "Seleccionar perfil...";
            // 
            // cb_usuarios
            // 
            cb_usuarios.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            cb_usuarios.FormattingEnabled = true;
            cb_usuarios.Location = new Point(16, 39);
            cb_usuarios.Name = "cb_usuarios";
            cb_usuarios.Size = new Size(232, 23);
            cb_usuarios.TabIndex = 1;
            cb_usuarios.Text = "Seleccionar usuario...";
            // 
            // btn_asignar
            // 
            btn_asignar.Location = new Point(286, 48);
            btn_asignar.Name = "btn_asignar";
            btn_asignar.Size = new Size(100, 45);
            btn_asignar.TabIndex = 0;
            btn_asignar.Text = "Asignar";
            btn_asignar.UseVisualStyleBackColor = true;
            btn_asignar.Click += btn_asignar_Click;
            // 
            // FormAsignarPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(426, 152);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAsignarPerfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Asignación de perfiles a usuario";
            Load += FormAsignarPerfil_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cb_perfiles;
        private ComboBox cb_usuarios;
        private Button btn_asignar;
    }
}