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
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace UI
{
    public partial class FormReporteRecaudacion : Form
    {
        public FormReporteRecaudacion()
        {
            InitializeComponent();
        }

        private void FormReporteRecaudacion_Load(object sender, EventArgs e)
        {
            TraducirComponentes();
            enlazarOrdenamientos();
            enlazarReporte();
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

        private void enlazarOrdenamientos()
        {
            cb_orden.Items.Clear();
            cb_orden.Items.Add("Ascendente");
            cb_orden.Items.Add("Descendente");
        }

        //logica core del reporte
        private void enlazarReporte()
        {
            Boolean ordenDescendente = false;

            if (cb_orden.SelectedItem is not null)
            {
                string ordenElegido = (string)cb_orden.SelectedItem;

                ordenDescendente = ordenElegido.Equals("Descendente");
            }

            dgv_recaudacion.DataSource = null;
            dgv_recaudacion.DataSource = BLL.ExpensaBLL.Instance.BuscarRecaudacionPorPeriodo(ordenDescendente);

            // Dar formato de moneda a la columna de 'recaudacion'
            DataGridViewCellStyle currencyStyle = new DataGridViewCellStyle();
            currencyStyle.Format = "C";
            dgv_recaudacion.Columns["RECAUDACION"].DefaultCellStyle = currencyStyle;

        }

        //deprecado
        private void dgv_recaudacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //si elegi otra opcion, refresco el reporte
        private void cb_orden_SelectedIndexChanged(object sender, EventArgs e)
        {
            enlazarReporte();
        }

        //logica para generar el pdf
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            // Crear un nuevo documento PDF
            Document doc = new Document();

            try
            {
                string rutaArchivoPDF = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\pdfs\\archivo.pdf";

                // Obtener la ruta del directorio donde se encuentra el proyecto
                //string directorioProyecto = Directory.GetCurrentDirectory();

                // Nombre del archivo PDF a generar
                //string nombreArchivoPDF = "archivo.pdf";

                // Combinar la ruta del directorio con el nombre del archivo para obtener la ruta completa
               // string rutaArchivoPDF = Path.Combine(directorioProyecto, nombreArchivoPDF);

                PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));

                doc.Open();

                PdfPTable table = new PdfPTable(dgv_recaudacion.Columns.Count);

                for (int i = 0; i < dgv_recaudacion.Columns.Count; i++)
                {
                    table.AddCell(new Phrase(dgv_recaudacion.Columns[i].HeaderText));
                }

                table.HeaderRows = 1;

                for (int i = 0; i < dgv_recaudacion.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_recaudacion.Columns.Count; j++)
                    {
                        if (dgv_recaudacion.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(new Phrase(dgv_recaudacion.Rows[i].Cells[j].Value.ToString()));
                        }
                    }
                }

                doc.Add(table);

                doc.Close();

                MessageBox.Show("PDF generado con éxito en la ruta: " + rutaArchivoPDF);

                try
                {
                    // Abrir el archivo PDF con el programa predeterminado del sistema
                    Process.Start(new ProcessStartInfo(rutaArchivoPDF) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo PDF: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
            finally
            {
                doc.Close();
            }
        }
    }
}
