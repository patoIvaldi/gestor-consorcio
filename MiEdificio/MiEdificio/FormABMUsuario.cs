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
        private int llamadaMenu = 0;

        public FormABMUsuario(int numMenu)
        {
            llamadaMenu = numMenu;
            InitializeComponent();
        }

        //logica boton guardar
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                if (!BLL.UsuarioBLL.Instance.existeUsuario(uC_tb_username.TEXT_BOX)
                    && string.IsNullOrEmpty(uC_tb_password2.TEXT_BOX))
                {
                    MessageBox.Show("Debe ingresar la contraseña para el nuevo usuario.");
                }
                else
                {
                    if (BLL.UsuarioBLL.Instance.insertarOEditarUsuario(armarUsuario()))
                    {
                        enlazar();

                        if (llamadaMenu == 3)
                        {
                            grisarTodo();
                            uC_tb_password2.TEXT_BOX = "";
                            MessageBox.Show("Contraseña modificada con éxito.");
                        }
                        else
                        {
                            limpiar();
                            MessageBox.Show("Usuario creado/modificado con éxito.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, ocurrió un problema con la persistencia del usuario.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos requeridos.");
            }
        }

        //metodo que arma el usuario en base a los campos del formulario
        private BE.Usuario armarUsuario()
        {
            BE.Usuario newUser = new BE.Usuario();
            newUser.USERNAME = uC_tb_username.TEXT_BOX;
            newUser.MAIL = uC_tb_mail.TEXT_BOX;
            newUser.CONTRASENIA = uC_tb_password2.TEXT_BOX;
            BE.Perfil perfil = new BE.Perfil();

            if (cb_esAdmin.Checked is true)
            {
                perfil.ID_TIPO = 1;
                newUser.PERSONA = new BE.AdministradorConsorcio();
                ((BE.AdministradorConsorcio)newUser.PERSONA).CUIT = uC_tb_cuit.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).NOMBRE_EMPRESA = uC_tb_empresa.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).RAZON_SOCIAL = uC_tb_razonSocial.TEXT_BOX;
                ((BE.AdministradorConsorcio)newUser.PERSONA).FECHA_INICIO_CONCESION =
                    uC_dttm_inicioConcesion.VALOR.HasValue ? uC_dttm_inicioConcesion.VALOR.Value.Date : null;
                ((BE.AdministradorConsorcio)newUser.PERSONA).FECHA_FIN_CONCESION =
                    uC_dttm_finConcesion.VALOR.HasValue ? uC_dttm_finConcesion.VALOR.Value.Date : null;

            }
            else
            {
                perfil.ID_TIPO = 2;
                newUser.PERSONA = new BE.Propietario();
                if (!string.IsNullOrEmpty(uC_tb_nroDepto.TEXT_BOX)) { ((BE.Propietario)newUser.PERSONA).NRO_DEPARTAMENTO = uC_tb_nroDepto.TEXT_BOX; }
                if (!string.IsNullOrEmpty(uC_tb_telefono.TEXT_BOX)) { ((BE.Propietario)newUser.PERSONA).NRO_TELEFONO = long.Parse(uC_tb_telefono.TEXT_BOX); }
            }

            newUser.PERSONA.DNI = long.Parse(uC_tb_dni.TEXT_BOX);
            newUser.PERSONA.NOMBRE = uC_tb_nombre.TEXT_BOX;
            newUser.PERSONA.APELLIDO = uC_tb_apellido.TEXT_BOX;
            newUser.PERSONA.FECHA_NACIMIENTO =
                uC_dttm_fechaNac.VALOR.HasValue ? uC_dttm_fechaNac.VALOR.Value.Date : null;
            newUser.PERFIL = perfil;

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

            uC_tb_nroDepto.Enabled = true;
            uC_tb_telefono.Enabled = true;
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
            if (usuarioConectado.PERSONA is BE.AdministradorConsorcio) //esto hay que validar por permisos
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
            if (llamadaMenu == 2 || llamadaMenu == 3) { grisarTodo(); }
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
                if (llamadaMenu == 2) { btn_desbloquear.Enabled = userSeleccionado.ESTA_BLOQUEADO; }

                if (userSeleccionado.PERSONA is BE.Propietario)
                {
                    cb_esAdmin.Checked = false;
                    uC_tb_nroDepto.TEXT_BOX = ((BE.Propietario)userSeleccionado.PERSONA).NRO_DEPARTAMENTO;
                    uC_tb_telefono.TEXT_BOX = ((BE.Propietario)userSeleccionado.PERSONA).NRO_TELEFONO.ToString();
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
                    cb_esAdmin.Checked = true;
                    uC_tb_cuit.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).CUIT;
                    uC_tb_empresa.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).NOMBRE_EMPRESA;
                    uC_tb_razonSocial.TEXT_BOX = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).RAZON_SOCIAL;
                    uC_dttm_inicioConcesion.VALOR = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).FECHA_INICIO_CONCESION;
                    uC_dttm_finConcesion.VALOR = ((BE.AdministradorConsorcio)userSeleccionado.PERSONA).FECHA_FIN_CONCESION;
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
            uC_tb_nroDepto.TEXT_BOX = "";
            uC_tb_telefono.Enabled = !cb_esAdmin.Checked;
            uC_tb_telefono.TEXT_BOX = "";
            uC_tb_cuit.Enabled = cb_esAdmin.Checked;
            uC_tb_cuit.TEXT_BOX = "";
            uC_tb_empresa.Enabled = cb_esAdmin.Checked;
            uC_tb_empresa.TEXT_BOX = "";
            uC_tb_razonSocial.Enabled = cb_esAdmin.Checked;
            uC_tb_razonSocial.TEXT_BOX = "";
            uC_dttm_inicioConcesion.Enabled = cb_esAdmin.Checked;
            uC_dttm_inicioConcesion.resetear();
            uC_dttm_finConcesion.Enabled = cb_esAdmin.Checked;
            uC_dttm_finConcesion.resetear();
            if (llamadaMenu == 2 || llamadaMenu == 3) { grisarTodo(); }
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControles()
        {
            Boolean validacionOK = true;

            foreach (Control c in gb_campos.Controls)
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
                    else if (c is UC_tb_numerico)
                    {
                        validacionOK = ((UC_tb_numerico)c).validar();
                    }
                    else if (c is UC_dttmPicker)
                    {
                        validacionOK = ((UC_dttmPicker)c).validar();
                    }
                }
            }
            return validacionOK;
        }

        private void grisarTodo()
        {
            uC_tb_nombre.Enabled = false;
            uC_tb_apellido.Enabled = false;
            uC_tb_dni.Enabled = false;
            uC_dttm_fechaNac.Enabled = false;
            uC_tb_username.Enabled = false;
            uC_tb_mail.Enabled = false;
            if (llamadaMenu != 3) { uC_tb_password2.Enabled = false; }
            uC_tb_nroDepto.Enabled = false;
            uC_tb_telefono.Enabled = false;
            uC_tb_cuit.Enabled = false;
            uC_tb_empresa.Enabled = false;
            uC_tb_razonSocial.Enabled = false;
            uC_dttm_inicioConcesion.Enabled = false;
            uC_dttm_finConcesion.Enabled = false;
            cb_esAdmin.Enabled = false;
            btn_limpiar.Enabled = false;
            if (llamadaMenu != 2) { btn_desbloquear.Enabled = false; }
            if (llamadaMenu != 3) { btn_guardar.Enabled = false; }
        }

        //logica boton desbloquear usuario
        private void btn_desbloquear_Click(object sender, EventArgs e)
        {
            BE.Usuario userSeleccionado = (BE.Usuario)lb_usuarios.SelectedItem;

            if (userSeleccionado is not null)
            {
                if (BLL.UsuarioBLL.Instance.bloquearDesbloquearUsuario(userSeleccionado.USERNAME))
                {
                    enlazar();
                    MessageBox.Show("Usuario desbloqueado con éxito.");
                }
                else
                {
                    MessageBox.Show("Hubo un error al intentar desbloquear el usuario.");
                }
            }
        }
    }
}
