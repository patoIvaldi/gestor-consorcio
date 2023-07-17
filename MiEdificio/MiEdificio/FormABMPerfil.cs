using BE;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FormABMPerfil : Form
    {
        BE.PermisoSimple permisoSelected;
        BE.PermisoSimple permisoElegido2;
        BE.Perfil perfilSelected;

        public FormABMPerfil()
        {
            InitializeComponent();
        }

        private void FormABMPerfil_Load(object sender, EventArgs e)
        {
            enlazarPerfiles();
            enlazarPermisos();
            CargarComboBoxPermisos();
        }

        private void CargarComboBoxPermisos()
        {
            cb_asociar.Items.Clear();
            cb_asociar.Items.AddRange(BLL.PermisoBLL.Instance.ObtenerPermisosConfigurados().ToArray());
        }

        private void enlazarPerfiles()
        {
            dgv_perfil.DataSource = null;
            dgv_perfil.DataSource = BLL.PerfilBLL.Instance.ObtenerPerfiles();
        }

        private void enlazarPermisos()
        {
            dgv_permiso.DataSource = null;
            dgv_permiso.DataSource = BLL.PermisoBLL.Instance.ObtenerPermisosConfigurados();
        }

        private void enlazarPermisosDelPerfil(BE.Perfil perf)
        {
            dgv_perperfil.DataSource = null;
            dgv_perperfil.DataSource = BLL.PermisoBLL.Instance.ObtenerPermisosAsociadosAlPerfil(perf);
        }

        //logica cuando selecciono un perfil
        private void dgv_perfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            perfilSelected = (BE.Perfil)dgv_perfil.Rows[e.RowIndex].DataBoundItem;

            if (perfilSelected is not null)
            {
                enlazarPermisosDelPerfil(perfilSelected);

                uC_tb_idPerfil.TEXT_BOX = perfilSelected.ID_TIPO.ToString();
                uC_tb_descPerfil.TEXT_BOX = perfilSelected.DESCRIPCION;
            }
        }

        //logica cuando selecciono un permiso
        private void dgv_permiso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            permisoSelected = (BE.PermisoSimple)dgv_permiso.Rows[e.RowIndex].DataBoundItem;

            if (permisoSelected is not null)
            {
                enlazarPermisosDelPermiso(permisoSelected);

                uC_tb_idPermiso.TEXT_BOX = permisoSelected.ID_TIPO.ToString();
                uC_tb_descPermiso.TEXT_BOX = permisoSelected.DESCRIPCION;
                uC_tb_nombrePermiso.TEXT_BOX = permisoSelected.NOMBRE;
            }
        }

        private void enlazarPermisosDelPermiso(BE.PermisoSimple permSel)
        {
            dgv_perper.DataSource = null;
            dgv_perper.DataSource = BLL.PermisoBLL.Instance.ObtenerPermisosHijos(permSel);
        }

        //logica boton limpiar perfil
        private void btn_limpiarPerfil_Click(object sender, EventArgs e)
        {
            limpiarCamposPerfil();
        }

        //limpiamos los campos de la abm perfil
        private void limpiarCamposPerfil()
        {
            uC_tb_idPerfil.TEXT_BOX = "";
            uC_tb_descPerfil.TEXT_BOX = "";
            enlazarPerfiles();
        }

        //limpiamos los campos de la abm permiso
        private void limpiarCamposPermiso()
        {
            uC_tb_idPermiso.TEXT_BOX = "";
            uC_tb_descPermiso.TEXT_BOX = "";
            uC_tb_nombrePermiso.TEXT_BOX = "";
            enlazarPermisos();
        }

        //logica boton limpiar permiso
        private void btn_limparPermiso_Click(object sender, EventArgs e)
        {
            limpiarCamposPermiso();
        }

        //logica boton guardar perfil
        private void btn_guardarPerfil_Click(object sender, EventArgs e)
        {
            if (validarControlesPerfil())
            {
                BE.Perfil perf = new BE.Perfil();
                perf.ID_TIPO = !uC_tb_idPerfil.TEXT_BOX.IsNullOrEmpty() ?
                    int.Parse(uC_tb_idPerfil.TEXT_BOX) : 0;
                perf.DESCRIPCION = uC_tb_descPerfil.TEXT_BOX;

                if (BLL.PerfilBLL.Instance.InsertarOModificar(perf))
                {
                    MessageBox.Show("Perfil insertado/modificado con éxito!");
                    limpiarCamposPerfil();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo guardar el Perfil");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos requeridos asociados al Perfil.");
            }
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControlesPerfil()
        {
            Boolean validacionOK = true;

            foreach (Control c in gb_perfil.Controls)
            {
                //itero hasta encontrar alguno incorrecto
                if (validacionOK)
                {
                    if (c is UC_textbox)
                    {
                        validacionOK = ((UC_textbox)c).validar();

                    }
                    else if (c is UC_tb_numerico)
                    {
                        validacionOK = ((UC_tb_numerico)c).validar();
                    }
                }
            }
            return validacionOK;
        }

        //metodo para validar los controles que esten cargados si son requeridos
        private Boolean validarControlesPermiso()
        {
            Boolean validacionOK = true;

            foreach (Control c in gb_permiso.Controls)
            {
                //itero hasta encontrar alguno incorrecto
                if (validacionOK)
                {
                    if (c is UC_textbox)
                    {
                        validacionOK = ((UC_textbox)c).validar();

                    }
                    else if (c is UC_tb_numerico)
                    {
                        validacionOK = ((UC_tb_numerico)c).validar();
                    }
                }
            }
            return validacionOK;
        }

        //logica boton guardar permiso
        private void btn_guardarPermiso_Click(object sender, EventArgs e)
        {
            if (validarControlesPermiso())
            {
                BE.PermisoSimple permiso = new BE.PermisoSimple(
                    uC_tb_nombrePermiso.TEXT_BOX, uC_tb_descPermiso.TEXT_BOX);
                permiso.ID_TIPO = !uC_tb_idPermiso.TEXT_BOX.IsNullOrEmpty() ?
                    int.Parse(uC_tb_idPermiso.TEXT_BOX) : 0;

                if (BLL.PermisoBLL.Instance.InsertarOModificar(permiso))
                {
                    MessageBox.Show("Permiso insertado/modificado con éxito!");
                    limpiarCamposPermiso();
                    CargarComboBoxPermisos();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo guardar el Permiso.");
                }
            }
            else
            {
                MessageBox.Show("Debe completar los campos requeridos asociados al Permiso.");
            }
        }

        //logica boton borrar perfil
        private void btn_borrarPerfil_Click(object sender, EventArgs e)
        {
            if (!uC_tb_idPerfil.TEXT_BOX.IsNullOrEmpty())
            {
                BE.Perfil perf = new BE.Perfil();
                perf.ID_TIPO = int.Parse(uC_tb_idPerfil.TEXT_BOX);
                perf.DESCRIPCION = uC_tb_descPerfil.TEXT_BOX;

                if (BLL.PerfilBLL.Instance.Borrar(perf))
                {
                    MessageBox.Show("Se borró el perfil con éxito.");
                    limpiarCamposPerfil();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo borrar el perfil.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil para borrar.");
            }
        }

        //logica boton eliminar permiso
        private void btn_eliminarPermiso_Click(object sender, EventArgs e)
        {
            if (!uC_tb_idPermiso.TEXT_BOX.IsNullOrEmpty())
            {
                BE.PermisoSimple permiso = new BE.PermisoSimple(
                    uC_tb_nombrePermiso.TEXT_BOX, uC_tb_descPermiso.TEXT_BOX);
                permiso.ID_TIPO = int.Parse(uC_tb_idPermiso.TEXT_BOX);

                if (BLL.PermisoBLL.Instance.Borrar(permiso))
                {
                    MessageBox.Show("Se borró el permiso con éxito.");
                    limpiarCamposPermiso();
                }
                else
                {
                    MessageBox.Show("Error, no se pudo borrar el permiso.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un permiso para borrar.");
            }
        }

        //logica boton asignar permiso a perfil
        private void btn_asignar_Click(object sender, EventArgs e)
        {
            if (permisoSelected is not null && perfilSelected is not null)
            {
                if (!BLL.PermisoBLL.Instance.ExistePermisoEnPerfil(
                    perfilSelected.ID_TIPO, permisoSelected.ID_TIPO))
                {
                    if (BLL.PermisoBLL.Instance.AsociarPermisoPefil(
                        perfilSelected.ID_TIPO, permisoSelected.ID_TIPO))
                    {
                        MessageBox.Show("Se asoció el permiso al perfil exitosamente!");
                        enlazarPermisosDelPerfil(perfilSelected);
                    }
                    else
                    {
                        MessageBox.Show("Error, no se pudo asociar el permiso al perfil.");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe el permiso en el perfil.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil y el permiso que quiere asociarle.");
            }
        }

        //logica boton desasociar permisos al perfil
        private void btn_desasignar_Click(object sender, EventArgs e)
        {
            if (permisoSelected is not null && perfilSelected is not null)
            {
                if (BLL.PermisoBLL.Instance.ExistePermisoEnPerfil(
                    perfilSelected.ID_TIPO, permisoSelected.ID_TIPO))
                {
                    if (BLL.PermisoBLL.Instance.DesasociarPermisoPefil(
                        perfilSelected.ID_TIPO, permisoSelected.ID_TIPO))
                    {
                        MessageBox.Show("Se quitó el permiso al perfil exitosamente!");
                        enlazarPermisosDelPerfil(perfilSelected);
                    }
                    else
                    {
                        MessageBox.Show("Error, no se pudo quitar el permiso al perfil.");
                    }
                }
                else
                {
                    MessageBox.Show("No existe relación entre el permiso y el perfil.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un perfil y el permiso que quiere desasociar.");
            }
        }

        private void btn_relPerPer_Click(object sender, EventArgs e)
        {
            if (permisoSelected is not null && permisoElegido2 is not null)
            {
                if (!BLL.PermisoBLL.Instance.ExistePermisoEnPermiso(
                    permisoSelected.ID_TIPO, permisoElegido2.ID_TIPO))
                {
                    if (BLL.PermisoBLL.Instance.AsociarPermisoPermiso(
                        permisoSelected.ID_TIPO, permisoElegido2.ID_TIPO))
                    {
                        MessageBox.Show("Se asociaron los permisos exitosamente!");
                        enlazarPermisosDelPermiso(permisoSelected);
                    }
                    else
                    {
                        MessageBox.Show("Error, no se pudo asociar los permisos entre sí.");
                    }
                }
                else
                {
                    MessageBox.Show("Ambos permisos ya se encuentra relacionados entre sí.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar dos permisos que quiera relacionar entre sí.");
            }
        }

        private void cb_asociar_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisoElegido2 = (BE.PermisoSimple)cb_asociar.SelectedItem;
        }
    }
}
