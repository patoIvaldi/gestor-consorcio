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
            //this.ControlBox = false;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            BLL.UsuarioBLL.Instance.Logout();
            login.Show();
        }

        private void crearModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMUsuario formUsuario = new FormABMUsuario();
            formUsuario.ShowDialog();
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}