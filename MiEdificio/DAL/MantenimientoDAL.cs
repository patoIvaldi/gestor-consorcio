using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class MantenimientoDAL
    {

        Acceso acceso = new Acceso();

        public void realizarBackup(Services.ServiceBackup backup)
        {
            try
            {
                // Consulta SQL para realizar el respaldo
                string backupQuery = $"BACKUP DATABASE MiEdificio TO DISK = '{backup.DIRECTORIO + backup.NOMBRE_ARCHIVO}'";
                int modificados = acceso.escribir(backupQuery, null, CommandType.Text);
                if (modificados > 0)
                {
                    MessageBox.Show("Respaldo exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al realizar el respaldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el respaldo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void realizarRestore(Services.ServiceRestore restore)
        {

        }



    }
}
