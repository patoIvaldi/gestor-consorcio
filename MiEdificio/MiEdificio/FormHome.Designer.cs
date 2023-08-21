namespace MiEdificio
{
    partial class FormHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            crearModificarToolStripMenuItem = new ToolStripMenuItem();
            desbloquearToolStripMenuItem = new ToolStripMenuItem();
            perfilesToolStripMenuItem = new ToolStripMenuItem();
            crearModificarToolStripMenuItem1 = new ToolStripMenuItem();
            asignarToolStripMenuItem = new ToolStripMenuItem();
            idiomasToolStripMenuItem = new ToolStripMenuItem();
            altasToolStripMenuItem = new ToolStripMenuItem();
            generarExpensaToolStripMenuItem = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            cambiarClaveToolStripMenuItem = new ToolStripMenuItem();
            cambiarIdiomaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            reservarSUMToolStripMenuItem = new ToolStripMenuItem();
            gestionesToolStripMenuItem = new ToolStripMenuItem();
            pagarExpensaToolStripMenuItem = new ToolStripMenuItem();
            visualizarDocumentoToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            recaudaciónPorPeríodoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, altasToolStripMenuItem, usuarioToolStripMenuItem, reservasToolStripMenuItem, gestionesToolStripMenuItem, reportesToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usuariosToolStripMenuItem, perfilesToolStripMenuItem, idiomasToolStripMenuItem });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { crearModificarToolStripMenuItem, desbloquearToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(119, 22);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // crearModificarToolStripMenuItem
            // 
            crearModificarToolStripMenuItem.Name = "crearModificarToolStripMenuItem";
            crearModificarToolStripMenuItem.Size = new Size(164, 22);
            crearModificarToolStripMenuItem.Text = "Crear / Modificar";
            crearModificarToolStripMenuItem.Click += crearModificarToolStripMenuItem_Click;
            // 
            // desbloquearToolStripMenuItem
            // 
            desbloquearToolStripMenuItem.Name = "desbloquearToolStripMenuItem";
            desbloquearToolStripMenuItem.Size = new Size(164, 22);
            desbloquearToolStripMenuItem.Text = "Desbloquear";
            desbloquearToolStripMenuItem.Click += desbloquearToolStripMenuItem_Click;
            // 
            // perfilesToolStripMenuItem
            // 
            perfilesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { crearModificarToolStripMenuItem1, asignarToolStripMenuItem });
            perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            perfilesToolStripMenuItem.Size = new Size(119, 22);
            perfilesToolStripMenuItem.Text = "Perfiles";
            // 
            // crearModificarToolStripMenuItem1
            // 
            crearModificarToolStripMenuItem1.Name = "crearModificarToolStripMenuItem1";
            crearModificarToolStripMenuItem1.Size = new Size(164, 22);
            crearModificarToolStripMenuItem1.Text = "Crear / Modificar";
            crearModificarToolStripMenuItem1.Click += crearModificarToolStripMenuItem1_Click;
            // 
            // asignarToolStripMenuItem
            // 
            asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            asignarToolStripMenuItem.Size = new Size(164, 22);
            asignarToolStripMenuItem.Text = "Asignar";
            asignarToolStripMenuItem.Click += asignarToolStripMenuItem_Click;
            // 
            // idiomasToolStripMenuItem
            // 
            idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            idiomasToolStripMenuItem.Size = new Size(119, 22);
            idiomasToolStripMenuItem.Text = "Idiomas";
            idiomasToolStripMenuItem.Click += idiomasToolStripMenuItem_Click;
            // 
            // altasToolStripMenuItem
            // 
            altasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarExpensaToolStripMenuItem });
            altasToolStripMenuItem.Name = "altasToolStripMenuItem";
            altasToolStripMenuItem.Size = new Size(45, 20);
            altasToolStripMenuItem.Text = "Altas";
            // 
            // generarExpensaToolStripMenuItem
            // 
            generarExpensaToolStripMenuItem.Name = "generarExpensaToolStripMenuItem";
            generarExpensaToolStripMenuItem.Size = new Size(161, 22);
            generarExpensaToolStripMenuItem.Text = "Generar expensa";
            generarExpensaToolStripMenuItem.Click += generarExpensaToolStripMenuItem_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cambiarClaveToolStripMenuItem, cambiarIdiomaToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(59, 20);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cambiarClaveToolStripMenuItem
            // 
            cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            cambiarClaveToolStripMenuItem.Size = new Size(159, 22);
            cambiarClaveToolStripMenuItem.Text = "Cambiar clave";
            cambiarClaveToolStripMenuItem.Click += cambiarClaveToolStripMenuItem_Click;
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            cambiarIdiomaToolStripMenuItem.Size = new Size(159, 22);
            cambiarIdiomaToolStripMenuItem.Text = "Cambiar idioma";
            cambiarIdiomaToolStripMenuItem.Click += cambiarIdiomaToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(159, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // reservasToolStripMenuItem
            // 
            reservasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reservarSUMToolStripMenuItem });
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(64, 20);
            reservasToolStripMenuItem.Text = "Reservas";
            // 
            // reservarSUMToolStripMenuItem
            // 
            reservarSUMToolStripMenuItem.Name = "reservarSUMToolStripMenuItem";
            reservarSUMToolStripMenuItem.Size = new Size(146, 22);
            reservarSUMToolStripMenuItem.Text = "Reservar SUM";
            // 
            // gestionesToolStripMenuItem
            // 
            gestionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pagarExpensaToolStripMenuItem, visualizarDocumentoToolStripMenuItem });
            gestionesToolStripMenuItem.Name = "gestionesToolStripMenuItem";
            gestionesToolStripMenuItem.Size = new Size(70, 20);
            gestionesToolStripMenuItem.Text = "Gestiones";
            // 
            // pagarExpensaToolStripMenuItem
            // 
            pagarExpensaToolStripMenuItem.Name = "pagarExpensaToolStripMenuItem";
            pagarExpensaToolStripMenuItem.Size = new Size(189, 22);
            pagarExpensaToolStripMenuItem.Text = "Pagar expensa";
            pagarExpensaToolStripMenuItem.Click += pagarExpensaToolStripMenuItem_Click;
            // 
            // visualizarDocumentoToolStripMenuItem
            // 
            visualizarDocumentoToolStripMenuItem.Name = "visualizarDocumentoToolStripMenuItem";
            visualizarDocumentoToolStripMenuItem.Size = new Size(189, 22);
            visualizarDocumentoToolStripMenuItem.Text = "Visualizar Documento";
            visualizarDocumentoToolStripMenuItem.Click += visualizarDocumentoToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recaudaciónPorPeríodoToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // recaudaciónPorPeríodoToolStripMenuItem
            // 
            recaudaciónPorPeríodoToolStripMenuItem.Name = "recaudaciónPorPeríodoToolStripMenuItem";
            recaudaciónPorPeríodoToolStripMenuItem.Size = new Size(207, 22);
            recaudaciónPorPeríodoToolStripMenuItem.Text = "Recaudación por período";
            recaudaciónPorPeríodoToolStripMenuItem.Click += recaudaciónPorPeríodoToolStripMenuItem_Click;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiEdificio";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormHome_FormClosing;
            Load += Home_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem crearModificarToolStripMenuItem;
        private ToolStripMenuItem desbloquearToolStripMenuItem;
        private ToolStripMenuItem altasToolStripMenuItem;
        private ToolStripMenuItem generarExpensaToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem reservarSUMToolStripMenuItem;
        private ToolStripMenuItem gestionesToolStripMenuItem;
        private ToolStripMenuItem pagarExpensaToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem visualizarDocumentoToolStripMenuItem;
        private ToolStripMenuItem perfilesToolStripMenuItem;
        private ToolStripMenuItem crearModificarToolStripMenuItem1;
        private ToolStripMenuItem asignarToolStripMenuItem;
        private ToolStripMenuItem idiomasToolStripMenuItem;
        private ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private ToolStripMenuItem recaudaciónPorPeríodoToolStripMenuItem;
    }
}