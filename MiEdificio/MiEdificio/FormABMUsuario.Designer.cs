namespace UI
{
    partial class FormABMUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABMUsuario));
            gb_campos = new GroupBox();
            uC_textbox4 = new UC_textbox();
            uC_tb_password2 = new UC_tb_password();
            uC_tb_password1 = new UC_tb_password();
            uC_tb_numerico1 = new UC_tb_numerico();
            uC_textbox3 = new UC_textbox();
            uC_textbox2 = new UC_textbox();
            uC_textbox1 = new UC_textbox();
            lb_usuarios = new ListBox();
            btn_guardar = new Button();
            btn_nuevo = new Button();
            btn_desbloquear = new Button();
            uC_dttmPicker1 = new UC_dttmPicker();
            gb_campos.SuspendLayout();
            SuspendLayout();
            // 
            // gb_campos
            // 
            gb_campos.Controls.Add(uC_dttmPicker1);
            gb_campos.Controls.Add(uC_textbox4);
            gb_campos.Controls.Add(uC_tb_password2);
            gb_campos.Controls.Add(uC_tb_password1);
            gb_campos.Controls.Add(uC_tb_numerico1);
            gb_campos.Controls.Add(uC_textbox3);
            gb_campos.Controls.Add(uC_textbox2);
            gb_campos.Controls.Add(uC_textbox1);
            gb_campos.Location = new Point(12, 12);
            gb_campos.Name = "gb_campos";
            gb_campos.Size = new Size(212, 384);
            gb_campos.TabIndex = 0;
            gb_campos.TabStop = false;
            // 
            // uC_textbox4
            // 
            uC_textbox4.ETIQUETA = "Username:";
            uC_textbox4.Location = new Point(6, 194);
            uC_textbox4.Name = "uC_textbox4";
            uC_textbox4.REQUERIDO = false;
            uC_textbox4.Size = new Size(176, 46);
            uC_textbox4.TabIndex = 6;
            uC_textbox4.TEXT_BOX = "";
            // 
            // uC_tb_password2
            // 
            uC_tb_password2.ETIQUETA = "Contraseña:";
            uC_tb_password2.Location = new Point(6, 289);
            uC_tb_password2.Name = "uC_tb_password2";
            uC_tb_password2.REQUERIDO = false;
            uC_tb_password2.Size = new Size(200, 46);
            uC_tb_password2.TabIndex = 5;
            uC_tb_password2.TEXT_BOX = "";
            // 
            // uC_tb_password1
            // 
            uC_tb_password1.ETIQUETA = "Nueva contraseña:";
            uC_tb_password1.Location = new Point(6, 334);
            uC_tb_password1.Name = "uC_tb_password1";
            uC_tb_password1.REQUERIDO = false;
            uC_tb_password1.Size = new Size(200, 46);
            uC_tb_password1.TabIndex = 4;
            uC_tb_password1.TEXT_BOX = "";
            // 
            // uC_tb_numerico1
            // 
            uC_tb_numerico1.ETIQUETA = "DNI:";
            uC_tb_numerico1.Location = new Point(6, 97);
            uC_tb_numerico1.Name = "uC_tb_numerico1";
            uC_tb_numerico1.REQUERIDO = false;
            uC_tb_numerico1.Size = new Size(200, 46);
            uC_tb_numerico1.TabIndex = 3;
            uC_tb_numerico1.TEXT_BOX = "";
            // 
            // uC_textbox3
            // 
            uC_textbox3.ETIQUETA = "Mail:";
            uC_textbox3.Location = new Point(6, 246);
            uC_textbox3.Name = "uC_textbox3";
            uC_textbox3.REQUERIDO = false;
            uC_textbox3.Size = new Size(200, 46);
            uC_textbox3.TabIndex = 2;
            uC_textbox3.TEXT_BOX = "";
            // 
            // uC_textbox2
            // 
            uC_textbox2.ETIQUETA = "Apellido:";
            uC_textbox2.Location = new Point(6, 56);
            uC_textbox2.Name = "uC_textbox2";
            uC_textbox2.REQUERIDO = false;
            uC_textbox2.Size = new Size(200, 45);
            uC_textbox2.TabIndex = 1;
            uC_textbox2.TEXT_BOX = "";
            // 
            // uC_textbox1
            // 
            uC_textbox1.ETIQUETA = "Nombre:";
            uC_textbox1.Location = new Point(6, 14);
            uC_textbox1.Name = "uC_textbox1";
            uC_textbox1.REQUERIDO = false;
            uC_textbox1.Size = new Size(200, 47);
            uC_textbox1.TabIndex = 0;
            uC_textbox1.TEXT_BOX = "";
            // 
            // lb_usuarios
            // 
            lb_usuarios.FormattingEnabled = true;
            lb_usuarios.ItemHeight = 15;
            lb_usuarios.Location = new Point(230, 20);
            lb_usuarios.Name = "lb_usuarios";
            lb_usuarios.Size = new Size(205, 304);
            lb_usuarios.TabIndex = 1;
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(149, 402);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(75, 36);
            btn_guardar.TabIndex = 2;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            btn_nuevo.Location = new Point(12, 402);
            btn_nuevo.Name = "btn_nuevo";
            btn_nuevo.Size = new Size(75, 36);
            btn_nuevo.TabIndex = 3;
            btn_nuevo.Text = "Nuevo";
            btn_nuevo.UseVisualStyleBackColor = true;
            // 
            // btn_desbloquear
            // 
            btn_desbloquear.Location = new Point(230, 329);
            btn_desbloquear.Name = "btn_desbloquear";
            btn_desbloquear.Size = new Size(205, 67);
            btn_desbloquear.TabIndex = 4;
            btn_desbloquear.Text = "Desbloquear usuario";
            btn_desbloquear.UseVisualStyleBackColor = true;
            // 
            // uC_dttmPicker1
            // 
            uC_dttmPicker1.ETIQUETA = "Fecha de nacimiento:";
            uC_dttmPicker1.Location = new Point(6, 139);
            uC_dttmPicker1.Name = "uC_dttmPicker1";
            uC_dttmPicker1.REQUERIDO = false;
            uC_dttmPicker1.Size = new Size(176, 50);
            uC_dttmPicker1.TabIndex = 7;
            // 
            // FormABMUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(446, 450);
            Controls.Add(btn_desbloquear);
            Controls.Add(btn_nuevo);
            Controls.Add(btn_guardar);
            Controls.Add(lb_usuarios);
            Controls.Add(gb_campos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormABMUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - ABM Usuario";
            gb_campos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_campos;
        private ListBox lb_usuarios;
        private Button btn_guardar;
        private Button btn_nuevo;
        private Button btn_desbloquear;
        private UC_tb_password uC_tb_password2;
        private UC_tb_password uC_tb_password1;
        private UC_tb_numerico uC_tb_numerico1;
        private UC_textbox uC_textbox3;
        private UC_textbox uC_textbox2;
        private UC_textbox uC_textbox1;
        private UC_textbox uC_textbox4;
        private UC_dttmPicker uC_dttmPicker1;
    }
}