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
            TraducirComponentes();
            enlazarUsuarios();
            enlazarPerfiles();
        }

        public void TraducirComponentes()
        {
            IDictionary<string, string> traducciones = BLL.IdiomaBLL.INSTANCE.diccionario;

            if (traducciones is not null && traducciones.Count > 0)
            {
                this.Text = traducciones.ContainsKey(this.Name) ? traducciones[this.Name] : this.Text;

                foreach (Control c in this.Controls)
                {
                    //traduzco el texto del componente
                    c.Text = traducciones.ContainsKey(c.Name + "_" + this.Name) ? traducciones[c.Name + "_" + this.Name] : c.Text;

                    //si es un groupbox, recorro todos los componentes que tenga en su interior
                    if (c is GroupBox)
                    {
                        foreach (Control controlChild in ((GroupBox)c).Controls)
                        {
                            if (controlChild is UC_tb_numerico)
                            {
                                ((UC_tb_numerico)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_numerico)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_tb_password)
                            {
                                ((UC_tb_password)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_tb_password)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_textbox)
                            {
                                ((UC_textbox)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_textbox)controlChild).ETIQUETA;
                            }
                            else if (controlChild is UC_dttmPicker)
                            {
                                ((UC_dttmPicker)controlChild).ETIQUETA = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : ((UC_dttmPicker)controlChild).ETIQUETA;
                            }
                            else
                            {
                                controlChild.Text = traducciones.ContainsKey(controlChild.Name + "_" + this.Name) ? traducciones[controlChild.Name + "_" + this.Name] : controlChild.Text;
                            }
                        }
                    }
                }
            }
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
