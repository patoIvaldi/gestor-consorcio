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

        private void Home_Load(object sender, EventArgs e)
        {

        }

        //menu cerrar sesion
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}