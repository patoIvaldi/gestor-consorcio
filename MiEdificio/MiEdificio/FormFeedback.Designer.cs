namespace UI
{
    partial class FormFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFeedback));
            dgv_reserva = new DataGridView();
            groupBox1 = new GroupBox();
            btn_guardar = new Button();
            rt_feedback = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_reserva).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_reserva
            // 
            dgv_reserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_reserva.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_reserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_reserva.Location = new Point(12, 12);
            dgv_reserva.MultiSelect = false;
            dgv_reserva.Name = "dgv_reserva";
            dgv_reserva.ReadOnly = true;
            dgv_reserva.RowTemplate.Height = 25;
            dgv_reserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_reserva.Size = new Size(904, 74);
            dgv_reserva.TabIndex = 0;
            dgv_reserva.CellClick += dgv_reserva_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_guardar);
            groupBox1.Controls.Add(rt_feedback);
            groupBox1.Location = new Point(12, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(904, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detallar feedback:";
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(808, 34);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(90, 47);
            btn_guardar.TabIndex = 1;
            btn_guardar.Text = "Enviar feedback";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // rt_feedback
            // 
            rt_feedback.Location = new Point(6, 22);
            rt_feedback.Name = "rt_feedback";
            rt_feedback.Size = new Size(643, 72);
            rt_feedback.TabIndex = 0;
            rt_feedback.Text = "";
            rt_feedback.TextChanged += rt_feedback_TextChanged;
            // 
            // FormFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(928, 205);
            Controls.Add(groupBox1);
            Controls.Add(dgv_reserva);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormFeedback";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio - Enviar feedback reserva";
            Load += FormFeedback_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_reserva).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_reserva;
        private GroupBox groupBox1;
        private RichTextBox rt_feedback;
        private Button btn_guardar;
    }
}