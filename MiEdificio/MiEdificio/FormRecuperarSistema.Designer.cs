namespace UI
{
    partial class FormRecuperarSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecuperarSistema));
            groupBox1 = new GroupBox();
            btn_salir = new Button();
            btn_bd = new Button();
            btn_recalcular = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_salir);
            groupBox1.Controls.Add(btn_bd);
            groupBox1.Controls.Add(btn_recalcular);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(216, 210);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Elija una opción:";
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(51, 138);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(123, 52);
            btn_salir.TabIndex = 2;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // btn_bd
            // 
            btn_bd.Location = new Point(51, 80);
            btn_bd.Name = "btn_bd";
            btn_bd.Size = new Size(123, 52);
            btn_bd.TabIndex = 1;
            btn_bd.Text = "Restablecer versión BD";
            btn_bd.UseVisualStyleBackColor = true;
            btn_bd.Click += btn_bd_Click;
            // 
            // btn_recalcular
            // 
            btn_recalcular.Location = new Point(51, 22);
            btn_recalcular.Name = "btn_recalcular";
            btn_recalcular.Size = new Size(123, 52);
            btn_recalcular.TabIndex = 0;
            btn_recalcular.Text = "Recalcular Digitos verificadores";
            btn_recalcular.UseVisualStyleBackColor = true;
            btn_recalcular.Click += btn_recalcular_Click;
            // 
            // FormRecuperarSistema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(240, 234);
            ControlBox = false;
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRecuperarSistema";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Recuperar sistema";
            Load += FormRecuperarSistema_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_salir;
        private Button btn_bd;
        private Button btn_recalcular;
    }
}