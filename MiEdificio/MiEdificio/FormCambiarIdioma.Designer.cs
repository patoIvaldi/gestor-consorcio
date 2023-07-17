namespace UI
{
    partial class FormCambiarIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiarIdioma));
            gb_cambiarIdioma = new GroupBox();
            btn_cambiar = new Button();
            cb_idioma = new ComboBox();
            gb_cambiarIdioma.SuspendLayout();
            SuspendLayout();
            // 
            // gb_cambiarIdioma
            // 
            gb_cambiarIdioma.Controls.Add(btn_cambiar);
            gb_cambiarIdioma.Controls.Add(cb_idioma);
            gb_cambiarIdioma.Location = new Point(12, 12);
            gb_cambiarIdioma.Name = "gb_cambiarIdioma";
            gb_cambiarIdioma.Size = new Size(219, 83);
            gb_cambiarIdioma.TabIndex = 0;
            gb_cambiarIdioma.TabStop = false;
            gb_cambiarIdioma.Text = "Cambiar Idioma:";
            // 
            // btn_cambiar
            // 
            btn_cambiar.Location = new Point(68, 51);
            btn_cambiar.Name = "btn_cambiar";
            btn_cambiar.Size = new Size(75, 23);
            btn_cambiar.TabIndex = 1;
            btn_cambiar.Text = "Cambiar";
            btn_cambiar.UseVisualStyleBackColor = true;
            btn_cambiar.Click += btn_cambiar_Click;
            // 
            // cb_idioma
            // 
            cb_idioma.FormattingEnabled = true;
            cb_idioma.Location = new Point(41, 22);
            cb_idioma.Name = "cb_idioma";
            cb_idioma.Size = new Size(121, 23);
            cb_idioma.TabIndex = 0;
            cb_idioma.SelectedIndexChanged += cb_idioma_SelectedIndexChanged;
            // 
            // FormCambiarIdioma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(239, 107);
            Controls.Add(gb_cambiarIdioma);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormCambiarIdioma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Cambiar idioma";
            Load += FormCambiarIdioma_Load;
            gb_cambiarIdioma.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gb_cambiarIdioma;
        private Button btn_cambiar;
        private ComboBox cb_idioma;
    }
}