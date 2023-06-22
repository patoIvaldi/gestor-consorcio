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
            uC_dttm_fechaNac = new UC_dttmPicker();
            uC_tb_username = new UC_textbox();
            uC_tb_password2 = new UC_tb_password();
            uC_tb_dni = new UC_tb_numerico();
            uC_tb_mail = new UC_textbox();
            uC_tb_apellido = new UC_textbox();
            uC_tb_nombre = new UC_textbox();
            lb_usuarios = new ListBox();
            btn_guardar = new Button();
            btn_limpiar = new Button();
            btn_desbloquear = new Button();
            gb_campos2 = new GroupBox();
            uC_tb_telefono = new UC_tb_numerico();
            uC_tb_nroDepto = new UC_textbox();
            cb_esAdmin = new CheckBox();
            groupBox1 = new GroupBox();
            uC_dttm_finConcesion = new UC_dttmPicker();
            uC_dttm_inicioConcesion = new UC_dttmPicker();
            uC_tb_razonSocial = new UC_textbox();
            uC_tb_empresa = new UC_textbox();
            uC_tb_cuit = new UC_tb_numerico();
            gb_campos.SuspendLayout();
            gb_campos2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gb_campos
            // 
            gb_campos.Controls.Add(uC_dttm_fechaNac);
            gb_campos.Controls.Add(uC_tb_username);
            gb_campos.Controls.Add(uC_tb_password2);
            gb_campos.Controls.Add(uC_tb_dni);
            gb_campos.Controls.Add(uC_tb_mail);
            gb_campos.Controls.Add(uC_tb_apellido);
            gb_campos.Controls.Add(uC_tb_nombre);
            gb_campos.Location = new Point(12, 12);
            gb_campos.Name = "gb_campos";
            gb_campos.Size = new Size(212, 353);
            gb_campos.TabIndex = 0;
            gb_campos.TabStop = false;
            gb_campos.Text = "Información básica:";
            // 
            // uC_dttm_fechaNac
            // 
            uC_dttm_fechaNac.ETIQUETA = "Fecha de nacimiento:";
            uC_dttm_fechaNac.Location = new Point(6, 139);
            uC_dttm_fechaNac.Name = "uC_dttm_fechaNac";
            uC_dttm_fechaNac.REQUERIDO = false;
            uC_dttm_fechaNac.Size = new Size(176, 50);
            uC_dttm_fechaNac.TabIndex = 7;
            uC_dttm_fechaNac.VALOR = new DateTime(0L);
            // 
            // uC_tb_username
            // 
            uC_tb_username.ETIQUETA = "Username:";
            uC_tb_username.Location = new Point(6, 194);
            uC_tb_username.Name = "uC_tb_username";
            uC_tb_username.REQUERIDO = false;
            uC_tb_username.Size = new Size(176, 46);
            uC_tb_username.TabIndex = 6;
            uC_tb_username.TEXT_BOX = "";
            // 
            // uC_tb_password2
            // 
            uC_tb_password2.ETIQUETA = "Nueva contraseña:";
            uC_tb_password2.Location = new Point(6, 292);
            uC_tb_password2.Name = "uC_tb_password2";
            uC_tb_password2.REQUERIDO = false;
            uC_tb_password2.Size = new Size(200, 46);
            uC_tb_password2.TabIndex = 4;
            uC_tb_password2.TEXT_BOX = "";
            // 
            // uC_tb_dni
            // 
            uC_tb_dni.ETIQUETA = "DNI:";
            uC_tb_dni.Location = new Point(6, 97);
            uC_tb_dni.Name = "uC_tb_dni";
            uC_tb_dni.REQUERIDO = false;
            uC_tb_dni.Size = new Size(200, 46);
            uC_tb_dni.TabIndex = 3;
            uC_tb_dni.TEXT_BOX = "";
            // 
            // uC_tb_mail
            // 
            uC_tb_mail.ETIQUETA = "Mail:";
            uC_tb_mail.Location = new Point(6, 246);
            uC_tb_mail.Name = "uC_tb_mail";
            uC_tb_mail.REQUERIDO = false;
            uC_tb_mail.Size = new Size(200, 46);
            uC_tb_mail.TabIndex = 2;
            uC_tb_mail.TEXT_BOX = "";
            // 
            // uC_tb_apellido
            // 
            uC_tb_apellido.ETIQUETA = "Apellido:";
            uC_tb_apellido.Location = new Point(6, 56);
            uC_tb_apellido.Name = "uC_tb_apellido";
            uC_tb_apellido.REQUERIDO = false;
            uC_tb_apellido.Size = new Size(200, 45);
            uC_tb_apellido.TabIndex = 1;
            uC_tb_apellido.TEXT_BOX = "";
            // 
            // uC_tb_nombre
            // 
            uC_tb_nombre.ETIQUETA = "Nombre:";
            uC_tb_nombre.Location = new Point(6, 14);
            uC_tb_nombre.Name = "uC_tb_nombre";
            uC_tb_nombre.REQUERIDO = false;
            uC_tb_nombre.Size = new Size(200, 47);
            uC_tb_nombre.TabIndex = 0;
            uC_tb_nombre.TEXT_BOX = "";
            // 
            // lb_usuarios
            // 
            lb_usuarios.FormattingEnabled = true;
            lb_usuarios.ItemHeight = 15;
            lb_usuarios.Location = new Point(451, 20);
            lb_usuarios.Name = "lb_usuarios";
            lb_usuarios.Size = new Size(205, 409);
            lb_usuarios.TabIndex = 1;
            lb_usuarios.SelectedIndexChanged += lb_usuarios_SelectedIndexChanged;
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(128, 386);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(75, 36);
            btn_guardar.TabIndex = 2;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(28, 386);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 36);
            btn_limpiar.TabIndex = 3;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_desbloquear
            // 
            btn_desbloquear.Location = new Point(237, 371);
            btn_desbloquear.Name = "btn_desbloquear";
            btn_desbloquear.Size = new Size(205, 67);
            btn_desbloquear.TabIndex = 4;
            btn_desbloquear.Text = "Desbloquear usuario";
            btn_desbloquear.UseVisualStyleBackColor = true;
            // 
            // gb_campos2
            // 
            gb_campos2.Controls.Add(uC_tb_telefono);
            gb_campos2.Controls.Add(uC_tb_nroDepto);
            gb_campos2.Location = new Point(230, 12);
            gb_campos2.Name = "gb_campos2";
            gb_campos2.Size = new Size(215, 107);
            gb_campos2.TabIndex = 5;
            gb_campos2.TabStop = false;
            gb_campos2.Text = "Información propietario:";
            // 
            // uC_tb_telefono
            // 
            uC_tb_telefono.ETIQUETA = "Telefono:";
            uC_tb_telefono.Location = new Point(6, 56);
            uC_tb_telefono.Name = "uC_tb_telefono";
            uC_tb_telefono.REQUERIDO = false;
            uC_tb_telefono.Size = new Size(176, 46);
            uC_tb_telefono.TabIndex = 2;
            uC_tb_telefono.TEXT_BOX = "";
            // 
            // uC_tb_nroDepto
            // 
            uC_tb_nroDepto.ETIQUETA = "Nro Departamento:";
            uC_tb_nroDepto.Location = new Point(6, 14);
            uC_tb_nroDepto.Name = "uC_tb_nroDepto";
            uC_tb_nroDepto.REQUERIDO = false;
            uC_tb_nroDepto.Size = new Size(190, 44);
            uC_tb_nroDepto.TabIndex = 1;
            uC_tb_nroDepto.TEXT_BOX = "";
            // 
            // cb_esAdmin
            // 
            cb_esAdmin.AutoSize = true;
            cb_esAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cb_esAdmin.Location = new Point(252, 346);
            cb_esAdmin.Name = "cb_esAdmin";
            cb_esAdmin.Size = new Size(190, 19);
            cb_esAdmin.TabIndex = 0;
            cb_esAdmin.Text = "Es administrador de consorcio";
            cb_esAdmin.UseVisualStyleBackColor = true;
            cb_esAdmin.CheckedChanged += cb_esAdmin_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(uC_dttm_finConcesion);
            groupBox1.Controls.Add(uC_dttm_inicioConcesion);
            groupBox1.Controls.Add(uC_tb_razonSocial);
            groupBox1.Controls.Add(uC_tb_empresa);
            groupBox1.Controls.Add(uC_tb_cuit);
            groupBox1.Location = new Point(230, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(215, 215);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información administrador:";
            // 
            // uC_dttm_finConcesion
            // 
            uC_dttm_finConcesion.ETIQUETA = "Fin concesión:";
            uC_dttm_finConcesion.Location = new Point(105, 147);
            uC_dttm_finConcesion.Name = "uC_dttm_finConcesion";
            uC_dttm_finConcesion.REQUERIDO = false;
            uC_dttm_finConcesion.Size = new Size(107, 62);
            uC_dttm_finConcesion.TabIndex = 4;
            uC_dttm_finConcesion.VALOR = new DateTime(0L);
            // 
            // uC_dttm_inicioConcesion
            // 
            uC_dttm_inicioConcesion.ETIQUETA = "Inicio concesión:";
            uC_dttm_inicioConcesion.Location = new Point(3, 147);
            uC_dttm_inicioConcesion.Name = "uC_dttm_inicioConcesion";
            uC_dttm_inicioConcesion.REQUERIDO = false;
            uC_dttm_inicioConcesion.Size = new Size(105, 52);
            uC_dttm_inicioConcesion.TabIndex = 3;
            uC_dttm_inicioConcesion.VALOR = new DateTime(0L);
            // 
            // uC_tb_razonSocial
            // 
            uC_tb_razonSocial.ETIQUETA = "Razón social:";
            uC_tb_razonSocial.Location = new Point(6, 103);
            uC_tb_razonSocial.Name = "uC_tb_razonSocial";
            uC_tb_razonSocial.REQUERIDO = false;
            uC_tb_razonSocial.Size = new Size(193, 45);
            uC_tb_razonSocial.TabIndex = 2;
            uC_tb_razonSocial.TEXT_BOX = "";
            // 
            // uC_tb_empresa
            // 
            uC_tb_empresa.ETIQUETA = "Nombre empresa:";
            uC_tb_empresa.Location = new Point(6, 58);
            uC_tb_empresa.Name = "uC_tb_empresa";
            uC_tb_empresa.REQUERIDO = false;
            uC_tb_empresa.Size = new Size(193, 47);
            uC_tb_empresa.TabIndex = 1;
            uC_tb_empresa.TEXT_BOX = "";
            // 
            // uC_tb_cuit
            // 
            uC_tb_cuit.ETIQUETA = "CUIT:";
            uC_tb_cuit.Location = new Point(6, 16);
            uC_tb_cuit.Name = "uC_tb_cuit";
            uC_tb_cuit.REQUERIDO = false;
            uC_tb_cuit.Size = new Size(193, 48);
            uC_tb_cuit.TabIndex = 0;
            uC_tb_cuit.TEXT_BOX = "";
            // 
            // FormABMUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(669, 450);
            Controls.Add(groupBox1);
            Controls.Add(gb_campos2);
            Controls.Add(btn_desbloquear);
            Controls.Add(cb_esAdmin);
            Controls.Add(btn_limpiar);
            Controls.Add(btn_guardar);
            Controls.Add(lb_usuarios);
            Controls.Add(gb_campos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormABMUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - ABM Usuario";
            Load += FormABMUsuario_Load;
            gb_campos.ResumeLayout(false);
            gb_campos2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gb_campos;
        private ListBox lb_usuarios;
        private Button btn_guardar;
        private Button btn_limpiar;
        private Button btn_desbloquear;
        private UC_tb_password uC_tb_password2;
        private UC_tb_numerico uC_tb_dni;
        private UC_textbox uC_tb_mail;
        private UC_textbox uC_tb_apellido;
        private UC_textbox uC_tb_nombre;
        private UC_textbox uC_tb_username;
        private UC_dttmPicker uC_dttm_fechaNac;
        private GroupBox gb_campos2;
        private UC_tb_numerico uC_tb_telefono;
        private UC_textbox uC_tb_nroDepto;
        private CheckBox cb_esAdmin;
        private GroupBox groupBox1;
        private UC_dttmPicker uC_dttm_finConcesion;
        private UC_dttmPicker uC_dttm_inicioConcesion;
        private UC_textbox uC_tb_razonSocial;
        private UC_textbox uC_tb_empresa;
        private UC_tb_numerico uC_tb_cuit;
    }
}