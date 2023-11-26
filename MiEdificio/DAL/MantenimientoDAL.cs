using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class MantenimientoDAL
    {

        Acceso acceso = new Acceso();

        //metodo que genrar el archivo de backup de la BD
        public void realizarBackup(Services.ServiceBackup backup)
        {
            try
            {
                // Consulta SQL para realizar el respaldo
                string backupQuery = $"BACKUP DATABASE REPOSITORIO TO DISK = '{backup.DIRECTORIO + backup.NOMBRE_ARCHIVO}'";
                int modificados = acceso.escribir(backupQuery, null, CommandType.Text);
                if (modificados != 0)
                {
                    MessageBox.Show("Backup exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al realizar el Backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el Backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //metodo que genera el restore de la BD.
        public void realizarRestore(Services.ServiceRestore restore)
        {
            try
            {
                StringBuilder query = new StringBuilder($"USE MASTER ALTER DATABASE REPOSITORIO SET OFFLINE WITH ROLLBACK IMMEDIATE; ");
                query.Append($"RESTORE DATABASE REPOSITORIO FROM DISK = '{restore.DIRECTORIO + restore.NOMBRE_ARCHIVO}' WITH REPLACE ");
                query.Append($"ALTER DATABASE REPOSITORIO SET ONLINE WITH ROLLBACK IMMEDIATE;");

                int modificados = acceso.escribir(query.ToString(), null, CommandType.Text);

                if (modificados != 0)
                {
                    MessageBox.Show("Se generó exitosamente el restore de la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al realizar el restore de la BD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el restore de la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
