using BE;
using MiEdificio;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Properties;

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

            enlazar();
        }

        public void enlazar()
        {
            //recupero los idiomas configurados y los cargo en la pantalla
            cb_idioma.DataSource = null;
            cb_idioma.DataSource = BLL.IdiomaBLL.INSTANCE.Listar();
            cb_idioma.DisplayMember = "DESCRIPCION";
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
                        tb_usuario.TEXT_BOX.Trim(), tb_password.TEXT_BOX.Trim());

                    if (IniciarLogin(usuario))
                    {
                        FormHome form = new FormHome(this);
                        form.Show(this);
                        Limpiar();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error, credenciales incorrectas.");
                    }
                }
                else
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
            Boolean existe = false;

            if (!BLL.UsuarioBLL.Instance.esUsuarioBloqueado(user.USERNAME))
            {
                //En base al username y pass, busco la entidad en la BD.
                user = BLL.UsuarioBLL.Instance.Login(user,
                    (ServiceIdioma)cb_idioma.SelectedItem);

                if (user != null)
                {
                    existe = true;
                }
            }
            else
            {
                MessageBox.Show("El usuario se encuentra bloqueado, contactar a un administrador.");
            }

            return existe;
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

        //metodo que se dispara cuando elige una opcion del combobox de idioma
        private void cb_idioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Services.ServiceIdioma idiomaElegido = (Services.ServiceIdioma)cb_idioma.SelectedItem;

            if (idiomaElegido is not null)
            {
                TraducirComponentes(
                    BLL.IdiomaBLL.INSTANCE.ListarTraducciones(idiomaElegido));
            }
        }

        private void TraducirComponentes(IDictionary<string,string> traducciones)
        {
            if (traducciones is not null && traducciones.Count > 0)
            {
                tb_usuario.ETIQUETA = traducciones.ContainsKey(tb_usuario.Name+"_"+this.Name)? traducciones[tb_usuario.Name + "_" + this.Name]: tb_usuario.ETIQUETA;
                tb_password.ETIQUETA = traducciones.ContainsKey(tb_password.Name+"_"+this.Name)? traducciones[tb_password.Name + "_" + this.Name]: tb_password.ETIQUETA;
                btn_ingresar.Text = traducciones.ContainsKey(btn_ingresar.Name+"_"+this.Name)? traducciones[btn_ingresar.Name + "_" + this.Name]: btn_ingresar.Text;
            }
        }
    }
}
