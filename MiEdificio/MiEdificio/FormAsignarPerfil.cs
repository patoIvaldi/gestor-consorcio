using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormAsignarPerfil : Form
    {
        public FormAsignarPerfil()
        {
            InitializeComponent();
        }

        private void FormAsignarPerfil_Load(object sender, EventArgs e)
        {
            enlazarUsuarios();
            enlazarPerfiles();
        }

        private void enlazarUsuarios()
        {
            cb_usuarios.Items.Clear();
            cb_usuarios.Items.AddRange(UsuarioBLL.Instance.listarUsuarios().ToArray());
        }

        private void enlazarPerfiles()
        {
            cb_perfiles.Items.Clear();
            cb_perfiles.Items.AddRange(PerfilBLL.Instance.ObtenerPerfiles().ToArray());
        }

        //logico boton asignar
        private void btn_asignar_Click(object sender, EventArgs e)
        {
            if (cb_perfiles.SelectedItem is not null
                && cb_usuarios.SelectedItem is not null)
            {
                BE.Perfil perfilSelected = (BE.Perfil)cb_perfiles.SelectedItem;
                BE.Usuario usuarioSelected = (BE.Usuario)cb_usuarios.SelectedItem;

                if (UsuarioBLL.Instance.CambiarPerfilUsuario(
                    usuarioSelected,perfilSelected))
                {
                    MessageBox.Show("Perfil cambiado con éxito!");
                }
                else
                {
                    MessageBox.Show("Error, no se pudo cambiar el perfil al usuario.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario y un perfil.");
            }
        }
    }
}
