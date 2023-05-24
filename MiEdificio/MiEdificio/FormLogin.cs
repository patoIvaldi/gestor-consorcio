using BE;
using MiEdificio;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            lbl_pie.Text = lbl_pie.Text + DateTime.Now.Year.ToString();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            // Ajustar la posición de los controles para centrarlos
            foreach (Control control in this.Controls)
            {
                if (control.Name.Equals(this.pb_logo.Name))
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = ((this.Height - control.Height) / 2) - 200;
                }
                else if (control.Name.Equals(this.lbl_pie.Name))
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = ((this.Height - control.Height) / 2) + 300;
                }
                else
                {
                    control.Left = (this.Width - control.Width) / 2;
                    control.Top = (this.Height - control.Height) / 2;
                }
            }
        }

        //Logica del boton ingresar
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarControles())
                {
                    BE.Usuario usuario = new BE.Usuario(
                        tb_usuario.TEXT_BOX, tb_password.TEXT_BOX);

                    if (IniciarLogin(usuario))
                    {
                        FormHome form = new FormHome();
                        form.ShowDialog();
                        Limpiar();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error, credenciales incorrectas.");
                    }
                } else
                {
                    MessageBox.Show("Error, complete todos los campos requeridos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error con el logueo"); //TODO definir esto despues
            }
        }

        private Boolean IniciarLogin(Usuario user)
        {
            if (user.USERNAME.Equals("admin") && user.CONTRASENIA.Equals("admin"))
            {
                return true;
            }
        

            return false;
        }

        //limpieza de inputs
        private void Limpiar()
        {
            tb_usuario.TEXT_BOX = string.Empty;
            tb_password.TEXT_BOX = string.Empty;
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControles()
        {
            Boolean validacionOK = true;

            foreach (Control c in groupBox1.Controls)
            {
                //itero hasta encontrar alguno incorrecto
                if (validacionOK)
                {
                    if (c is UC_textbox)
                    {
                        validacionOK = ((UC_textbox)c).validar();
                    }
                    else if (c is UC_tb_password)
                    {
                        validacionOK = ((UC_tb_password)c).validar();
                    }
                }
            }
            return validacionOK;
        }
    }
}
