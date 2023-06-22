using BE;
using BLL;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormABMUsuario : Form
    {

        private BE.Usuario usuarioConectado = Services.ServiceSesion.Instance.USER;

        public FormABMUsuario()
        {
            InitializeComponent();
        }

        //logica boton guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (BLL.UsuarioBLL.Instance.insertarOEditarUsuario(armarUsuario())) {

                MessageBox.Show("Usuario creado/modificado con exito.");
                enlazar();
            }
            else
            {
                MessageBox.Show("Error, ocurrió un problema con la persistencia del usuario.");
            }
        }

        //metodo que arma el usuario en base a los campos del formulario
        private BE.Usuario armarUsuario()
        {
            BE.Usuario newUser = new BE.Usuario();
            newUser.USERNAME = uC_tb_username.TEXT_BOX;
            newUser.MAIL = uC_tb_mail.TEXT_BOX;
            newUser.CONTRASENIA = uC_tb_password2.TEXT_BOX;

            if (cb_esAdmin.Checked is true)
            {
                newUser.PERSONA = new BE.AdministradorConsorcio();
                ((BE.AdministradorConsorcio)newUser.PERSONA).CUIT = uC_tb_cuit.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).NOMBRE_EMPRESA = uC_tb_empresa.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).RAZON_SOCIAL = uC_tb_razonSocial.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).FECHA_INICIO_CONCESION =
                    uC_dttm_inicioConcesion.VALOR.HasValue?uC_dttm_inicioConcesion.VALOR.Value.Date:null;
                ((BE.AdministradorConsorcio)newUser.PERSONA).FECHA_FIN_CONCESION =
                    uC_dttm_finConcesion.VALOR.HasValue?uC_dttm_finConcesion.VALOR.Value.Date:null;

            }
            else
            {
                newUser.PERSONA = new BE.Propietario();
                ((BE.Propietario)newUser.PERSONA).NRO_DEPARTAMENTO = uC_tb_nroDepto.TEXT_BOX;
                ((BE.Propietario)newUser.PERSONA).NRO_TELEFONO = long.Parse(uC_tb_telefono.TEXT_BOX);
            }

            newUser.PERSONA.DNI = long.Parse(uC_tb_dni.TEXT_BOX);
            newUser.PERSONA.NOMBRE = uC_tb_nombre.TEXT_BOX;
            newUser.PERSONA.APELLIDO = uC_tb_apellido.TEXT_BOX;
            newUser.PERSONA.FECHA_NACIMIENTO =
                uC_dttm_fechaNac.VALOR.HasValue?uC_dttm_fechaNac.VALOR.Value.Date:null;

            return newUser;
        }

        //limpia el form
        private void limpiar()
        {
            uC_tb_nombre.TEXT_BOX = "";
            uC_tb_apellido.TEXT_BOX = "";
            uC_tb_dni.TEXT_BOX = "";
            uC_dttm_fechaNac.resetear();
            uC_tb_username.TEXT_BOX = "";
            uC_tb_password2.TEXT_BOX = "";
            uC_tb_nroDepto.TEXT_BOX = "";
            uC_tb_telefono.TEXT_BOX = "";
            uC_tb_cuit.TEXT_BOX = "";
            uC_tb_empresa.TEXT_BOX = "";
            uC_tb_razonSocial.TEXT_BOX = "";
            uC_tb_mail.TEXT_BOX = "";
            uC_dttm_inicioConcesion.resetear();
            uC_dttm_finConcesion.resetear();

            cb_esAdmin.Checked = false;

            uC_tb_dni.Enabled = true;
            uC_tb_username.Enabled = true;

            uC_tb_nroDepto.Enabled = false;
            uC_tb_telefono.Enabled = false;
            uC_tb_cuit.Enabled = false;
            uC_tb_empresa.Enabled = false;
            uC_tb_razonSocial.Enabled = false;
            uC_dttm_inicioConcesion.Enabled = false;
            uC_dttm_finConcesion.Enabled = false;
        }

        //enlazo en la grilla
        private void enlazar()
        {
            lb_usuarios.DataSource = null;
            if (usuarioConectado.PERSONA is BE.AdministradorConsorcio)
            {
                lb_usuarios.DataSource = BLL.UsuarioBLL.Instance.listarUsuarios();
            }
            else
            {
                List<BE.Usuario> usuarios = new List<Usuario>();
                usuarios.Add(usuarioConectado);
                lb_usuarios.DataSource = usuarios;
            }
        }

        //logica del boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void FormABMUsuario_Load(object sender, EventArgs e)
        {
            uC_tb_username.Enabled = false;
            uC_tb_dni.Enabled = false;
            btn_desbloquear.Enabled = false;
            enlazar();
        }

        private void cargarCampos()
        {
            BE.Usuario userSeleccionado = (BE.Usuario)lb_usuarios.SelectedItem;

            if (userSeleccionado is not null)
            {
                uC_tb_dni.Enabled = false;
                uC_tb_username.Enabled = false;

                uC_tb_nombre.TEXT_BOX = userSeleccionado.PERSONA.NOMBRE;
                uC_tb_apellido.TEXT_BOX = userSeleccionado.PERSONA.APELLIDO;
                uC_tb_dni.TEXT_BOX = userSeleccionado.PERSONA.DNI.ToString();
                uC_dttm_fechaNac.VALOR = userSeleccionado.PERSONA.FECHA_NACIMIENTO;
                uC_tb_mail.TEXT_BOX = userSeleccionado.MAIL;
                uC_tb_username.TEXT_BOX = userSeleccionado.USERNAME;
                btn_desbloquear.Enabled = userSeleccionado.ESTA_BLOQUEADO;

                if (userSeleccionado.PERSONA is BE.Propietario)
                {
                    uC_tb_nroDepto.TEXT_BOX = ((BE.Propietario)userSeleccionado.PERSONA).NRO_DEPARTAMENTO;
                    uC_tb_telefono.TEXT_BOX = ((BE.Propietario)userSeleccionado.PERSONA).NRO_TELEFONO.ToString();
                    cb_esAdmin.Checked = false;
                    uC_tb_cuit.Enabled = false;
                    uC_tb_cuit.TEXT_BOX = "";
                    uC_tb_empresa.Enabled = false;
                    uC_tb_empresa.TEXT_BOX = "";
                    uC_tb_razonSocial.Enabled = false;
                    uC_tb_razonSocial.TEXT_BOX = "";
                    uC_dttm_inicioConcesion.Enabled = false;
                    uC_dttm_inicioConcesion.resetear();
                    uC_dttm_finConcesion.Enabled = false;
                    uC_dttm_finConcesion.resetear();

                }
                else
                {
                    uC_tb_cuit.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).CUIT;
                    uC_tb_empresa.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).NOMBRE_EMPRESA;
                    uC_tb_razonSocial.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).RAZON_SOCIAL;
                    uC_dttm_inicioConcesion.VALOR = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).FECHA_INICIO_CONCESION;
                    uC_dttm_finConcesion.VALOR = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).FECHA_FIN_CONCESION;
                    cb_esAdmin.Checked = true;
                    uC_tb_nroDepto.Enabled = false;
                    uC_tb_nroDepto.TEXT_BOX = "";
                    uC_tb_telefono.Enabled = false;
                    uC_tb_telefono.TEXT_BOX = "";

                }
            }
        }

        private void lb_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos();

        }

        private void cb_esAdmin_CheckedChanged(object sender, EventArgs e)
        {
            uC_tb_nroDepto.Enabled = !cb_esAdmin.Checked;
            uC_tb_telefono.Enabled = !cb_esAdmin.Checked;
            uC_tb_cuit.Enabled = cb_esAdmin.Checked;
            uC_tb_empresa.Enabled = cb_esAdmin.Checked;
            uC_tb_razonSocial.Enabled = cb_esAdmin.Checked;
            uC_dttm_inicioConcesion.Enabled = cb_esAdmin.Checked;
            uC_dttm_finConcesion.Enabled = cb_esAdmin.Checked;
        }
    }
}
