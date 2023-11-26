using BE;
using System.Diagnostics;
using UI;

namespace MiEdificio
{
    public partial class FormHome : Form
    {
        public FormHome(FormLogin login)
        {
            this.login = login;
            InitializeComponent();
        }

        FormLogin login;
        public Boolean necesitaReiniciar = false;

        private void Home_Load(object sender, EventArgs e)
        {
            necesitaReiniciar = false;

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó al Home.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.Home.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

            if (BLL.UsuarioBLL.Instance.userOut is not null)
            {
                adminToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.ABM_Admin);
                altasToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.ABM_Altas);
                usuarioToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.ABM_Usuario);
                reservasToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.ABM_Reservas);
                pagarExpensaToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.ABM_Gestiones);
                visualizarDocumentoToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.Lectura_Gestiones);
                reportesToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.Lectura_Reportes);
                ayudaToolStripMenuItem.Enabled = BLL.UsuarioBLL.Instance.ExistePermiso(PermisosConstantes.Lectura_Ayuda);
            }

            TraducirComponentes();
            //chequear digitos verificadores del sistema
            chequearIDVSistema();
        }

        private void chequearIDVSistema()
        {
            Boolean sistemaOK = true;

            //validamos que el hash de la tabla USUARIO este correcto.
            sistemaOK = BLL.HashGlobalBLL.Instance.ExisteHash(
                BLL.UsuarioBLL.Instance.RecalcularHashGlobalUsuarios());

            if (!sistemaOK)
            {
                //bloqueamos el sistema y disparamos pop-up con accionar
                MessageBox.Show("Se detectó una vulneración en el sistema. Por favor, proceda a solucionarlo según el siguiente menú de opciones.");
                FormRecuperarSistema formRecuperacion = new FormRecuperarSistema(this);
                formRecuperacion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sistema congruente.");
            }
        }

        public void TraducirComponentes()
        {
            IDictionary<string, string> traducciones = BLL.IdiomaBLL.INSTANCE.diccionario;

            foreach (ToolStripItem menu in menuStrip1.Items)
            {
                menu.Text = traducciones is not null && traducciones.ContainsKey(menu.Name) ? traducciones[menu.Name] : menu.Text;

                //verifico que sea un menu
                if (menu is ToolStripMenuItem)
                {
                    // iteramos sobre los submenús en caso de tener
                    foreach (ToolStripItem subMenu in ((ToolStripMenuItem)menu).DropDownItems)
                    {
                        subMenu.Text = traducciones is not null && traducciones.ContainsKey(subMenu.Name) ? traducciones[subMenu.Name] : subMenu.Text;

                        //verifico si tiene mas subsubmenues
                        if (subMenu is ToolStripMenuItem)
                        {
                            foreach (ToolStripItem ssubmenu in ((ToolStripMenuItem)subMenu).DropDownItems)
                            {
                                ssubmenu.Text = traducciones is not null && traducciones.ContainsKey(ssubmenu.Name) ? traducciones[ssubmenu.Name] : ssubmenu.Text;
                            }
                        }
                    }
                }
            }
        }

        //menu cerrar sesion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario cerró la sesion";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Cerrar.ToString();
            evento.MODULO = Enumerador.Modulo.CierreSesion.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);
            cerrarSesion();
        }

        public void cerrarSesion()
        {
            this.Close();
            BLL.UsuarioBLL.Instance.Logout();
            login.enlazar();
            login.Show();
        }

        //menu ABM personas-usuarios
        private void crearModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMUsuario formUsuario = new FormABMUsuario(1);
            formUsuario.ShowDialog();
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLL.UsuarioBLL.Instance.Logout();
            login.enlazar();
            login.Show();
        }

        //menu para cambiar la clave del usuario
        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMUsuario formUsuario = new FormABMUsuario(3);
            formUsuario.ShowDialog();
        }

        //menu para desbloquear usuario
        private void desbloquearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMUsuario formUsuario = new FormABMUsuario(2);
            formUsuario.ShowDialog();
        }

        //menu ABM idioma
        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIdioma formIdioma = new FormIdioma();
            formIdioma.ShowDialog();
        }

        //menu ABM perfil
        private void crearModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormABMPerfil formPerfil = new FormABMPerfil();
            formPerfil.ShowDialog();
        }

        //menu asignar perfil a usuario
        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignarPerfil formAsignarPerfil = new FormAsignarPerfil();
            formAsignarPerfil.ShowDialog();
        }

        //menu pagar expensas
        private void pagarExpensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPagarExpensas formPagar = new FormPagarExpensas(1);
            formPagar.Owner = this;
            formPagar.ShowDialog();
        }

        //menu visualizar documento
        private void visualizarDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPagarExpensas formPagar = new FormPagarExpensas(2);
            formPagar.ShowDialog();
        }

        //menu generar expensa
        private void generarExpensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerarExpensa formGenerar = new FormGenerarExpensa();
            formGenerar.ShowDialog();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCambiarIdioma formCambiarIdioma = new FormCambiarIdioma(this);
            formCambiarIdioma.ShowDialog();
        }

        private void recaudaciónPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteRecaudacion formReporteRecaudacion = new FormReporteRecaudacion();
            formReporteRecaudacion.ShowDialog();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEventos formEventos = new FormEventos();
            formEventos.ShowDialog();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormControlCambios formControlcambios = new FormControlCambios();
            formControlcambios.ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRespaldo formRespaldo = new FormRespaldo();
            formRespaldo.ShowDialog();
        }

        private void reservarSUMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerarReserva formReserva = new FormGenerarReserva("Salón de usos múltiples (SUM)");
            formReserva.ShowDialog();
        }

        private void generarÁreaComúnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMAreaComun formABMAreaComun = new FormABMAreaComun();
            formABMAreaComun.ShowDialog();
        }

        private void reporteInteligenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteInteligente formInteligente = new FormReporteInteligente();
            formInteligente.ShowDialog();
        }

        private void cantidadDeReservasPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteCantReservas formCantReservas = new FormReporteCantReservas();
            formCantReservas.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaArchivoPDF = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\archivos\\Manual.pdf";

                // Abrir el manual en PDF con el programa predeterminado del sistema
                Process.Start(new ProcessStartInfo(rutaArchivoPDF) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo PDF: " + ex.Message);
            }
        }
    }
}