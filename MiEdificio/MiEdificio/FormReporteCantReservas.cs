using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UI
{
    public partial class FormReporteCantReservas : Form
    {
        public FormReporteCantReservas()
        {
            InitializeComponent();
        }

        private void FormReporteCantReservas_Load(object sender, EventArgs e)
        {
            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario ingresó a la pantalla de reporte cantidad de reservas por usuario.";
            evento.CRITICIDAD = Enumerador.Criticidad.Baja.ToString();
            evento.OPERACION = Enumerador.Operacion.Iniciar.ToString();
            evento.MODULO = Enumerador.Modulo.Reportes.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);

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

        private void enlazarReporte()
        {
            Boolean ordenDescendente = false;

            if (cb_orden.SelectedItem is not null)
            {
                string ordenElegido = (string)cb_orden.SelectedItem;

                ordenDescendente = ordenElegido.Equals("Descendente");
            }

            dgv_cantReservas.DataSource = null;
            dgv_cantReservas.DataSource = BLL.ReservasBLL.Instance.BuscarCantidadReservas(ordenDescendente);
            dgv_cantReservas.Columns["IDV"].Visible = false;

        }

        private void cb_orden_SelectedIndexChanged(object sender, EventArgs e)
        {
            enlazarReporte();
            btn_serializar.Enabled = true;
        }

        //boton con la logica para serializar la informacion del datagridview en un archivo xml
        private void btn_serializar_Click(object sender, EventArgs e)
        {

            DirectoryInfo directorioPadre = Directory.GetParent(Application.StartupPath);
            DirectoryInfo directorioAbuelo = Directory.GetParent(directorioPadre.FullName);
            DirectoryInfo directorioBisAbuelo = Directory.GetParent(directorioAbuelo.FullName);
            DirectoryInfo directorioTataraAbuelo = Directory.GetParent(directorioBisAbuelo.FullName);
            string rutaArchivoXML = Path.Combine(directorioTataraAbuelo.FullName, "Resources", "archivos");

            //string rutaArchivoXML = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\archivos\\";
            string nombreArchivo = "cantReservas";

            DataSet serializado = BLL.GenericHelper.Instance.SerializarObjetoEnXML((DataTable)dgv_cantReservas.DataSource, rutaArchivoXML, nombreArchivo);

            try
            {
                // Abrir el archivo XML con el programa predeterminado del sistema
                Process.Start(new ProcessStartInfo(rutaArchivoXML + nombreArchivo + ".xml") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo XML: " + ex.Message);
            }

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario serializo un archivo.";
            evento.CRITICIDAD = Enumerador.Criticidad.Media.ToString();
            evento.OPERACION = Enumerador.Operacion.Modificar.ToString();
            evento.MODULO = Enumerador.Modulo.Reportes.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);
        }

        //boton con la logica para deserializar un archivo xml y cargarlo en el datagridview
        private void btn_deserializar_Click(object sender, EventArgs e)
        {

            DirectoryInfo directorioPadre = Directory.GetParent(Application.StartupPath);
            DirectoryInfo directorioAbuelo = Directory.GetParent(directorioPadre.FullName);
            DirectoryInfo directorioBisAbuelo = Directory.GetParent(directorioAbuelo.FullName);
            DirectoryInfo directorioTataraAbuelo = Directory.GetParent(directorioBisAbuelo.FullName);
            string rutaArchivoXML = Path.Combine(directorioTataraAbuelo.FullName, "Resources", "archivos");

            //string rutaArchivoXML = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\archivos\\";
            string nombreArchivo = "cantReservas";

            DataSet dataSet = new DataSet();

            // Leer el archivo XML y cargarlo en el DataSet
            dataSet.ReadXml(openFileDialog1.FileName);

            // Obtener el DataTable del DataSet (suponiendo que solo hay un DataTable)
            DataTable dataTableFromXML = dataSet.Tables.Count > 0 ? dataSet.Tables[0] : null;

            //cargamos el dgv
            dgv_cantReservas.DataSource = null;
            dgv_cantReservas.DataSource = dataTableFromXML;

            btn_serializar.Enabled = false;

            BE.Evento evento = new Evento();
            evento.USUARIO = Services.ServiceSesion.Instance.USER;
            evento.DETALLE = "El usuario deserializo un archivo.";
            evento.CRITICIDAD = Enumerador.Criticidad.Media.ToString();
            evento.OPERACION = Enumerador.Operacion.Modificar.ToString();
            evento.MODULO = Enumerador.Modulo.Reportes.ToString();

            BLL.EventoBLL.Instance.AgregarEvento(evento);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            tb_buscar.Text = " ...";
            openFileDialog1.Title = "Elija el archivo a deserializar.";

            DirectoryInfo directorioPadre = Directory.GetParent(Application.StartupPath);
            DirectoryInfo directorioAbuelo = Directory.GetParent(directorioPadre.FullName);
            DirectoryInfo directorioBisAbuelo = Directory.GetParent(directorioAbuelo.FullName);
            DirectoryInfo directorioTataraAbuelo = Directory.GetParent(directorioBisAbuelo.FullName);
            string rutaArchivoXML = Path.Combine(directorioTataraAbuelo.FullName, "Resources", "archivos");

            //openFileDialog1.InitialDirectory = "C:\\Users\\Pato\\Desktop\\Facultad\\Trabajo de Campo\\Proyecto\\MiEdificio\\MiEdificio\\Resources\\archivos\\"; // Directorio inicial
            openFileDialog1.InitialDirectory = rutaArchivoXML+"\\"; // Directorio inicial
            openFileDialog1.Filter = "Archivos XML (*.xml)|*.xml"; // Filtros de archivo

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> rutaArchivoSelected = openFileDialog1.FileName.Split("\\").ToList();

                //lo mostramos en el textbox
                tb_buscar.Text = tb_buscar.Text + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 2)
                    + "\\" + rutaArchivoSelected.ElementAt(rutaArchivoSelected.Count - 1);

                btn_deserializar.Enabled = true;
            }
            else
            {
                btn_deserializar.Enabled = false;
            }

        }
    }
}
