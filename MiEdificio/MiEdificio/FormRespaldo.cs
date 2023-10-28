using Microsoft.Data.SqlClient;
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
    public partial class FormRespaldo : Form
    {
        public FormRespaldo()
        {
            InitializeComponent();
        }

        //metodo buscar archivo restore
        private void btn_Restore_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Elija el archivo de backup a restaurar.";

            //openFileDialog1.InitialDirectory = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\Backups-BD\\"; // Directorio inicial
            openFileDialog1.InitialDirectory = "C:\\Users\\Pato\\Downloads\\"; // Directorio inicial
            openFileDialog1.Filter = "Archivos de respaldo de SQL Server (*.bak)|*.bak"; // Filtros de archivo

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> rutaArchivoSelected = openFileDialog1.FileName.Split("\\").ToList();

                //lo mostramos en el textbox
                tb_dirRestore.Text = tb_dirRestore.Text + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 2)
                    + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 1);
            }
        }

        //metodo del boton generar backup
        private void btn_bkp_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.InitialDirectory = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\Backups-BD\\";
            saveFileDialog1.InitialDirectory = "C:\\Users\\Pato\\Downloads\\";
            saveFileDialog1.Filter = "Archivos de respaldo de SQL Server (*.bak)|*.bak";
            saveFileDialog1.Title = "Guardar respaldo de la base de datos";
            saveFileDialog1.FileName = "Backup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> rutaArchivoSelected = saveFileDialog1.FileName.Split("\\").ToList();

                tb_dirBKP.Text = tb_dirBKP.Text + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 2)
                    + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 1);

                try
                {
                    Services.ServiceBackup backup = new Services.ServiceBackup();
                    backup.AUTOR = Services.ServiceSesion.Instance.USER;
                    backup.DIRECTORIO = saveFileDialog1.InitialDirectory;
                    backup.NOMBRE_ARCHIVO = rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 1);

                    //llamamos al servicio de backup
                    BLL.MantenimientoBLL.Instance.crearBackup(backup);

                    MessageBox.Show("Respaldo exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar el respaldo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //boton limpiar
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tb_dirBKP.Text = " ...";
            tb_dirRestore.Text = " ...";
        }

        //boton confirmar restore
        private void btn_confirmarRestore_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> rutaArchivoSelected = openFileDialog1.FileName.Split("\\").ToList();

                Services.ServiceRestore restore = new Services.ServiceRestore();
                restore.AUTOR = Services.ServiceSesion.Instance.USER;
                restore.DIRECTORIO = openFileDialog1.InitialDirectory;
                restore.NOMBRE_ARCHIVO = rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 1);

                //llamamos al servicio de restore
                BLL.MantenimientoBLL.Instance.crearRestore(restore);

                MessageBox.Show("Restore exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el restore de la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
